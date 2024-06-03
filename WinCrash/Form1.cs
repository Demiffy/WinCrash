using System;

namespace WinCrash
{
    public partial class Form1 : Form
    {
        private int percentComplete = 0;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            percentTimer.Interval = GetRandomInterval();
            percentTimer.Tick += percentTimer_Tick;
            percentTimer.Start();
        }

        private async void percentTimer_Tick(object sender, EventArgs e)
        {
            // Introduce random jumps and stops
            if (random.Next(0, 10) < 2) // 20% chance to do nothing (simulate pause)
            {
                return;
            }
            else if (random.Next(0, 10) < 3) // 30% chance to jump by a significant amount
            {
                percentComplete += random.Next(5, 15); // Jump by 5 to 15 percent
            }
            else
            {
                percentComplete++; // Increment the percentage by 1
            }

            // Ensure percentComplete does not exceed 100
            if (percentComplete > 100)
            {
                percentComplete = 100;
            }

            percentageLabel.Text = $"{percentComplete}% complete";

            // If percentage reaches 100, stop the timer and change the form's background to black
            if (percentComplete >= 100)
            {
                percentTimer.Stop();
                percentageLabel.Text = "100% complete";
                await Task.Delay(2000); // Wait for 2 seconds

                this.BackColor = Color.Black;
                faceLabel.Visible = false;
                maintextLabel.Visible = false;
                percentageLabel.Visible = false;
                stopcodeLabel.Visible = false;
                infoLabel.Visible = false;
                infoText.Visible = false;
                qrcode.Visible = false;
                await Task.Delay(2000); // Wait for 2 seconds

                winLogo.Visible = true;
                await Task.Delay(2000); // Wait for 2 seconds

                loadingAnimPicturebox.Visible = true;
                await Task.Delay(10000); // Wait for 10 seconds

                loadingAnimPicturebox.Visible = false;
                winLogo.Visible = false;
                await Task.Delay(2000); // Wait for 2 seconds
                this.BackColor = ColorTranslator.FromHtml("#0078D7"); // Restore original BSOD color

                // Show all the labels and controls
                faceLabel.Visible = true;
                maintextLabel.Visible = true;
                percentageLabel.Visible = true;
                stopcodeLabel.Visible = true;
                infoLabel.Visible = true;
                infoText.Visible = true;
                qrcode.Visible = true;

                // Reset percentage complete
                percentComplete = 0;
                percentageLabel.Text = $"{percentComplete}% complete";
                percentTimer.Start();
            }
            else
            {
                // Set the next random interval
                percentTimer.Interval = GetRandomInterval();
            }
        }

        private int GetRandomInterval()
        {
            return random.Next(500, 2000); // Random interval between 0.5 and 2 seconds
        }
    }
}