using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace battleship {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        
        int computerSubmarineHP= 2;
        int computerWarshipHP = 3;
        int computerDestroyerHP = 4;
        int computerAircraftcarrierHP = 5;
        int computerShipRemaining = 4;
        int playerSubmarineHP= 2;
        int playerWarshipHP = 3;
        int playerDestroyerHP = 4;
        int playerAircraftcarrierHP = 5;
        int playerShipRemaining = 4;
        bool itsPlayersTurn = true;
        int turn = 1;
        double time = 0;
        int wins = 0;
        int loses = 0;

        private void Form1_Load(object sender, EventArgs e) {
            tableBindingSource.AddNew();
            MakeButton1Beatiful(); //stylize the "Match History" button
            CreateBoards();
            GeneratePlayerShips();
            GenerateComputerShips();
            timer1.Start();
        }
        private void CreateBoards() {
            foreach(Button myButton in Board1.CreateBoard1Array()) { //Creates Board1 (The one that the players clicks on)
                this.Controls.Add(myButton);
                myButton.Click += new System.EventHandler(this.codeForMyButton);
            }
            foreach(Button myButton in Board2.CreateBoard2Array()) { //Creates Board2 (The one the players ships are)
                this.Controls.Add(myButton);
            }
            foreach(Button myButton in CreatStartbuttonsArray("board1")) { //Creates the buttons 1 , 2 , 3 etc... & A , B , C etc... for Board1
                this.Controls.Add(myButton);
            }
            foreach(Button myButton in CreatStartbuttonsArray("board2")) { //Creates the buttons 1 , 2 , 3 etc... & A , B , C etc... for Board2
                this.Controls.Add(myButton);
            }
        }
        public void codeForMyButton(object sender, EventArgs e) { //This code is added to every button in Board1
            foreach (Button myButton in Board1.allButtons) {
                if (sender.Equals(myButton)) {
                    if (myButton.Tag.ToString() == "notPressed" && itsPlayersTurn) {
                        itsPlayersTurn = false;
                        if (myButton.Name == "sea") {
                            myButton.Text = "-";
                            myButton.ForeColor = Color.LimeGreen;                      
                        } else {
                            myButton.Text = "X";
                            myButton.ForeColor = Color.Red;
                            CheckIfComputerShipDestroyed(myButton.Name);
                        }
                        myButton.Tag = "pressed";
                        CheckIfGameOver();
                        break;
                    }                
                }
            }
        }
        public static Button[] CreatStartbuttonsArray(string whatBoard) {
            //locationX and locationY change depending on which board is being created, and they represent their coordinates
            int locationX = 0;
            int locationY = 80;
            int extraX = 0;
            if (whatBoard == "board1") {
                locationX = 80;
            } else if (whatBoard == "board2") {
                locationX = 600;
                extraX = 520;
            }
            for (int i = 0; i < 10; i++) {  //Creates the HORIZONTAL start buttons ex. 1 , 2 , 3 , 4...
                 Button myButton = new Button();
                //The following lines are for the technical part of the button
                 myButton.Location = new Point(40 * i + 120 + extraX, locationY);
                 myButton.Size = new Size(40, 40);
                 myButton.Text = (i + 1).ToString();
                 myButton.Enabled = false;
                //The following lines are for the aesthetic/visuals of the button
                 myButton.FlatStyle = FlatStyle.Flat;
                 myButton.FlatAppearance.BorderSize = 0;
                 myButton.BackColor = Color.Blue;
                 myButton.ForeColor = Color.DarkBlue;
                 myButton.Font = new Font(myButton.Font.FontFamily, 10, FontStyle.Bold);
                 if (whatBoard == "board1") {
                    Board1.starterButtons[i] = myButton;
                 } else if (whatBoard == "board2") {
                    Board2.starterButtons[i] = myButton;
                 }
            }
            for (int i = 0; i < 10; i++) { //Creates the VERTICAL start buttons ex. A , B , C , D...
                 Button myButton = new Button();
                //The following lines are for the technical part of the button
                 myButton.Location = new Point(locationX, 40 * i + locationY + 40);
                 myButton.Size = new Size(40, 40);
                 myButton.Text = FromNumberToLetter(i);
                 myButton.Enabled = false;
                //The following lines are for the aesthetic/visuals of the button
                 myButton.FlatStyle = FlatStyle.Flat;
                 myButton.FlatAppearance.BorderSize = 0;
                 myButton.BackColor = Color.Blue;
                 myButton.ForeColor = Color.DarkBlue;
                 myButton.Font = new Font(myButton.Font.FontFamily, 10, FontStyle.Bold);
                 if (whatBoard == "board1") {
                    Board1.starterButtons[i + 10] = myButton;
                 } else if (whatBoard == "board2") {
                    Board2.starterButtons[i + 10] = myButton;
                 }
            }
            if (whatBoard == "board1") {
                return Board1.starterButtons;
            } else if (whatBoard == "board2") {
                return Board2.starterButtons;
            } else {
                return null;
            }
            
        }
        private static String FromNumberToLetter(int num) {
            string buttonLetter;
            switch(num) {
                case 0:
                    buttonLetter = "A";
                    break;
                case 1:
                    buttonLetter = "B";
                    break;
                case 2:
                    buttonLetter = "C";
                    break;
                case 3:
                    buttonLetter = "D";
                    break;
                case 4:
                    buttonLetter = "E";
                    break;
                case 5:
                    buttonLetter = "F";
                    break;
                case 6:
                    buttonLetter = "G";
                    break;
                case 7:
                    buttonLetter = "H";
                    break;
                case 8:
                    buttonLetter = "I";
                    break;
                case 9:
                    buttonLetter = "J";
                    break;
                default:
                    buttonLetter = "";
                    break;
            }
            return buttonLetter;
        }
        private void GeneratePlayerShips() {
            Random rnd = new Random(DateTime.Now.Second);
            int randomX;
            int randomY;
            string shipDirection;
            //GENERATE SUBMARINE
            int randomForSubmarine = rnd.Next(2);
            shipDirection = randomForSubmarine == 0? "Horizontal" : "Vertical";
            if (shipDirection == "Horizontal") {
                randomX = rnd.Next(9);
                randomY = rnd.Next(10);
                for (int i = 0; i < 2; i++) {
                    Button myButton = Board2.allButtons[randomX + (randomY * 10) + i];
                    myButton.BackColor = Color.LightGray;
                    myButton.Name = "Submarine";
                }
            } else if (shipDirection == "Vertical") {
                randomX = rnd.Next(10);
                randomY = rnd.Next(9);
                for (int i = 0; i < 2; i++) {
                    Button myButton = Board2.allButtons[randomX + (randomY * 10) + (10 * i)];
                    myButton.BackColor = Color.LightGray;
                    myButton.Name = "Submarine";
                }
            }
            //GENERATE WARSHIP
            int randomForWarship = rnd.Next(2);
            shipDirection = randomForWarship == 0? "Horizontal" : "Vertical";
            if (shipDirection == "Horizontal") {
                //Checks if the there are other ships obscuring their way
                bool seaIsClear = true;
                do {
                    randomX = rnd.Next(8);
                    randomY = rnd.Next(10);
                    int i = 0;
                    do { 
                        seaIsClear = Board2.allButtons[randomX + (randomY * 10) + i].Name == "sea";
                        i++;
                    } while (seaIsClear && i < 3);
                } while (seaIsClear == false);
                //...
                for (int i = 0; i < 3; i++) {
                    Button myButton = Board2.allButtons[randomX + (randomY * 10) + i];
                    myButton.BackColor = Color.DarkSlateGray;
                    myButton.Name = "Warship";
                }
            } else if (shipDirection == "Vertical") {
                //Checks if the there are other ships obscuring their way
                bool seaIsClear = true;
                do {
                    randomX = rnd.Next(10);
                    randomY = rnd.Next(8);
                    int i = 0;
                    do { 
                        seaIsClear = Board2.allButtons[randomX + (randomY * 10) + (10 * i)].Name == "sea";
                        i++;
                    } while (seaIsClear && i < 3);
                } while (seaIsClear == false);
                //...
                for (int i = 0; i < 3; i++) {
                    Button myButton = Board2.allButtons[randomX + (randomY * 10) + (10 * i)];
                    myButton.BackColor = Color.DarkSlateGray;
                    myButton.Name = "Warship";
                }
            }
            //GENERATE DESTROYER
            int randomForDestroyer = rnd.Next(2);
            shipDirection = randomForDestroyer == 0? "Horizontal" : "Vertical";
            if (shipDirection == "Horizontal") {
                //Checks if the there are other ships obscuring their way
                bool seaIsClear = true;
                do {
                    randomX = rnd.Next(7);
                    randomY = rnd.Next(10);
                    int i = 0;
                    do { 
                        seaIsClear = Board2.allButtons[randomX + (randomY * 10) + i].Name == "sea";
                        i++;
                    } while (seaIsClear && i < 4);
                } while (seaIsClear == false);
                //...
                for (int i = 0; i < 4; i++) {
                    Button myButton = Board2.allButtons[randomX + (randomY * 10) + i];
                    myButton.BackColor = Color.DimGray;
                    myButton.Name = "Destroyer";
                }
            } else if (shipDirection == "Vertical") {
                //Checks if the there are other ships obscuring their way
                bool seaIsClear = true;
                do {
                    randomX = rnd.Next(10);
                    randomY = rnd.Next(7);
                    int i = 0;
                    do { 
                        seaIsClear = Board2.allButtons[randomX + (randomY * 10) + (10 * i)].Name == "sea";
                        i++;
                    } while (seaIsClear && i < 4);
                } while (seaIsClear == false);
                //...
                for (int i = 0; i < 4; i++) {
                    Button myButton = Board2.allButtons[randomX + (randomY * 10) + (10 * i)];
                    myButton.BackColor = Color.DimGray;
                    myButton.Name = "Destroyer";
                }
            }
            //GENERATE AIRCRAFT CARRIER
            int randomForAircraftcarrier = rnd.Next(2);
            shipDirection = randomForAircraftcarrier == 0? "Horizontal" : "Vertical";
            if (shipDirection == "Horizontal") {
                //Checks if the there are other ships obscuring their way
                bool seaIsClear = true;
                do {
                    randomX = rnd.Next(6);
                    randomY = rnd.Next(10);
                    int i = 0;
                    do { 
                        seaIsClear = Board2.allButtons[randomX + (randomY * 10) + i].Name == "sea";
                        i++;
                    } while (seaIsClear && i < 5);
                } while (seaIsClear == false);
                //...
                for (int i = 0; i < 5; i++) {
                    Button myButton = Board2.allButtons[randomX + (randomY * 10) + i];
                    myButton.BackColor = Color.Gray;
                    myButton.Name = "Aircraftcarrier";
                }
            } else if (shipDirection == "Vertical") {
                //Checks if the there are other ships obscuring their way
                bool seaIsClear = true;
                do {
                    randomX = rnd.Next(10);
                    randomY = rnd.Next(6);
                    int i = 0;
                    do { 
                        seaIsClear = Board2.allButtons[randomX + (randomY * 10) + (10 * i)].Name == "sea";
                        i++;
                    } while (seaIsClear && i < 5);
                } while (seaIsClear == false);
                //...
                for (int i = 0; i < 5; i++) {
                    Button myButton = Board2.allButtons[randomX + (randomY * 10) + (10 * i)];
                    myButton.BackColor = Color.Gray;
                    myButton.Name = "Aircraftcarrier";
                }
            }
        }
        private void GenerateComputerShips() {
            Random rnd = new Random(DateTime.Now.Millisecond);
            int randomX;
            int randomY;
            string shipDirection;
            //GENERATE SUBMARINE
            int randomForSubmarine = rnd.Next(2);
            shipDirection = randomForSubmarine == 0? "Horizontal" : "Vertical";
            if (shipDirection == "Horizontal") {
                randomX = rnd.Next(9);
                randomY = rnd.Next(10);
                for (int i = 0; i < 2; i++) {
                    Button myButton = Board1.allButtons[randomX + (randomY * 10) + i];
                    //myButton.BackColor = Color.LightGray;
                    myButton.Name = "Submarine";
                }
            } else if (shipDirection == "Vertical") {
                randomX = rnd.Next(10);
                randomY = rnd.Next(9);
                for (int i = 0; i < 2; i++) {
                    Button myButton = Board1.allButtons[randomX + (randomY * 10) + (10 * i)];
                    //myButton.BackColor = Color.LightGray;
                    myButton.Name = "Submarine";
                }
            }
            //GENERATE WARSHIP
            int randomForWarship = rnd.Next(2);
            shipDirection = randomForWarship == 0? "Horizontal" : "Vertical";
            if (shipDirection == "Horizontal") {
                //Checks if the there are other ships obscuring their way
                bool seaIsClear = true;
                do {
                    randomX = rnd.Next(8);
                    randomY = rnd.Next(10);
                    int i = 0;
                    do { 
                        seaIsClear = Board1.allButtons[randomX + (randomY * 10) + i].Name == "sea";
                        i++;
                    } while (seaIsClear && i < 3);
                } while (seaIsClear == false);
                //...
                for (int i = 0; i < 3; i++) {
                    Button myButton = Board1.allButtons[randomX + (randomY * 10) + i];
                    //myButton.BackColor = Color.DarkSlateGray;
                    myButton.Name = "Warship";
                }
            } else if (shipDirection == "Vertical") {
                //Checks if the there are other ships obscuring their way
                bool seaIsClear = true;
                do {
                    randomX = rnd.Next(10);
                    randomY = rnd.Next(8);
                    int i = 0;
                    do { 
                        seaIsClear = Board1.allButtons[randomX + (randomY * 10) + (10 * i)].Name == "sea";
                        i++;
                    } while (seaIsClear && i < 3);
                } while (seaIsClear == false);
                //...
                for (int i = 0; i < 3; i++) {
                    Button myButton = Board1.allButtons[randomX + (randomY * 10) + (10 * i)];
                   //myButton.BackColor = Color.DarkSlateGray;
                    myButton.Name = "Warship";
                }
            }
            //GENERATE DESTROYER
            int randomForDestroyer = rnd.Next(2);
            shipDirection = randomForDestroyer == 0? "Horizontal" : "Vertical";
            if (shipDirection == "Horizontal") {
                //Checks if the there are other ships obscuring their way
                bool seaIsClear = true;
                do {
                    randomX = rnd.Next(7);
                    randomY = rnd.Next(10);
                    int i = 0;
                    do { 
                        seaIsClear = Board1.allButtons[randomX + (randomY * 10) + i].Name == "sea";
                        i++;
                    } while (seaIsClear && i < 4);
                } while (seaIsClear == false);
                //...
                for (int i = 0; i < 4; i++) {
                    Button myButton = Board1.allButtons[randomX + (randomY * 10) + i];
                   // myButton.BackColor = Color.DimGray;
                    myButton.Name = "Destroyer";
                }
            } else if (shipDirection == "Vertical") {
                //Checks if the there are other ships obscuring their way
                bool seaIsClear = true;
                do {
                    randomX = rnd.Next(10);
                    randomY = rnd.Next(7);
                    int i = 0;
                    do { 
                        seaIsClear = Board1.allButtons[randomX + (randomY * 10) + (10 * i)].Name == "sea";
                        i++;
                    } while (seaIsClear && i < 4);
                } while (seaIsClear == false);
                //...
                for (int i = 0; i < 4; i++) {
                    Button myButton = Board1.allButtons[randomX + (randomY * 10) + (10 * i)];
                    //myButton.BackColor = Color.DimGray;
                    myButton.Name = "Destroyer";
                }
            }
            //GENERATE AIRCRAFT CARRIER
            int randomForAircraftcarrier = rnd.Next(2);
            shipDirection = randomForAircraftcarrier == 0? "Horizontal" : "Vertical";
            if (shipDirection == "Horizontal") {
                //Checks if the there are other ships obscuring their way
                bool seaIsClear = true;
                do {
                    randomX = rnd.Next(6);
                    randomY = rnd.Next(10);
                    int i = 0;
                    do { 
                        seaIsClear = Board1.allButtons[randomX + (randomY * 10) + i].Name == "sea";
                        i++;
                    } while (seaIsClear && i < 5);
                } while (seaIsClear == false);
                //...
                for (int i = 0; i < 5; i++) {
                    Button myButton = Board1.allButtons[randomX + (randomY * 10) + i];
                   // myButton.BackColor = Color.Gray;
                    myButton.Name = "Aircraftcarrier";
                }
            } else if (shipDirection == "Vertical") {
                //Checks if the there are other ships obscuring their way
                bool seaIsClear = true;
                do {
                    randomX = rnd.Next(10);
                    randomY = rnd.Next(6);
                    int i = 0;
                    do { 
                        seaIsClear = Board1.allButtons[randomX + (randomY * 10) + (10 * i)].Name == "sea";
                        i++;
                    } while (seaIsClear && i < 5);
                } while (seaIsClear == false);
                //...
                for (int i = 0; i < 5; i++) {
                    Button myButton = Board1.allButtons[randomX + (randomY * 10) + (10 * i)];
                    //myButton.BackColor = Color.Gray;
                    myButton.Name = "Aircraftcarrier";
                }
            }

        }
        private void CheckIfComputerShipDestroyed(string shipName) {
            switch(shipName) {
                case "Submarine":
                    computerSubmarineHP--;
                    if (computerSubmarineHP == 0) {
                        MessageBox.Show("Το αντίπαλο υποβρύχιο βυθίστικε!", "Επιτυχία!");
                        computerShipRemaining--;
                    }
                    break;
                case "Warship":
                    computerWarshipHP--;
                    if (computerWarshipHP == 0) {
                        MessageBox.Show("Το αντίπαλο Πολεμικό βυθίστικε!", "Επιτυχία!");
                        computerShipRemaining--;
                    }
                    break;
                case "Destroyer":
                    computerDestroyerHP--;
                    if (computerDestroyerHP == 0) {
                        MessageBox.Show("Το αντίπαλο Αντιτορπλικό βυθίστικε!", "Επιτυχία!");
                        computerShipRemaining--;
                    }
                    break;
                case "Aircraftcarrier":
                    computerAircraftcarrierHP--;
                    if (computerAircraftcarrierHP == 0) {
                        MessageBox.Show("Το αντίπαλο Αεροπλανοφόρο βυθίστικε!", "Επιτυχία!");
                        computerShipRemaining--;
                    }
                    break;
            }
        }
        private void ComputersTurn() {
            Random rnd = new Random(DateTime.Now.Millisecond);
            bool foundTarget = false;
            int tries = 0;
            do {
                int randomX = rnd.Next(10);
                int randomY = rnd.Next(10);
                Button myButton = Board2.allButtons[randomX + (randomY * 10)]; ; //Selects a random button
                if (myButton.Tag.ToString() == "notHit") {                       //Makes sure it has not been already hit
                    tries++;
                    if (myButton.Name == "sea") {                                //Checks if the button is empty or if there is a ship
                        if (tries > 2) {
                            myButton.Text = "·";
                            myButton.ForeColor = Color.Black;
                            myButton.Tag = "hit";
                            foundTarget = true;
                        }
                    } else {
                        myButton.Text = "X";
                        myButton.ForeColor = Color.Red;
                        myButton.Tag = "hit";
                        foundTarget = true;
                        CheckIfPlayerShipDestroyed(myButton.Name);
                    }
                }
            } while (foundTarget == false);
            itsPlayersTurn = true;
        }
        private void CheckIfPlayerShipDestroyed(string shipName) {
            switch(shipName) {
                case "Submarine":
                    playerSubmarineHP--;
                    if (playerSubmarineHP == 0) {
                        MessageBox.Show("Βυθίστηκε το υποβρύχιο μου!", "Προσοχή!");
                        playerShipRemaining--;
                    }
                    break;
                case "Warship":
                    playerWarshipHP--;
                    if (playerWarshipHP == 0) {
                        MessageBox.Show("Βυθίστηκε το Πολεμικό μου!", "Προσοχή!");
                        playerShipRemaining--;
                    }
                    break;
                case "Destroyer":
                    playerDestroyerHP--;
                    if (playerDestroyerHP == 0) {
                        MessageBox.Show("Βυθίστηκε το Αντιτορπλικό μου!", "Προσοχή!");
                        playerShipRemaining--;
                    }
                    break;
                case "Aircraftcarrier":
                    playerAircraftcarrierHP--;
                    if (playerAircraftcarrierHP == 0) {
                        MessageBox.Show("Βυθίστηκε το Αεροπλανοφόρο μου!", "Προσοχή!");
                        playerShipRemaining--;
                    }
                    break;
            }
        }
        private void CheckIfGameOver() {
            if (computerShipRemaining == 0) {
                wins++;
                timer1.Stop();
                updateScoreboard();
                var result = (dynamic)null;
                if (wins + loses == 1) {
                    result = MessageBox.Show($"Συγχαρητήρια βύθισες όλα τα αντίπαλα πλοία! " +
                    $"{Environment.NewLine}Προσπάθειες: {turn}" +
                    $"{Environment.NewLine}Χρόνος: {time / 10} Δευτερόλεπτα" +
                    $"{Environment.NewLine}{Environment.NewLine}Θα ήθελες να ξαναπαίξεις",
                    "Νίκη!",
                    MessageBoxButtons.YesNo);
                } else {
                    result = MessageBox.Show($"Συγχαρητήρια βύθισες όλα τα αντίπαλα πλοία! " +
                    $"{Environment.NewLine}Προσπάθειες: {turn}" +
                    $"{Environment.NewLine}Χρόνος: {time / 10} Δευτερόλεπτα" +
                    $"{Environment.NewLine}Νίκες: {wins}" +
                    $"{Environment.NewLine}Ήττες: {loses}" +
                    $"{Environment.NewLine}{Environment.NewLine}Θα ήθελες να ξαναπαίξεις",
                    "Νίκη!",
                    MessageBoxButtons.YesNo);
                }
                if (result == DialogResult.No) {
                    Application.ExitThread();
                } else if (result == DialogResult.Yes) {
                    restartGame();
                }
            } else {
                ComputersTurn();
            }
            if (playerShipRemaining == 0) {
                loses++;
                timer1.Stop();
                updateScoreboard();
                var result = (dynamic)null;
                if (wins + loses == 1) {
                    result = MessageBox.Show($"Ο εχθρός βύθισε όλα τα πλοία σου!" +
                    $"{Environment.NewLine}Προσπάθειες: {turn}" +
                    $"{Environment.NewLine}Χρόνος: {time / 10} Δευτερόλεπτα" +
                    $"{Environment.NewLine}{Environment.NewLine}Θα ήθελες να ξαναπαίξεις",
                    "Ήττα!",
                    MessageBoxButtons.YesNo);
                } else {
                    result = MessageBox.Show($"Ο εχθρός βύθισε όλα τα πλοία σου!" +
                    $"{Environment.NewLine}Προσπάθειες: {turn}" +
                    $"{Environment.NewLine}Χρόνος: {time / 10} Δευτερόλεπτα" +
                    $"{Environment.NewLine}Νίκες: {wins}" +
                    $"{Environment.NewLine}Ήττες: {loses}" +
                    $"{Environment.NewLine}{Environment.NewLine}Θα ήθελες να ξαναπαίξεις",
                    "Ήττα!",
                    MessageBoxButtons.YesNo);
                }
                if (result == DialogResult.No) {
                Application.ExitThread();
                } else if (result == DialogResult.Yes) {
                    restartGame();
                }
            }
            turn++;
        } 
        private void timer1_Tick(object sender, EventArgs e) {
            time++;
        }
        private void restartGame() {

            computerSubmarineHP= 2;
            computerWarshipHP = 3;
            computerDestroyerHP = 4;
            computerAircraftcarrierHP = 5;
            computerShipRemaining = 4;

            playerSubmarineHP= 2;
            playerWarshipHP = 3;
            playerDestroyerHP = 4;
            playerAircraftcarrierHP = 5;
            playerShipRemaining = 4;

            itsPlayersTurn = true;
            turn = 1;
            time = 0;

            Board1 board = new Board1();
            board.ClearBoard();
            Board2.ClearBoard();
            GeneratePlayerShips();
            GenerateComputerShips();
            timer1.Start();
        }

        private void updateScoreboard() {
            Result.Text = computerShipRemaining == 0? "Vicotry" : "Defeat";
            TimeTextBox.Text = (time / 10).ToString() + " Seconds";
            Rounds.Text = turn.ToString();
            tableBindingSource.EndEdit();
            tableBindingSource.AddNew();
            tableTableAdapter.Update(database1DataSet);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void MakeButton1Beatiful()
        {
            button1.BackColor = Color.Orange;
            button1.ForeColor = Color.Black;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 3;
            button1.Font = new Font(button1.Font.FontFamily, 8, FontStyle.Bold);
            button1.Size = new System.Drawing.Size(50, 30);
            button1.Location = new System.Drawing.Point(1010, 10);
        }
    }
}
