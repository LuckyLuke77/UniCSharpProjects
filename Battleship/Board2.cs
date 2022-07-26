using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace battleship {
    //PLAYER BOARD
    public class Board2 {
        public static Button[] allButtons = new Button[100];
        public static Button[] starterButtons = new Button[20];
        public static Button[] CreateBoard2Array() {
            for (int i = 0; i < 10; i++) {
                for (int j = 0; j < 10; j++) {
                    Button myButton = new Button();
                    myButton.Location = new System.Drawing.Point(40 * j + 640, 40 * i + 120);
                    myButton.Name = "sea";
                    myButton.Size = new System.Drawing.Size(40, 40);
                    myButton.Tag = "notHit";
                    //myButton.Enabled = false;
                    myButton.FlatStyle = FlatStyle.Popup;
                    myButton.FlatAppearance.BorderSize = 0;
                    myButton.BackColor = Color.Blue;
                    myButton.Font = new Font(myButton.Font.FontFamily, 20, FontStyle.Bold);
                    myButton.ForeColor = Color.White;
                    allButtons[i * 10 + j] = myButton;
                }
            }
            return allButtons;
        }
        public static void ClearBoard() {
            foreach(Button myButton in allButtons) {
                myButton.Name = "sea";
                myButton.Text = "";
                myButton.Tag = "notHit";
                myButton.BackColor = Color.Blue;
            }
        }
    }
}
