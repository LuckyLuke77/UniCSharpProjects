
namespace CrossyRoad
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lightTimer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.carTimer = new System.Windows.Forms.Timer(this.components);
            this.lightTick = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.car6 = new System.Windows.Forms.PictureBox();
            this.car5 = new System.Windows.Forms.PictureBox();
            this.lightX = new System.Windows.Forms.PictureBox();
            this.car4 = new System.Windows.Forms.PictureBox();
            this.car3 = new System.Windows.Forms.PictureBox();
            this.car2 = new System.Windows.Forms.PictureBox();
            this.car1 = new System.Windows.Forms.PictureBox();
            this.lightY = new System.Windows.Forms.PictureBox();
            this.CrossRoad = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lightTick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.car6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.car5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.car4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.car3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.car2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.car1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CrossRoad)).BeginInit();
            this.SuspendLayout();
            // 
            // lightTimer
            // 
            this.lightTimer.Interval = 50;
            this.lightTimer.Tick += new System.EventHandler(this.lightTimer_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.button1.Location = new System.Drawing.Point(781, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 71);
            this.button1.TabIndex = 6;
            this.button1.Text = "Start Simulation";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // carTimer
            // 
            this.carTimer.Interval = 20;
            this.carTimer.Tick += new System.EventHandler(this.carTimer_Tick);
            // 
            // lightTick
            // 
            this.lightTick.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lightTick.Location = new System.Drawing.Point(748, 158);
            this.lightTick.Name = "lightTick";
            this.lightTick.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lightTick.Size = new System.Drawing.Size(194, 45);
            this.lightTick.TabIndex = 9;
            this.lightTick.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.lightTick.Value = 1;
            this.lightTick.Scroll += new System.EventHandler(this.lightTick_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(177)))), ((int)(((byte)(76)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(701, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Slow";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(177)))), ((int)(((byte)(76)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(948, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Fast";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(177)))), ((int)(((byte)(76)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(768, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Traffic light\'s Tick Speed";
            // 
            // car6
            // 
            this.car6.Image = global::CrossyRoad.Properties.Resources.car6;
            this.car6.Location = new System.Drawing.Point(220, 271);
            this.car6.Name = "car6";
            this.car6.Size = new System.Drawing.Size(100, 50);
            this.car6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.car6.TabIndex = 14;
            this.car6.TabStop = false;
            // 
            // car5
            // 
            this.car5.Image = global::CrossyRoad.Properties.Resources.car5;
            this.car5.Location = new System.Drawing.Point(340, 271);
            this.car5.Name = "car5";
            this.car5.Size = new System.Drawing.Size(100, 50);
            this.car5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.car5.TabIndex = 13;
            this.car5.TabStop = false;
            // 
            // lightX
            // 
            this.lightX.Image = global::CrossyRoad.Properties.Resources.redLight2;
            this.lightX.Location = new System.Drawing.Point(460, 340);
            this.lightX.Name = "lightX";
            this.lightX.Size = new System.Drawing.Size(100, 50);
            this.lightX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lightX.TabIndex = 8;
            this.lightX.TabStop = false;
            // 
            // car4
            // 
            this.car4.Image = global::CrossyRoad.Properties.Resources.car4;
            this.car4.Location = new System.Drawing.Point(460, 271);
            this.car4.Name = "car4";
            this.car4.Size = new System.Drawing.Size(100, 50);
            this.car4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.car4.TabIndex = 7;
            this.car4.TabStop = false;
            // 
            // car3
            // 
            this.car3.Image = global::CrossyRoad.Properties.Resources.car3;
            this.car3.Location = new System.Drawing.Point(590, 580);
            this.car3.Name = "car3";
            this.car3.Size = new System.Drawing.Size(50, 100);
            this.car3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.car3.TabIndex = 5;
            this.car3.TabStop = false;
            // 
            // car2
            // 
            this.car2.Image = global::CrossyRoad.Properties.Resources.car2;
            this.car2.Location = new System.Drawing.Point(590, 460);
            this.car2.Name = "car2";
            this.car2.Size = new System.Drawing.Size(50, 100);
            this.car2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.car2.TabIndex = 3;
            this.car2.TabStop = false;
            // 
            // car1
            // 
            this.car1.Image = global::CrossyRoad.Properties.Resources.car1;
            this.car1.Location = new System.Drawing.Point(590, 340);
            this.car1.Name = "car1";
            this.car1.Size = new System.Drawing.Size(50, 100);
            this.car1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.car1.TabIndex = 2;
            this.car1.TabStop = false;
            this.car1.Click += new System.EventHandler(this.pictureBox1_Click_2);
            // 
            // lightY
            // 
            this.lightY.Image = global::CrossyRoad.Properties.Resources.redLight;
            this.lightY.InitialImage = global::CrossyRoad.Properties.Resources.redLight;
            this.lightY.Location = new System.Drawing.Point(664, 340);
            this.lightY.Name = "lightY";
            this.lightY.Size = new System.Drawing.Size(50, 100);
            this.lightY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lightY.TabIndex = 1;
            this.lightY.TabStop = false;
            this.lightY.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // CrossRoad
            // 
            this.CrossRoad.Image = global::CrossyRoad.Properties.Resources.CrossRoad;
            this.CrossRoad.InitialImage = global::CrossyRoad.Properties.Resources.CrossRoad;
            this.CrossRoad.Location = new System.Drawing.Point(-2, -8);
            this.CrossRoad.Name = "CrossRoad";
            this.CrossRoad.Size = new System.Drawing.Size(1015, 740);
            this.CrossRoad.TabIndex = 0;
            this.CrossRoad.TabStop = false;
            this.CrossRoad.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Help";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.car6);
            this.Controls.Add(this.car5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lightTick);
            this.Controls.Add(this.lightX);
            this.Controls.Add(this.car4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.car3);
            this.Controls.Add(this.car2);
            this.Controls.Add(this.car1);
            this.Controls.Add(this.lightY);
            this.Controls.Add(this.CrossRoad);
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "Form1";
            this.Text = "Crossy Road";
            ((System.ComponentModel.ISupportInitialize)(this.lightTick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.car6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.car5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.car4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.car3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.car2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.car1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CrossRoad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CrossRoad;
        private System.Windows.Forms.PictureBox lightY;
        private System.Windows.Forms.Timer lightTimer;
        private System.Windows.Forms.PictureBox car1;
        private System.Windows.Forms.PictureBox car2;
        private System.Windows.Forms.PictureBox car3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox car4;
        private System.Windows.Forms.PictureBox lightX;
        private System.Windows.Forms.Timer carTimer;
        private System.Windows.Forms.TrackBar lightTick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox car5;
        private System.Windows.Forms.PictureBox car6;
        private System.Windows.Forms.Button button2;
    }
}

