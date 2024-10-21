namespace _2_Lines
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Random random = new Random();
            Point line1Start = new Point(random.Next(0, ClientSize.Width), random.Next(0, ClientSize.Height));
            Point line1End = new Point(random.Next(0, ClientSize.Width), random.Next(0, ClientSize.Height));
            Point line2Start = new Point(random.Next(0, ClientSize.Width), random.Next(0, ClientSize.Height));
            Point line2End = new Point(random.Next(0, ClientSize.Width), random.Next(0, ClientSize.Height));
            e.Graphics.DrawLine(Pens.Blue, line1Start, line1End);
            e.Graphics.DrawLine(Pens.Red, line2Start, line2End);
            bool intersection = DoIntersect(line1Start, line1End, line2Start, line2End);
            if (intersection)
            {
                MessageBox.Show("Линии пересекаються!");
            }
            else
            {
                MessageBox.Show("Линии не пересекаются!");
            }
        }
        private bool DoIntersect(Point p1, Point q1, Point p2, Point q2)
        {
            int o1 = Orientation(p1, q1, p2);
            int o2 = Orientation(p1, q1, q2);
            int o3 = Orientation(p2, q2, p1);
            int o4 = Orientation(p2, q2, q1);
            if (o1 != o2 && o3 != o4)
            {
                return true;
            }
            return false;
        }
        private int Orientation(Point p, Point q, Point r)
        {
            int val = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);
            if (val == 0)
            {
                return 0;
            }
            return (val > 0) ? 1 : 2;
        }
    }
}