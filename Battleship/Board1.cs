using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace battleship {
    //COMPUTER BOARD (The one where the player presses buttons)
    public class Board1 {
        public static Button[] allButtons = new Button[100];
        public static Button[] starterButtons = new Button[20];
        public static Button[] CreateBoard1Array() {
            for (int i = 0; i < 10; i++) {
                for (int j = 0; j < 10; j++) {
                    Button myButton = new Button();
                    myButton.Location = new System.Drawing.Point(40 * j + 120, 40 * i + 120);
                    myButton.Name = "sea";
                    myButton.Size = new System.Drawing.Size(40, 40);
                    myButton.Text = "";
                    myButton.Tag = "notPressed";
                    myButton.FlatStyle = FlatStyle.Popup;
                    myButton.FlatAppearance.BorderSize = 0;
                    myButton.Font = new Font(myButton.Font.FontFamily, 20, FontStyle.Bold);
                    myButton.BackColor = Color.Blue;
                    allButtons[i * 10 + j] = myButton;
                }
            }
            return allButtons;
        }
        public void ClearBoard() {
            foreach(Button myButton in allButtons) {
                myButton.Name = "sea";
                myButton.Text = "";
                myButton.Tag = "notPressed";
                myButton.BackColor = Color.Blue;
            }
        }
    }
}
