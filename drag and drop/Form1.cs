using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drag_and_drop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button newButton = new Button();
            newButton.Text = "New Button";
            newButton.Size = new System.Drawing.Size(75, 23); // knappstorleken
            newButton.Location = new System.Drawing.Point(400, 200); // vart den sätter ut knappen
            newButton.MouseDown += new MouseEventHandler(button_MouseDown);
            newButton.MouseMove += new MouseEventHandler(button_MouseMove);
            newButton.MouseUp += new MouseEventHandler(button_MouseUp);
            this.Controls.Add(newButton); // lägger till knappen
        }

        private bool isDragging = false;
        private Point lastLocation;

        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            lastLocation = e.Location;            
        }


        private void button_MouseMove(object sender, MouseEventArgs e) 
        {
            if (isDragging)
            {
                Button btn = sender as Button;
                btn.Left += e.X - lastLocation.X; // <-- nånting fel (probably för att picturebox och button delar samma lastlocation)
                btn.Top += e.Y - lastLocation.Y;
                // sätter knappens location till musens

                PictureBox picBox = new PictureBox();
                picBox.Left += e.X - lastLocation.X;
                picBox.Top += e.Y - lastLocation.Y;
            }
        }

        private void button_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            // om man släpper musen släpps knappen

            Button btn = sender as Button;
            PictureBox picBox = sender as PictureBox;
            if (sender is Button && btn.Bounds.IntersectsWith(trash.Bounds))
            {
                btn.Dispose();
            }
            else if (sender is PictureBox)
            {
                if (picBox.Bounds.IntersectsWith(trash.Bounds)) 
                {
                    picBox.Dispose();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Lägger till en picturebox
            PictureBox picBox = new PictureBox();
            picBox.Location = new System.Drawing.Point(400, 200);
            picBox.Size = new System.Drawing.Size(50, 50);
            picBox.BackColor = System.Drawing.Color.Black;
            picBox.MouseDown += new MouseEventHandler(button_MouseDown);
            picBox.MouseMove += new MouseEventHandler(button_MouseMove);
            picBox.MouseUp += new MouseEventHandler(button_MouseUp);
            this.Controls.Add(picBox);
        }
    }
}
