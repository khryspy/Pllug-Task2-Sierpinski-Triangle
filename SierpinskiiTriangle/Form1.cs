using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sierpinski
{
    public partial class Form1 : Form
    {
        private Bitmap Bitmap;

        private Graphics Graphics;

        private int Step;

        public Form1()
        {
            InitializeComponent();


        }

        private void TriangleButton_Click(object sender, EventArgs e)
        {
            Step = Convert.ToInt32(textBox.Text);
            Bitmap = new Bitmap(PictureBox.Width, PictureBox.Height);
            Graphics = Graphics.FromImage(Bitmap);

            PointF LeftPoint = new PointF(0, Bitmap.Height);
            PointF RightPoint = new PointF(Bitmap.Width, Bitmap.Height);
            PointF TopPoint = new PointF(Bitmap.Width / 2f, 0);

            BuildTriangle(Step, TopPoint, LeftPoint, RightPoint);

            PictureBox.BackgroundImage = Bitmap;
        }



        private void BuildTriangle(int Step, PointF TopPoint, PointF LeftPoint, PointF RightPoint)
        {
            if (Step == 0)
            {
                PointF[] triangle = new PointF[3] { TopPoint, LeftPoint, RightPoint };
                Graphics.FillPolygon(Brushes.Red, triangle);

            }

            if (Step > 0)
            {

                PointF MiddleLeft = new PointF((TopPoint.X + LeftPoint.X) / 2f, (TopPoint.Y + LeftPoint.Y) / 2f);
                PointF MiddleRight = new PointF((TopPoint.X + RightPoint.X) / 2f, (TopPoint.Y + RightPoint.Y) / 2f);
                PointF MiddleTop = new PointF((RightPoint.X + LeftPoint.X) / 2f, (RightPoint.Y + LeftPoint.Y) / 2f);

                BuildTriangle(Step - 1, TopPoint, MiddleLeft, MiddleRight);
                BuildTriangle(Step - 1, MiddleLeft, LeftPoint, MiddleTop);
                BuildTriangle(Step - 1, MiddleRight, MiddleTop, RightPoint);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }


    }
}