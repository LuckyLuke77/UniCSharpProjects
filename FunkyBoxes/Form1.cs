//----------------------------
//LEONIDAS PASTRAS
//P20155
//12-22-2021
//----------------------------

using System;
using System.Drawing;
using System.Windows.Forms;

namespace SoloEx2 {
    public partial class Form1 : Form {
        public Button[] allButtons = new Button[0];
        public int buttonCount;
        public Form1() {
            InitializeComponent();
            CenterUI();
        }

        private void StartButton_Click(object sender, EventArgs e) {
            if (ValidUserValue(ButtonCount())) {
                DestroyButtons();
                buttonCount = Int32.Parse(ButtonCount());
                if (Int32.Parse(ButtonCount()) > allButtons.Length) {
                    Array.Resize(ref allButtons, buttonCount);
                }
                allButtons = new Button[buttonCount];
                CreateButtons();
                timer1.Enabled = true;
            } else {
                MessageBox.Show("Invalid value; Enter an integer");
            }
        }
        void DestroyButtons() { //Deletes all dynamic buttons
            foreach(Button button in allButtons) {
                button.Dispose();
            }
        }

        void CreateButtons() {
            int horizontalButtons = HorizontalButtons();
            int newButtonCount = 1;
            int j = 1;
            do { 
                for (int i = 1; i <= horizontalButtons; i++) {
                    Button myButton = new Button();
                    allButtons[newButtonCount - 1] = myButton;
                    myButton.Location = new System.Drawing.Point(50 * i - 50, 50 * j + 30);
                    myButton.Name = newButtonCount.ToString();
                    myButton.Size = new System.Drawing.Size(50, 50);
                    myButton.Text = newButtonCount.ToString();
                    ButtonBeautification(myButton);
                    myButton.Click += new System.EventHandler(this.codeForMyButton);
                    this.Controls.Add(myButton);
                    newButtonCount++;
                    if (newButtonCount == buttonCount + 1) {
                        break;
                    }
                }
                j++;
            } while (newButtonCount != buttonCount + 1);
        }

        void ButtonBeautification(Button myButton) { //Makes the button very beatiful :-)
            //Colors the button with a random color:
            Random rnd = new Random(DateTime.Now.Millisecond); 
            int red = rnd.Next(256);
            int green = rnd.Next(256);
            int blue = rnd.Next(256);
            myButton.BackColor = Color.FromArgb(red, green, blue);
            //Colors the text color with the negative value of the former color:
            int redNeg = 255 - red;
            int greenNeg = 255 - green;
            int blueNeg = 255 - blue;
            myButton.ForeColor = Color.FromArgb(redNeg, greenNeg, blueNeg);
            //Removes the buttons border:
            myButton.TabStop = false;
            myButton.FlatStyle = FlatStyle.Flat;
            myButton.FlatAppearance.BorderSize = 0;
        }
 
        void codeForMyButton(object sender, EventArgs e)
        {
            for(int i = 0; i < buttonCount; i++) {
                if (allButtons[i] == sender) {
                    MessageBox.Show((i + 1).ToString());
                }
            }
        }

        string ButtonCount() {
            string buttonCount = textBox1.Text;
            return buttonCount;
        }

        bool ValidUserValue(string userValue) { //Checks if the users value is valid or not
            int temp;
            bool isInteger = int.TryParse(userValue, out temp);
            if (isInteger) {
                bool isPositive = temp > 0;
                if (isPositive) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }

        void RearrangeButtons() { 
           int horizontalButtons = HorizontalButtons();
           int newButtonCount = 1;
           int j = 1;
           do { 
               for (int i = 1; i <= horizontalButtons; i++) {
                   allButtons[newButtonCount - 1].Location = new Point(50 * i - 50, 50 * j + 30);
                   newButtonCount++;
                   if (newButtonCount == buttonCount + 1) {
                       break;
                   }
               }
               j ++;
           } while (newButtonCount != buttonCount + 1);
        }

        void CenterUI() { //Centers textBox1 and StartButton
            int width = this.Size.Width;
            StartButton.Location = new Point(width/2 - StartButton.Width/2, StartButton.Location.Y);
            textBox1.Location = new Point(width/2 - textBox1.Width/2, textBox1.Location.Y);
        }

        int HorizontalButtons() { //Counts how many buttons can fit horizontaly
            int width = this.Size.Width;
            int horizontalButtons = width / 50;
            return horizontalButtons;
        }

        private void timer1_Tick(object sender, EventArgs e) { //tick tock
            RearrangeButtons();
            CenterUI();
        }
    }
}
