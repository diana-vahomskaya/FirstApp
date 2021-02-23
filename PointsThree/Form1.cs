using System;
using System.Drawing;
using System.Windows.Forms;

namespace PointsThree
{
    public partial class Form1 : Form
    {
        Random rand;
        Graphics g;

        double x1 = 0;
        double x2 = 0;
        double x3 = 0;

        double y1 = 0;
        double y2 = 0;
        double y3 = 0;

        int width;
        int height;

        public Form1()
        {
            InitializeComponent();
        }

        public void BackGround()
        {
            width = pictureBox1.Width;
            height = pictureBox1.Height;

            pictureBox1.Image = new Bitmap(width, height);
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.RosyBrown);

            // Create rectangle.
            Rectangle rect = new Rectangle(100, 100, width - 200, height - 200);

            g.FillRectangle(blueBrush, rect);
        }

        public void DrawTriangle(Point point1, Point point2, Point point3)
        {
            Pen vertexPen = new Pen(Color.White, 2);

            g.DrawLine(vertexPen, point1, point2);
            g.DrawLine(vertexPen, point2, point3);
            g.DrawLine(vertexPen, point3, point1);

        }

        public void DrawCircleInTriangle(Point point1, Point point2, Point point3)
        {
            Pen vertexPen = new Pen(Color.MistyRose, 2);

            double line_a = Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
            double line_b = Math.Sqrt(Math.Pow(point3.X - point2.X, 2) + Math.Pow(point3.Y - point2.Y, 2));
            double line_c = Math.Sqrt(Math.Pow(point1.X - point3.X, 2) + Math.Pow(point1.Y - point3.Y, 2));

            double polyperimetr = (line_a + line_b + line_c) / 2;

            double radius = Math.Sqrt(((polyperimetr - line_a) * (polyperimetr - line_b) * (polyperimetr - line_c)) / polyperimetr);

            double w1 = (point1.X * line_b + point2.X * line_c + point3.X * line_a) / (line_a + line_b + line_c);
            double w2 = (point1.Y * line_b + point2.Y * line_c + point3.Y * line_a) / (line_a + line_b + line_c);

            g.DrawRectangle(vertexPen, (float)(w1 ), (float)(w2 ), 2, 2); 
            g.DrawEllipse(vertexPen, (float)(w1 - radius), (float)(w2 - radius), (float)(2 * radius), (float)(2 * radius));

        }
        public void DrawCircleOutTriangle(Point point1, Point point2, Point point3)
        {
            Pen vertexPen = new Pen(Color.Bisque, 2);

            double w1 = ((point2.X * point2.X - point1.X * point1.X + point2.Y * point2.Y - point1.Y * point1.Y) * (point3.Y - point1.Y) - (point3.X * point3.X - point1.X * point1.X + point3.Y * point3.Y - point1.Y * point1.Y) * (point2.Y - point1.Y)) / ((point2.X - point1.X) * (point3.Y - point1.Y) - (point3.X - point1.X) * (point2.Y - point1.Y)) / 2.0;
            double w2 = ((point3.X * point3.X - point1.X * point1.X + point3.Y * point3.Y - point1.Y * point1.Y) * (point2.X - point1.X) - (point2.X * point2.X - point1.X * point1.X + point2.Y * point2.Y - point1.Y * point1.Y) * (point3.X - point1.X)) / ((point2.X - point1.X) * (point3.Y - point1.Y) - (point3.X - point1.X) * (point2.Y - point1.Y)) / 2.0;
            double Rad = Math.Sqrt((w1 - point1.X) * (w1 - point1.X) + (w2 - point1.Y) * (w2 - point1.Y));

            g.DrawRectangle(vertexPen, (float)(w1), (float)(w2), 2, 2);
            g.DrawEllipse(vertexPen, (float)(w1 - Rad), (float)(w2 - Rad), (float)(2.0 * Rad), (float)(2.0 * Rad));
        }
        private void DRAW_Click(object sender, EventArgs e)
        {
            BackGround();

            rand = new Random();
            x1 = rand.Next(100, width - 200);
            y1 = rand.Next(100, height - 200);

            x2 = rand.Next(100, width - 200);
            y2 = rand.Next(100, height - 200);

            x3 = rand.Next(100, width - 200);
            y3 = rand.Next(100, height - 200);

            Point q1 = new Point((int)x1, (int)y1);
            Point q2 = new Point((int)x2, (int)y2);
            Point q3 = new Point((int)x3, (int)y3);

            DrawTriangle(q1, q2, q3);
            DrawCircleInTriangle(q1, q2, q3);
            DrawCircleOutTriangle(q1, q2, q3);
        }
    }
}
