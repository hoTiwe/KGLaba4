using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace KGLaba4
{
    public partial class Form1 : Form
    {
        Image image;
        bool needInit = true;
        Bitmap bitmap;
        Graphics graphics;
        int currentLayout = 0;
        int scale = 5;

        public Form1()
        {
            InitializeComponent();
            image = new Image(new Layout(Color.Red, Color.Black, new List<Point> { new Point(0, 0), new Point(40, 0), new Point(40, 40), new Point(0, 40) }));

            Layout layout1 = new Layout(Color.Red, Color.Black, new List<Point> { new Point(1, 1), new Point(21, 1), new Point(10, 20) });
            image.Add(layout1);

            Layout layout2 = new Layout(Color.Green, Color.Black, new List<Point> { new Point(1, 20), new Point(21, 20), new Point(10, 1) });
            image.Add(layout2);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (needInit)
            {
                bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                graphics = Graphics.FromImage(bitmap);
                needInit = false;
            }
        }

        public void paintLayout(Layout layout)
        {
            int avgX = 0; int avgY = 0;
            List<Point> outline = new List<Point>();
            for (int i = 0; i < layout.vertexsVisable.Count; i++)
            {
                var start = layout.vertexsVisable[i];
                avgX += start.X;
                avgY += start.Y;

                var end = layout.vertexsVisable[(i + 1) % layout.vertexsVisable.Count];
                outline.AddRange(GetLineBrezenthema(start.X, start.Y, end.X, end.Y));
            }
            avgX /= layout.vertexsVisable.Count;
            avgY /= layout.vertexsVisable.Count;

            List<Point> inner = FillInner(outline, new Point(avgX, avgY));

            for (int i = 0; i < outline.Count(); i++)
            {
                graphics.FillRectangle(new SolidBrush(layout.colorOutline), outline[i].X * scale, outline[i].Y * scale, scale, scale);
            }

            for (int i = 0; i < inner.Count(); i++)
            {
                graphics.FillRectangle(new SolidBrush(layout.colorInner), inner[i].X * scale, inner[i].Y * scale, scale, scale);
            }
        }


        private List<Point> GetLineBrezenthema(int x1, int y1, int x2, int y2)
        {
            List<Point> outlinePoint = new List<Point>();

            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);

            int sx = x1 < x2 ? 1 : -1;
            int sy = y1 < y2 ? 1 : -1;
            int x = x1, y = y1;
            int err = dx - dy;

            int k = 0;
            while (true)
            {
                outlinePoint.Add(new Point(x, y));

                if (x == x2 && y == y2) break;

                int e2 = 2 * err;

                if (e2 > -dy)
                {
                    err -= dy;
                    x += sx;
                }

                if (e2 < dx)
                {
                    err += dx;
                    y += sy;
                }

                if (k > 1000000)
                {
                    break;
                }
            }
            return outlinePoint;
        }

        public List<Point> FillInner(List<Point> outlinePoint, Point seedPixel)
        {
            List<Point> innerPoint = new List<Point>();

            var stack = new Stack<Point>();
            stack.Push(seedPixel);

            // ¬осьмисв€зные направлени€
            var directions = new List<(int dx, int dy)>
            {
                (1, 0), (0, 1), (-1, 0), (0, -1),   // основные направлени€
            };

            while (stack.Count > 0)
            {
                var currentPixel = stack.Pop();

                // ѕропускаем, если пиксель уже закрашен или €вл€етс€ частью контура
                if (innerPoint.FindIndex(0, (pixel) => currentPixel == pixel) != -1 || outlinePoint.FindIndex(0, (pixel) => currentPixel == pixel) != -1)
                    continue;

                // ƒобавл€ем пиксель в список закрашенных
                innerPoint.Add(currentPixel);

                // ƒобавл€ем соседние пиксели по всем 8 направлени€м
                foreach (var (dx, dy) in directions)
                {
                    int newX = currentPixel.X + dx;
                    int newY = currentPixel.Y + dy;
                    var adjacentPixel = new Point(newX, newY);

                    if (innerPoint.FindIndex(0, (pixel) => adjacentPixel == pixel) == -1 && outlinePoint.FindIndex(0, (pixel) => adjacentPixel == pixel) == -1)
                    {
                        stack.Push(adjacentPixel);
                    }
                }
            }
            return innerPoint;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (currentLayout < image.GetLayoutCount())
            {
                paintLayout(image.GetLayout(currentLayout++));
                Console.WriteLine("ffff");

            }
            pictureBox1.Image = bitmap;

        }
    }

    public partial class Image {
        List<Layout> layouts = new List<Layout>();
        Layout mainLayout;

        public Image(Layout main)
        {
            mainLayout = main;
        }

        public void Add(Layout layout, int index = -1)
        {
            if (index == -1) layouts.Add(layout);
            else layouts.Insert(index, layout);
        }

        public void Remove(int index)
        {
            layouts.RemoveAt(index);
        }

        public Layout GetLayout(int index)
        {
            return layouts[index];
        }

        public int GetLayoutCount()
        {
            return layouts.Count;
        }
    }

    public class Layout{
        public Color colorInner;
        public Color colorOutline;
        public List<Point> vertexs;
        public List<Point> vertexsVisable;

        public Layout(Color inner, Color outline, List<Point> _vertexs)
        {
            vertexs = _vertexs;
            vertexsVisable = new List<Point>(_vertexs);

            colorInner = inner;
            colorOutline = outline;
        }      

    }
}
