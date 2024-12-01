using System.Collections.Generic;
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
        int scale = 3;
        int offsetX = 0, offsetY = 0;

        private bool axesVisible = false;
        private bool gridVisible = false;
        private bool isAVid = true;

        public Form1()
        {
            InitializeComponent();
            image = new Image(new Layout(Color.Red, Color.Black, new List<Point> { new Point(0, 0), new Point(500, 0), new Point(500, 500), new Point(0, 500) }));

            List<Point> la1 = new List<Point>
            {
                new Point(12 * 5, 6 * 5),
                new Point(12 * 5, 12 * 5),
                new Point(6 * 5, 12 * 5),
            };

            List<Point> la2 = new List<Point>
            {
                new Point(10 * 5, 10 * 5),
                new Point(10 * 5, 15 * 5),
                new Point(15 * 5, 10 * 5),
            };

            List<Point> la3 = new List<Point>
            {
                new Point(9 * 5, 5*5),
                new Point(13 * 5, 18 * 5),
                new Point(5 * 5, 7 * 5),
            };

            Layout layouta1 = new Layout(Color.FromArgb(244, 200, 111), Color.Black, la1);
            image.Add(layouta1);

            Layout layouta3 = new Layout(Color.FromArgb(244, 200, 111), Color.Black, la3);
            image.Add(layouta3);

            Layout layouta2 = new Layout(Color.FromArgb(244, 200, 111), Color.Black, la2);
            image.Add(layouta2);

            //Console.WriteLine("In polygon " + needVisable(layout2, new Point(17, 10)));
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
        private void DrawAxes(Graphics graphics, int width, int height, int scale)
        {
            // ����� ��� ���������
            int centerX = offsetX;
            int centerY = offsetY;

            Pen axisPen = new Pen(Color.Black, 1);
            Pen recPen = new Pen(Color.Black, 2);

            graphics.DrawLine(axisPen, offsetX, centerY, width, centerY);

            graphics.DrawLine(axisPen, centerX, offsetY, centerX, height);

            graphics.DrawRectangle(recPen, 0, 0, width - 2, height - 2);
        }

        private void btnDrawAxes_Click(object sender, EventArgs e)
        {
            axesVisible = !axesVisible;

            if (axesVisible)
            {
                DrawAxes(graphics, pictureBox1.Width, pictureBox1.Height, scale);
                button1.Text = "������ ���";
            }
            else
            {
                graphics.Clear(Color.White); // �������� �������
                currentLayout = 0;
                button1.Text = "�������� ���";
            }

            pictureBox1.Image = bitmap;
        }

        private void DrawGrid(Graphics graphics, int width, int height, int scale)
        {
            // ���� ��� ����� �����
            Pen gridPen = new Pen(Color.Gray, 1);

            // ��������� ������������ �����
            for (int x = 0; x <= width; x += scale)
            {
                graphics.DrawLine(gridPen, x, 0, x, height);
            }

            // ��������� �������������� �����
            for (int y = 0; y <= height; y += scale)
            {
                graphics.DrawLine(gridPen, 0, y, width, y);
            }
        }

        private void btnDrawGrid_Click(object sender, EventArgs e)
        {
            gridVisible = !gridVisible;

            if (gridVisible)
            {
                DrawGrid(graphics, bitmap.Width * scale, bitmap.Height * scale, scale);
                button2.Text = "������ ����� ������";
            }
            else
            {
                graphics.Clear(Color.White); // �������� �������
                currentLayout = 0;
                button2.Text = "�������� ����� ������";
            }

            pictureBox1.Image = bitmap;
        }

        public void paintLayout(Layout layout)
        {
            Console.WriteLine("Paint " + layout.colorInner);
            int avgX = 0; int avgY = 0;
            List<Point> outline = new List<Point>();

            for (int i = 0; i < layout.vertexs.Count; i++)
            {
                var start = layout.vertexs[i];
                avgX += (int)start.X;
                avgY += (int)start.Y;

                var end = layout.vertexs[(i + 1) % layout.vertexs.Count];
                outline.AddRange(GetLineBrezenthema((int)start.X, (int)start.Y, (int)end.X, (int)end.Y));
            }
            avgX /= layout.vertexs.Count;
            avgY /= layout.vertexs.Count;

            List<Point> inner = FillInner(outline, new Point(avgX, avgY));
            if (isAVid)
            {
                for (int i = 0; i < outline.Count(); i++)
                {
                    Point curre = outline[i];
                    if (curre.X > image.mainLayout.vertexs[2].X || curre.Y > image.mainLayout.vertexs[2].Y || curre.X < image.mainLayout.vertexs[0].X || curre.Y < image.mainLayout.vertexs[0].Y)
                    {
                        continue;
                    }

                    bool need = needVisable(layout, curre);
                    Console.WriteLine($"({curre.X};{curre.Y}) - {need}");
                    if (!need)
                    {
                        continue;
                    }

                    graphics.FillRectangle(new SolidBrush(layout.colorOutline), (outline[i].X + offsetX) * scale, (outline[i].Y + offsetY) * scale, scale, scale);

                }

                for (int i = 0; i < inner.Count(); i++)
                {
                    if (!(PnPoly(layout.visable, inner[i]))) { continue; }
                    if (!needVisable(layout, inner[i])) { continue; }
                    graphics.FillRectangle(new SolidBrush(layout.colorInner), (inner[i].X + offsetX) * scale, (inner[i].Y + offsetY) * scale, scale, scale);
                }
            }
            else
            {
                for (int i = 0; i < outline.Count(); i++)
                {
                    Point curre = outline[i];
                    Color resColor = layout.colorOutline;
                    if (curre.X > image.mainLayout.vertexs[2].X || curre.Y > image.mainLayout.vertexs[2].Y || curre.X < image.mainLayout.vertexs[0].X || curre.Y < image.mainLayout.vertexs[0].Y)
                    {
                        continue;
                    }

                    bool need = needVisable(layout, curre);
                    Console.WriteLine($"({curre.X};{curre.Y}) - {need}");

                    if (!need)
                    {
                        Color existColor = bitmap.GetPixel(outline[i].X, outline[i].Y);
                        int r = existColor.R ^ layout.colorOutline.R;
                        int g = existColor.G ^ layout.colorOutline.G;
                        int b = existColor.B ^ layout.colorOutline.B;
                        int a = existColor.A ^ layout.colorOutline.A;
                        resColor = Color.FromArgb(r, g, b, a);
                    }
                    graphics.FillRectangle(new SolidBrush(resColor), (outline[i].X + offsetX) * scale, (outline[i].Y + offsetY) * scale, scale, scale);

                }

                for (int i = 0; i < inner.Count(); i++)
                {
                    Color resColor = layout.colorInner;
                    if (!(PnPoly(layout.visable, inner[i]))) { continue; }
                    if (!needVisable(layout, inner[i])) 
                    {
                        resColor = Color.FromArgb(resColor.R, resColor.G, resColor.B, resColor.A/3);
                    }
                    graphics.FillRectangle(new SolidBrush(resColor), (inner[i].X + offsetX) * scale, (inner[i].Y + offsetY) * scale, scale, scale);
                }
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

            // ������������� �����������
            var directions = new List<(int dx, int dy)>
            {
                (1, 0), (0, 1), (-1, 0), (0, -1),   // �������� �����������
            };

            while (stack.Count > 0)
            {
                var currentPixel = stack.Pop();

                // ����������, ���� ������� ��� �������� ��� �������� ������ �������
                if (innerPoint.FindIndex(0, (pixel) => currentPixel == pixel) != -1 || outlinePoint.FindIndex(0, (pixel) => currentPixel == pixel) != -1)
                    continue;

                // ��������� ������� � ������ �����������
                innerPoint.Add(currentPixel);

                // ��������� �������� ������� �� ���� 8 ������������
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
                Console.WriteLine(currentLayout);

            }
            pictureBox1.Image = bitmap;

        }

        private void textBoxSpeed_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int newInterval) && newInterval > 0)
            {
                timer1.Interval = newInterval;
                Console.WriteLine($"�������� ������� ���������� ��: {newInterval} ��");
            }
            else
            {
                Console.WriteLine("������� ���������� �������� ��������� (������������� �����).");
            }
        }
        public static bool needVisable(Layout polygon, Point point)
        {
            for (int i = 0; i < polygon.vertexsInvisable.Count; i++)
            {
                if (PnPoly(polygon.vertexsInvisable[i], point)) return false;
            }
            return true;
        }


        // ������� ��� ��������, ����� �� ����� �� �������
        public static bool IsPointOnSegment(Point p, Point p1, Point p2)
        {
            // ���������, ��� ����� p ����� �� ������� p1p2
            return (p.X >= Math.Min(p1.X, p2.X) && p.X <= Math.Max(p1.X, p2.X) &&
                    p.Y >= Math.Min(p1.Y, p2.Y) && p.Y <= Math.Max(p1.Y, p2.Y) &&
                    (p2.Y - p1.Y) * (p.X - p1.X) == (p.Y - p1.Y) * (p2.X - p1.X));
        }

        public static bool PnPoly(List<Point> polygon, Point p)
        {
            bool inside = false;
            int n = polygon.Count;
            int j = n - 1;  // ������ ��������� �������

            for (int i = 0; i < n; i++)
            {
                float x1 = polygon[i].X, y1 = polygon[i].Y;
                float x2 = polygon[j].X, y2 = polygon[j].Y;

                // ��������, ����� �� ����� �� ����� �� �����
                if (IsPointOnSegment(p, polygon[i], polygon[j]))
                {
                    return false;  // ����� ����� �� �����
                }

                // ���������, ���������� �� �������������� ���, ��������� �� ����� p
                if (((y1 > p.Y) != (y2 > p.Y)) && // ���� ������� ��������� �� ������ ������� �� ����� y = p.Y
                    (p.X < (x2 - x1) * (p.Y - y1) / (y2 - y1) + x1)) // ������� ����������� � ������
                {
                    inside = !inside;
                }

                j = i;  // ���������� j � i ��� ��������� ��������
            }

            return inside;
        }

        private static bool Inside(Point p, Point cp1, Point cp2)
        {
            return (cp2.X - cp1.X) * (p.Y - cp1.Y) > (cp2.Y - cp1.Y) * (p.X - cp1.X);
        }

        // ������� ����� ����������� ���� ��������
        private static Point Intersection(Point s, Point e, Point cp1, Point cp2)
        {
            float dcX = cp1.X - cp2.X;
            float dcY = cp1.Y - cp2.Y;
            float dpX = s.X - e.X;
            float dpY = s.Y - e.Y;

            float n1 = cp1.X * cp2.Y - cp1.Y * cp2.X;
            float n2 = s.X * e.Y - s.Y * e.X;
            float n3 = 1.0f / (dcX * dpY - dcY * dpX);

            float ix = (n1 * dpX - n2 * dcX) * n3;
            float iy = (n1 * dpY - n2 * dcY) * n3;

            return new Point((int)ix, (int)iy);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int newScale) && newScale > 0)
            {
                scale = newScale;
                graphics.Clear(Color.White); // �������� �������
                currentLayout = 0;
            }
            else
            {
                Console.WriteLine("������� ���������� �������� ��������� (������������� �����).");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox3.Text, out int newOffsetX) &&
                int.TryParse(textBox4.Text, out int newOffsetY))
            {
                offsetX = newOffsetX;
                offsetY = newOffsetY;
                graphics.Clear(Color.White); // �������� �������
                currentLayout = 0;

            }
            else
            {
                MessageBox.Show("Please enter valid integers for offsets.");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            isAVid = !isAVid;

            if (isAVid)
            {
                graphics.Clear(Color.White); 
                currentLayout = 0;
                button6.Text = "����� �";
            }
            else
            {
                graphics.Clear(Color.White); 
                currentLayout = 0;
                button6.Text = "����� �";
            }

            pictureBox1.Image = bitmap;
        }
        //dop a1

        public static List<List<Point>> ClipPolygon(List<Point> subjectPolygon, List<Point> clipPolygon)
        {
            List<List<Point>> resultPolygons = new List<List<Point>>();

            // ��� 1: ����� ����� �����������
            List<Point> intersections = FindIntersections(subjectPolygon, clipPolygon);

            // ��� 2: ������� ������ ������ � ����� �����������
            List<Point> currentPolygon = new List<Point>();
            List<Point> enteringIntersections = new List<Point>();
            List<Point> exitingIntersections = new List<Point>();

            foreach (Point intersection in intersections)
            {
                // ����������, �������� �� ����� �������� ��� ���������
                if (IsEntering(intersection, subjectPolygon))
                {
                    enteringIntersections.Add(intersection);
                }
                else
                {
                    exitingIntersections.Add(intersection);
                }
            }

            // ��� 3: ����� ������ ��������������� ��������������
            for (int i = 0; i < subjectPolygon.Count; i++)
            {
                Point current = subjectPolygon[i];
                currentPolygon.Add(current);

                if (intersections.Contains(current))
                {
                    if (enteringIntersections.Contains(current))
                    {
                        // ���� ����� �����, �������� ����� �������
                        resultPolygons.Add(new List<Point>(currentPolygon));
                        currentPolygon.Clear();
                    }
                }
            }

            // ���������� �������� ��� ����������� ��������������
            for (int i = 0; i < clipPolygon.Count; i++)
            {
                Point current = clipPolygon[i];
                currentPolygon.Add(current);

                if (intersections.Contains(current))
                {
                    if (enteringIntersections.Contains(current))
                    {
                        // �������� ����� ������� ��� ����������� ��������������
                        resultPolygons.Add(new List<Point>(currentPolygon));
                        currentPolygon.Clear();
                    }
                }
            }

            return resultPolygons;
        }

        private static List<Point> FindIntersections(List<Point> subjectPolygon, List<Point> clipPolygon)
        {
            List<Point> intersections = new List<Point>();

            for (int i = 0; i < subjectPolygon.Count; i++)
            {
                Point s1 = subjectPolygon[i];
                Point s2 = subjectPolygon[(i + 1) % subjectPolygon.Count];

                for (int j = 0; j < clipPolygon.Count; j++)
                {
                    Point c1 = clipPolygon[j];
                    Point c2 = clipPolygon[(j + 1) % clipPolygon.Count];

                    if (DoLinesIntersect(s1, s2, c1, c2, out Point intersection))
                    {
                        if (!intersections.Contains(intersection))
                        {
                            intersections.Add(intersection);
                        }
                    }
                }
            }
            return intersections;
        }

        public static bool DoLinesIntersect(Point s1, Point s2, Point c1, Point c2, out Point intersection)
        {
            intersection = new Point();

            double d1x = s2.X - s1.X;
            double d1y = s2.Y - s1.Y;
            double d2x = c2.X - c1.X;
            double d2y = c2.Y - c1.Y;

            double denominator = d1x * d2y - d1y * d2x;
            if (Math.Abs(denominator) < 1e-10) // �������� �� �������������� � ������ �����������
            {
                return false; // ������������ �����
            }

            double t = ((c1.X - s1.X) * d2y - (c1.Y - s1.Y) * d2x) / denominator;
            double u = ((c1.X - s1.X) * d1y - (c1.Y - s1.Y) * d1x) / denominator;

            // ��������, ��� ����� ����������� ����� � �������� ��������
            if (t >= 0 && t <= 1 && u >= 0 && u <= 1)
            {
                intersection.X = (int)(s1.X + t * d1x);
                intersection.Y = (int)(s1.Y + t * d1y);
                return true;
            }

            return false;
        }

        private static bool IsEntering(Point point, List<Point> polygon)
        {
            // ����������, ��������� �� ����� ������ ��������������, ����� ����������, �������� �� ��� �������� ��� ���������.
            int crossings = 0;
            for (int i = 0; i < polygon.Count; i++)
            {
                Point current = polygon[i];
                Point next = polygon[(i + 1) % polygon.Count];

                // ���������, ���������� �� �������������� �����, ���������� ����� �����, ����� ��������������
                if (((current.Y > point.Y) != (next.Y > point.Y)) &&
                    (point.X < (next.X - current.X) * (point.Y - current.Y) / (next.Y - current.Y) + current.X))
                {
                    crossings++;
                }
            }

            // ���� ���������� ����������� ��������, ����� ������ ��������������, ����� �������.
            bool isInside = (crossings % 2 == 1);
            return isInside; // ���� ����� ������, ���������� true, ��� �������� �������� �����.
        }


    }

    public partial class Image {
        List<Layout> layouts = new List<Layout>();
        public Layout mainLayout;

        public Image(Layout main)
        {
            mainLayout = main;
        }

        public void Add(Layout layout, int index = -1)
        {
            if (index == -1) layouts.Add(layout);
            else layouts.Insert(index, layout);
            layout.visable.AddRange(SutherlandCohenClipper.ClipPolygon(layout.vertexs, mainLayout.vertexs));

            // TODO: ���������� � ���������� �� ������� (��������� ������ ���� ��� ���
            for (int i = layouts.Count - 2; i >= 0; i--)
            {
                layouts[i].Notificate(layout);
            }
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
        public List<List<Point>> vertexsInvisable = new List<List<Point>>();
        public List<Point> visable = new List<Point>();

        public Layout(Color inner, Color outline, List<Point> _vertexs)
        {
            vertexs = _vertexs;

            colorInner = inner;
            colorOutline = outline;
        }

        public void Notificate(Layout layout)
        {
            Console.WriteLine("Notificate " + colorInner);
            List<Point> list = new List<Point>();
            Form1.ClipPolygon(vertexs, layout.vertexs).ForEach((item) => {
                item.ForEach(point => {
                    list.Add(new Point(point.X, point.Y));
                    Console.WriteLine($"Point: X = {point.X}, Y = {point.Y}");
                });
            });
            vertexsInvisable.Add(list);

        }
    }

    public class SutherlandCohenClipper
    {
        // ����� ��� ��������� �������������� �� �������������� ���������
        public static List<Point> ClipPolygon(List<Point> subjectPolygon, List<Point> clipperPolygon)
        {
            // �������� ������������� ���������, ���� �� �� �������
            if (clipperPolygon[clipperPolygon.Count - 1] != clipperPolygon[0])
            {
                clipperPolygon.Add(clipperPolygon[0]);
            }
            List<Point> clippedPolygon = new List<Point>(subjectPolygon);

            bool isIntersecting = false; // ���������� ��� ������������ �����������

            // �������� �� ����� �������������� ���������
            for (int i = 0; i < clipperPolygon.Count - 1; i++)
            {
                Point clipStart = clipperPolygon[i];
                Point clipEnd = clipperPolygon[i + 1];

                // ��������� �� �������� �����
                List<Point> newClippedPolygon = ClipByEdge(clippedPolygon, clipStart, clipEnd);

                if (newClippedPolygon.Count > 0)
                {
                    isIntersecting = true; // ���� ���� �� ���� ��������� ���������, ��������, ��� ����������� ����
                    clippedPolygon = newClippedPolygon;
                }
                else
                {
                    // ���� ����� ��������� ������� ������ ������, �� ���������� ������ ���������
                    return new List<Point>(clipperPolygon);
                }
            }

            // ���� �� ���� �����������, ���������� �������� clipperPolygon
            if (!isIntersecting)
            {
                return clipperPolygon;
            }

            return clippedPolygon;
        }

        // ����� ��������� �� ������ �����
        private static List<Point> ClipByEdge(List<Point> polygon, Point clipStart, Point clipEnd)
        {
            List<Point> result = new List<Point>();

            for (int i = 0; i < polygon.Count; i++)
            {
                Point current = polygon[i];
                Point previous = polygon[(i - 1 + polygon.Count) % polygon.Count];

                // ��������, ��������� �� ����� ������ ���� ���������
                bool isCurrentInside = IsInside(current, clipStart, clipEnd);
                bool isPreviousInside = IsInside(previous, clipStart, clipEnd);

                // ���� ��� ����� ������, ��������� ������� �����
                if (isCurrentInside && isPreviousInside)
                {
                    result.Add(current);
                }
                // ���� ����� �����������
                else if (isCurrentInside && !isPreviousInside)
                {
                    Point intersection = GetIntersection(previous, current, clipStart, clipEnd);
                    result.Add(intersection);
                    result.Add(current);
                }
                // ���� ����� �����������
                else if (!isCurrentInside && isPreviousInside)
                {
                    Point intersection = GetIntersection(previous, current, clipStart, clipEnd);
                    result.Add(intersection);
                }
            }

            return result;
        }

        // ��������, ��������� �� ����� ������ ���� ���������
        private static bool IsInside(Point p, Point clipStart, Point clipEnd)
        {
            // ���������� �� ����� ������� �� ���� ��������� ��������� �����
            return (clipEnd.X - clipStart.X) * (p.Y - clipStart.Y) - (clipEnd.Y - clipStart.Y) * (p.X - clipStart.X) >= 0;
        }

        // ������� ����� ����������� ���� ��������
        private static Point GetIntersection(Point p1, Point p2, Point q1, Point q2)
        {
            float x1 = p1.X, y1 = p1.Y, x2 = p2.X, y2 = p2.Y;
            float x3 = q1.X, y3 = q1.Y, x4 = q2.X, y4 = q2.Y;

            // ���������� ����������� ��� ���������� �����������
            float denom = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);
            if (denom == 0) return new Point(0, 0); // ������������ �������, ��� �����������

            // ������� ����� �����������
            float intersectX = ((x1 * y2 - y1 * x2) * (x3 - x4) - (x1 - x2) * (x3 * y4 - y3 * x4)) / denom;
            float intersectY = ((x1 * y2 - y1 * x2) * (y3 - y4) - (y1 - y2) * (x3 * y4 - y3 * x4)) / denom;

            return new Point((int)intersectX, (int)intersectY);
        }
    }

}