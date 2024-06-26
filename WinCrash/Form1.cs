using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinCrash
{
    public partial class Form1 : Form
    {
        private string[] faces = { ":(", ":3", "x3", ";3", "uwu", "owo", ":)", ":o", ":p", ">w<", "^w^", "SOWWY" };
        private int currentFaceIndex = 0;
        private string originalMainText = "Your PC ran into a problem and needs to restart. We're just collecting some error info, and then we'll restart for you.";
        private string alternateMainText = "Oopsie Woopsie! Uwu We made a fucky wucky!! A wittle fucko boingo! The code monkeys at our headquarters are working VEWY HAWD to fix this!";
        private string[] stopcodes = { "0x00000000", "0x00000152", "0x00000085", "0x00000001", "0x00000102" };
        private int percentComplete = 0;
        private Random random = new Random();
        private LowLevelKeyboardProc _proc;
        private IntPtr _hookID = IntPtr.Zero;

        public Form1()
        {
            InitializeComponent();
            percentTimer.Interval = GetRandomInterval();
            percentTimer.Tick += percentTimer_Tick;
            percentTimer.Start();

            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.Cursor = Cursors.No;

            stopcodeLabel.Text = stopcodes[random.Next(stopcodes.Length)];

            _proc = HookCallback;
            _hookID = SetHook(_proc);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            this.KeyPreview = true;
            Cursor.Hide();
        }

        private async void percentTimer_Tick(object sender, EventArgs e)
        {
            if (random.Next(0, 10) < 2) // 20% chance to do nothing
            {
                return;
            }
            else if (random.Next(0, 10) < 3) // 30% chance to jump by a significant amount
            {
                percentComplete += random.Next(5, 15); // Jump by 5 to 15 percent
            }
            else
            {
                percentComplete++;
            }

            if (percentComplete > 100)
            {
                percentComplete = 100;
            }

            percentageLabel.Text = $"{percentComplete}% complete";

            if (percentComplete >= 100)
            {
                percentTimer.Stop();
                percentageLabel.Text = "100% complete";
                await Task.Delay(2000);

                this.BackColor = Color.Black;
                faceLabel.Visible = false;
                maintextLabel.Visible = false;
                percentageLabel.Visible = false;
                stopcodeLabel.Visible = false;
                infoLabel.Visible = false;
                infoText.Visible = false;
                qrcode.Visible = false;
                await Task.Delay(2000);

                winLogo.Visible = true;
                await Task.Delay(2000);

                loadingAnimPicturebox.Visible = true;
                await Task.Delay(10000);

                loadingAnimPicturebox.Visible = false;
                winLogo.Visible = false;
                await Task.Delay(2000);
                this.BackColor = ColorTranslator.FromHtml("#0078D7");

                faceLabel.Visible = true;
                maintextLabel.Visible = true;
                percentageLabel.Visible = true;
                stopcodeLabel.Visible = true;
                infoLabel.Visible = true;
                infoText.Visible = true;
                qrcode.Visible = true;

                percentComplete = 0;
                percentageLabel.Text = $"{percentComplete}% complete";
                percentTimer.Start();
            }
            else
            {
                percentTimer.Interval = GetRandomInterval();
            }
        }

        private int GetRandomInterval()
        {
            return random.Next(500, 2000);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if Alt + U is pressed
            if (e.Alt && e.KeyCode == Keys.U)
            {
                this.Close();
            }

            // Check if Up or Down arrow key is pressed
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                maintextLabel.Text = maintextLabel.Text == originalMainText ? alternateMainText : originalMainText;
            }

            // Check if left or right arrow key is pressed
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                if (e.KeyCode == Keys.Left)
                {
                    currentFaceIndex = (currentFaceIndex - 1 + faces.Length) % faces.Length;
                }
                else if (e.KeyCode == Keys.Right)
                {
                    currentFaceIndex = (currentFaceIndex + 1) % faces.Length;
                }

                faceLabel.Text = faces[currentFaceIndex];
            }
        }

        // Set the hook
        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        // Unhook when the application is closed
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            UnhookWindowsHookEx(_hookID);
            base.OnFormClosing(e);
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                // Disable Alt+Tab, Ctrl+Shift+Esc, Windows Key
                if ((vkCode == (int)Keys.Tab && ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)) ||
                    (vkCode == (int)Keys.Escape && ((Control.ModifierKeys & Keys.Control) == Keys.Control) && ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)) ||
                    (vkCode == (int)Keys.LWin) || (vkCode == (int)Keys.RWin))
                {
                    return (IntPtr)1; // Block these key combinations
                }
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        //Disable F4
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
	        if (keyData == (Keys.Alt | Keys.F4))
	        {
		        return true;
	        }
	        return base.ProcessCmdKey(ref msg, keyData);
        }

		// P/Invoke declarations
		private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
