using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingApp
{
    public partial class Form1 : Form
    {
        #region Private members
        
        // Drawing window
        private Graphics g;
        // Mouse location
        private int x = -1;
        private int y = -1;
        // Variable to determine wheter mouse is moving
        private bool isMoving = false;
        // Drawing tool
        private Pen pen;

        #endregion

        public Form1()
        {
            InitializeComponent();
            // Sets panel as a drawing window
            g = panel1.CreateGraphics();
            // Clears spaces and aliasing from drawing tool
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            // Creates and then sets default pen color to black and width to 5px
            pen = new Pen(Color.Black, 5);
            // Rounds drawing start and end points
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        { 
            // Sets pen color to what color picture box you clicked
            PictureBox p = (PictureBox) sender;
            pen.Color = p.BackColor;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Error
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            // If you click and hold your mouse, resets default mouse location to location your mouse is at
            isMoving = true;
            x = e.X;
            y = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            // If you move your mouse, starts drawing a line and resetting location of your mouse
            if (isMoving && x != -1 && y != -1)
            {
                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            // If you stop holding mouse button, sets default mouse location
            isMoving = false;
            x = -1;
            y = -1;
        }

        private void pictureBoxClear_Click(object sender, EventArgs e)
        {
            // Clears drawing panel
            g.Clear(Color.White);
        }
    }
}
