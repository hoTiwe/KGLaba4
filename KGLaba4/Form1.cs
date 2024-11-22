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

            List<Point> l1 = new List<Point>
        {
            new Point(5, 5),
            new Point(20, 5),
            new Point(20, 20),

            new Point(5, 20),
        };

            List<Point> l2 = new List<Point>
        {
            new Point(3, 30),
            new Point(20, 1),
            new Point(40, 30),
        };
            List<Point> l3 = new List<Point>
        {
            new Point(5, 30),
            new Point(30, 5),
            new Point(35, 30),
        };


            Layout layout1 = new Layout(Color.Red, Color.Black, l1);
            image.Add(layout1);
            Layout layout2 = new Layout(Color.Green, Color.Black, l2);
            image.Add(layout2);
            Layout layout3 = new Layout(Color.Blue, Color.Black, l3);
            //image.Add(layout3);
            Console.WriteLine("In polygon " + needVisable(layout2, new Point(17, 10)));
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
            Console.WriteLine("Paint " + layout.colorInner);
            int avgX = 0; int avgY = 0;
            List<Point> outline = new List<Point>();
            
            for (int i = 0; i < layout.vertexs.Count; i++)
            {
                var start = layout.vertexs[i];
                avgX += (int) start.X;
                avgY += (int) start.Y;

                var end = layout.vertexs[(i + 1) % layout.vertexs.Count];
                outline.AddRange(GetLineBrezenthema((int)start.X, (int)start.Y, (int)end.X, (int)end.Y));
            }
            avgX /= layout.vertexs.Count;
            avgY /= layout.vertexs.Count;

            List<Point> inner = FillInner(outline, new Point(avgX, avgY));

            for (int i = 0; i < outline.Count(); i++)
            {
                Point curre = outline[i];
                bool need = needVisable(layout, curre);
                Console.WriteLine($"({curre.X};{curre.Y}) - {need}");
                if (!need) { 
                    continue;
                }

                graphics.FillRectangle(new SolidBrush(layout.colorOutline), outline[i].X * scale, outline[i].Y * scale, scale, scale);
            }
            /*for (int i = 0; i < layout.vertexsInvisable.Count; i++)
            {
                Point curre = inner[i];
                bool need = needVisable(layout, curre);
                if (!need)
                {
                    continue;
                }
                for (int j = 0; j < layout.vertexsInvisable[i].Count; j++) 

            }*/
            
            for (int i = 0; i < inner.Count(); i++)
            {
                if (!needVisable(layout, inner[i])) { continue; }
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

            // Восьмисвязные направления
            var directions = new List<(int dx, int dy)>
            {
                (1, 0), (0, 1), (-1, 0), (0, -1),   // основные направления
            };

            while (stack.Count > 0)
            {
                var currentPixel = stack.Pop();

                // Пропускаем, если пиксель уже закрашен или является частью контура
                if (innerPoint.FindIndex(0, (pixel) => currentPixel == pixel) != -1 || outlinePoint.FindIndex(0, (pixel) => currentPixel == pixel) != -1)
                    continue;

                // Добавляем пиксель в список закрашенных
                innerPoint.Add(currentPixel);

                // Добавляем соседние пиксели по всем 8 направлениям
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

        public static bool needVisable(Layout polygon, Point point)
        {
            for (int i = 0; i < polygon.vertexsInvisable.Count; i++)
            {
                if (PnPoly(polygon.vertexsInvisable[i], point)) return false;
            }
            return true;
        }

        public static bool PnPoly(List<Point> polygon, Point p)
        {
            bool c = false;
            int npol = polygon.Count;
            int j = npol - 1;  // РРЅРґРµРєСЃ РїСЂРµРґС‹РґСѓС‰РµР№ РІРµСЂС€РёРЅС‹ (РґР»СЏ РїРµСЂРІРѕР№ РёС‚РµСЂР°С†РёРё)

            for (int i = 0; i < npol; j = i++)
            {
                // РџРѕР»СѓС‡Р°РµРј РєРѕРѕСЂРґРёРЅР°С‚С‹ РІРµСЂС€РёРЅ РјРЅРѕРіРѕСѓРіРѕР»СЊРЅРёРєР°
                float x1 = polygon[i].X, y1 = polygon[i].Y;
                float x2 = polygon[j].X, y2 = polygon[j].Y;

                // РџСЂРѕРІРµСЂСЏРµРј, РїРµСЂРµСЃРµРєР°РµС‚ Р»Рё РіРѕСЂРёР·РѕРЅС‚Р°Р»СЊРЅР°СЏ Р»РёРЅРёСЏ, РїСЂРѕС…РѕРґСЏС‰Р°СЏ С‡РµСЂРµР· С‚РѕС‡РєСѓ (p.X, p.Y), СЂРµР±СЂРѕ РјРЅРѕРіРѕСѓРіРѕР»СЊРЅРёРєР°
                if (((y1 <= p.Y && p.Y <= y2) || (y2 <= p.Y && p.Y <= y1)) &&
                    ((y2 - y1) != 0) &&
                    (p.X > ((x2 - x1) * (p.Y - y1) / (y2 - y1) + x1)))
                {
                    c = !c;  // РџРµСЂРµРєР»СЋС‡Р°РµРј СЃРѕСЃС‚РѕСЏРЅРёРµ РїРµСЂРµРјРµРЅРЅРѕР№ c
                }
            }
            return c;  // Р’РѕР·РІСЂР°С‰Р°РµРј, Р»РµР¶РёС‚ Р»Рё С‚РѕС‡РєР° РІРЅСѓС‚СЂРё РјРЅРѕРіРѕСѓРіРѕР»СЊРЅРёРєР°
        }

        private static bool Inside(Point p, Point cp1, Point cp2)
        {
            return (cp2.X - cp1.X) * (p.Y - cp1.Y) > (cp2.Y - cp1.Y) * (p.X - cp1.X);
        }

        // Находим точку пересечения двух отрезков
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

        // Основной метод отсечения
        public static List<Point> Clip(List<Point> subjectPolygon, List<Point> clipPolygon)
        {
            List<Point> outputList = new List<Point>(subjectPolygon);
            Point cp1 = clipPolygon[clipPolygon.Count - 1];

            foreach (Point cp2 in clipPolygon)
            {
                List<Point> inputList = new List<Point>(outputList);
                outputList.Clear();

                Point s = inputList[inputList.Count - 1];
                foreach (Point e in inputList)
                {
                    if (Inside(e, cp1, cp2))
                    {
                        if (!Inside(s, cp1, cp2))
                        {
                            outputList.Add(Intersection(s, e, cp1, cp2));
                        }
                        outputList.Add(e);
                    }
                    else if (Inside(s, cp1, cp2))
                    {
                        outputList.Add(Intersection(s, e, cp1, cp2));
                    }
                    s = e;
                }

                cp1 = cp2;
            }

            return outputList;
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

            // TODO: переделать с добавление по индексу (заслонять только слои под ним
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
            Form1.Clip(vertexs, layout.vertexs).ForEach((item) => list.Add(new Point(item.X, item.Y)));
            vertexsInvisable.Add(list);

        }
    }
}
