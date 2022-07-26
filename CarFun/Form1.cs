using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrossyRoad
{
    public partial class Form1 : Form
    {
        public int i = 0;
        public string lightColorY = "red";
        public string lightColorX = "red";
        public string[] carsY = { "car1", "car2", "car3" };
        public string[] carsX = { "car4", "car5", "car6" };
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void lightTimer_Tick(object sender, EventArgs e) //This timer controls both lights
        {
            if (i < 10) {
                lightX.ImageLocation = "Pictures/redLight2.png";
                lightColorX = "red";
                i++;
            } else if (i < 20) {
                lightY.ImageLocation = "Pictures/greenLight.png";
                lightColorY = "green";
                i++;
            } else if (i < 25) {
                lightY.ImageLocation = "Pictures/yellowLight.png";
                lightColorY = "yellow";
                i++;
            } else if (i < 35) {
                lightY.ImageLocation = "Pictures/redLight.png";
                lightColorY = "red";
                i++;
            } else if (i < 45) {
                lightX.ImageLocation = "Pictures/greenLight2.png";
                lightColorX = "green";
                i++;
            } else if (i < 50) {
                lightY.ImageLocation = "Pictures/redLight.png";
                lightColorY = "red";
                lightX.ImageLocation = "Pictures/yellowLight2.png";
                lightColorX = "yellow";
                i++;
            } else {
                i = 0;
            }
        }
//-------------------------------------------------------VERTICAL CARS CODE----------------------------------------------------------//
        private void MoveCarY(PictureBox car) {
            if (CarShouldMoveY(car)) { 
                if (car.Location.Y > -80) {
                    car.Location = new Point(car.Location.X, car.Location.Y - 5);
                } else {
                    car.Location = new Point(car.Location.X, 700);
                    car.Location = new Point(car.Location.X, car.Location.Y - 5);
                }
            }
        }
        
        private void CheckCarLocationY(PictureBox car) {
            if(car.Location.Y == lightY.Location.Y - 5) { 
                string temp = carsY[0];
                carsY[0] = carsY[1];
                carsY[1] = carsY[2];
                carsY[2] = temp;
            }
        }

        private bool CarShouldMoveY(PictureBox car) { //Checks if the car should move depending on the color of the light, and its position relative to the other two cars
            bool shouldCarMove;
            if (lightColorY == "red") {
                if (car.Location.Y >= lightY.Location.Y) { 
                    int j = 0;
                    while (car.Name != carsY[j]) { //Checks what is the cars position inside carsY[], to determine how many many cars it should expect infornt of it
                        j++;
                    }
                    if (car.Location.Y <= lightY.Location.Y + 120 * j) { //ex. if j = 0, it means 0 cars are infont if it, so it stops exactly at the red light  
                        shouldCarMove = false;                           //ex. if j = 1, it means 1 car is infont if it, so it stops 120 * 1 = 120 earlier than the red light (100px is the height of every car)
                    } else {                                             //ex. if j = 2, it means 2 cars are infont if it, so it stops 240 pixels earlier than the red light
                        shouldCarMove = true;
                    }
                } else {
                    shouldCarMove = true;
                }
            } else {
                shouldCarMove = true;
            }
            return shouldCarMove;
        }
//-------------------------------------------------------HORIZONTAL CARS CODE----------------------------------------------------------//
        
        private void MoveCarX(PictureBox car) {
            if (CarShouldMoveX(car)) { 
                if (car.Location.X < 1000) {
                    car.Location = new Point(car.Location.X + 5, car.Location.Y);
                } else {
                    car.Location = new Point(0, car.Location.Y);
                    car.Location = new Point(car.Location.X + 5, car.Location.Y);
                }
            }
        }

         private void CheckCarLocationX(PictureBox car) {
            if(car.Location.X == lightX.Location.X + 5) { 
                string temp = carsX[0];
                carsX[0] = carsX[1];
                carsX[1] = carsX[2];
                carsX[2] = temp;
            }
        }
        
        private bool CarShouldMoveX(PictureBox car) { //Checks if the car should move depending on the color of the light, and its position relative to the other two cars
            bool shouldCarMove;
            if (lightColorX == "red") {
                if (car.Location.X <= lightX.Location.X) { 
                    int j = 0;
                    while (car.Name != carsX[j]) {
                        j++;
                    }
                    if (car.Location.X >= lightX.Location.X - 120 * j) { 
                        shouldCarMove = false;                          
                    } else {                                            
                        shouldCarMove = true;
                    }
                } else {
                    shouldCarMove = true;
                }
            } else {
                shouldCarMove = true;
            }
            return shouldCarMove;
        }
        
             
//-----------------------------------------------------------------------------------------------------------------------------------//       
        private void carTimer_Tick(object sender, EventArgs e) {
            foreach(string car in carsY) {
                PictureBox tempCar = getPictureBoxByName(car);
                MoveCarY(tempCar);
                CheckCarLocationY(tempCar);
            }
            foreach(string car in carsX) {
                PictureBox tempCar = getPictureBoxByName(car);
                MoveCarX(tempCar);
                CheckCarLocationX(tempCar);
            }
        }

        private void pictureBox1_Click_2(object sender, EventArgs e) {

        }

        private PictureBox getPictureBoxByName(string name) { //Turns string to PictureBox (stolen from: https://stackoverflow.com/questions/21926857/how-to-make-string-as-a-picturebox-name)
            foreach(object p in this.Controls ) {
                if( p.GetType() == typeof(PictureBox) )
                    if( ((PictureBox)p).Name == name )
                        return (PictureBox)p;
            }
            return new PictureBox(); //OR return null;
        }

        private void button1_Click(object sender, EventArgs e) {
            lightTimer.Enabled = true;
            carTimer.Enabled = true;
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }

        private void lightTick_Scroll(object sender, EventArgs e) {
            lightTimer.Interval = lightTick.Value != 0? lightTick.Value * 50 : 5; 

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void pictureBox1_Click_3(object sender, EventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {
            MessageBox.Show("Change the traffic lights tick speed using the slider to change how fast the traffic lights are changing!" + Environment.NewLine + "Also I didn't want to add a context menu strip because it was ugly");
        }
    }
}
