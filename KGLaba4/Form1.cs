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


            List<Point> l1 = new List<Point>
            {
                new Point(13 * 5, 23 * 5),
                new Point(20 * 5, 14 * 5),
                new Point(20 * 5, 23 * 5),
            };

            List<Point> l2 = new List<Point>
            {
                new Point(13 * 5, 23 * 5),
                new Point(13 * 5, 13 * 5),
                new Point(20 * 5, 14 * 5),
            };
            List<Point> l3 = new List<Point>
            {
                new Point(4 * 5, 22 * 5),
                new Point(13 * 5, 13 * 5),
                new Point(13 * 5, 23 * 5),
            };
            List<Point> l4 = new List<Point>
            {
                new Point(13 * 5, 13 * 5),
                new Point(19 * 5, 7 * 5),
                new Point(20 * 5, 14 * 5),
            };

            List<Point> l5 = new List<Point>
            {
                new Point(13 * 5, 13 * 5),
                new Point(17 * 5, 6 * 5),
                new Point(19 * 5, 7 * 5),
            };
            List<Point> l6 = new List<Point>
            {
                new Point(19 * 5, 7 * 5),
                new Point(17 * 5, 6 * 5),
                new Point(19 * 5, 5 * 5),
            };
            List<Point> l7 = new List<Point>
            {
                new Point(13 * 5, 13 * 5),
                new Point(14 * 5, 5 * 5),

                new Point(17 * 5, 6 * 5),
            };

            List<Point> l8 = new List<Point>
            {
                new Point(17 * 5, 6 * 5),

                new Point(18 * 5, 1 * 5),
                new Point(20 * 5, 5 * 5),

            };
            List<Point> l9 = new List<Point>
            {
                new Point(14 * 5, 5 * 5),
                new Point(18 * 5, 1 * 5),
                new Point(17 * 5, 6 * 5),
            };
            List<Point> l10 = new List<Point>
            {
                new Point(14 * 5, 5 * 5),
                new Point(12 * 5, 4 * 5),
                new Point(16 * 5, 4 * 5),
            };

            List<Point> l11 = new List<Point>
            {
                new Point(13 * 5, 13 * 5),
                new Point(4 * 5, 12 * 5),
                new Point(14 * 5, 5 * 5),
            };

            List<Point> l12 = new List<Point>
            {
                new Point(7 * 5, 19 * 5),
                new Point(6 * 5, 15 * 5),
                new Point(13 * 5, 13 * 5),
            };

            List<Point> l13 = new List<Point>
            {
                new Point(7 * 5, 19 * 5),
                new Point(4 * 5, 16 * 5),
                new Point(6 * 5, 15 * 5),
            };

            List<Point> l14 = new List<Point>
            {
                new Point(4 * 5, 16 * 5),

                new Point(4 * 5, 12 * 5),
                new Point(13 * 5, 13 * 5),
            };
            List<Point> l15 = new List<Point>
            {
                new Point(4 * 5, 12 * 5),
                new Point(6 * 5, 5 * 5),
                new Point(11 * 5, 7 * 5),
            };
            List<Point> l16 = new List<Point>
            {
                new Point(11 * 5, 7 * 5),
                new Point(6 * 5, 5 * 5),

                new Point(12 * 5, 4 * 5),
            };
            List<Point> l17 = new List<Point>
            {
                new Point(11 * 5, 7 * 5),
                new Point(12 * 5, 4 * 5),

                new Point(14 * 5, 5 * 5),
            };

            List<Point> l18 = new List<Point>
            {
                new Point(7 * 5, 5 * 5),
                new Point(9 * 5, 2 * 5),

                new Point(12 * 5, 4 * 5),
            };

            List<Point> l19 = new List<Point>
            {
                new Point(16 * 5, 5 * 5 - 1),
                new Point(18 * 5, 2 * 5),

                new Point(19 * 5 - 1, 5 * 5 - 1),
            };

            List<Point> l20 = new List<Point>
            {
                new Point(6 * 5, 13 * 5 + 1 ),
                new Point(10 * 5, 13 * 5 + 1),

                new Point(8 * 5, 14 * 5),
            };

            List<Point> l21 = new List<Point>
            {
                new Point(5 * 5 + 1, 13 * 5 -1 ),
                new Point(5 * 5 + 1, 11 * 5 - 1),

                new Point(7 * 5 + 1, 13 * 5 - 1 ),
            };

            List<Point> l22 = new List<Point>
            {
                new Point(7 * 5 + 1, 13 * 5 - 1 ),

                new Point(10 * 5 + 1, 11 * 5 -1 ),
                new Point(10 * 5 + 1, 13 * 5 - 1),

            };
            List<Point> l23 = new List<Point>
            {
                new Point(7 * 5 + 1, 13 * 5 - 1 ),
                new Point(5 * 5 + 1, 11 * 5 - 1),
                new Point(7 * 5 + 1, 10 * 5 - 1),
            };
            List<Point> l24 = new List<Point>
            {
                new Point(7 * 5 + 1, 13 * 5 - 1 ),
                new Point(7 * 5 + 1, 10 * 5 - 1),

                new Point(10 * 5 + 1, 11 * 5 - 1),
            };

            List<Point> l25 = new List<Point>
            {
                new Point(7 * 5 + 1, 13 * 5 - 1 ),
                new Point(6 * 5 + 1, 11 * 5 - 1),
                new Point(7 * 5 + 1, 10 * 5 - 1),
            };
            List<Point> l26 = new List<Point>
            {
                new Point(7 * 5 + 1, 13 * 5 - 1 ),
                new Point(7 * 5 + 1, 10 * 5 - 1),

                new Point(8 * 5 + 1, 11 * 5 - 1),
            };

            List<Point> l27 = new List<Point>
            {
                new Point(7 * 5, 9 * 5 ),
                new Point(6 * 5, 8 * 5),

                new Point(7 * 5, 7 * 5),
            };

            List<Point> l28 = new List<Point>
            {
                new Point(7 * 5, 9 * 5 ),
                new Point(7 * 5, 7 * 5),

                new Point(8 * 5, 8 * 5),
            };

            List<Point> l29 = new List<Point>
            {
                new Point(7 * 5 - 2, 8 * 5 ),
                new Point(7 * 5 , 8 * 5 - 2),

                new Point(8 * 5 - 2, 8 * 5),
            };

            List<Point> l30 = new List<Point>
            {
                new Point(12 * 5, 10 * 5 ),
                new Point(11 * 5, 9 * 5),

                new Point(12 * 5, 8 * 5),
            };

            List<Point> l31 = new List<Point>
            {
                new Point(12 * 5, 10 * 5 ),
                new Point(12 * 5, 8 * 5),

                new Point(14 * 5, 9 * 5 ),
            };

            List<Point> l32 = new List<Point>
            {
                new Point(12 * 5, 9 * 5),
                new Point(12 * 5 + 2, 9 * 5 - 2),

                new Point(13 * 5 - 2, 9 * 5),
            };
            Layout layout1 = new Layout(Color.FromArgb(244, 200, 111), Color.Black, l1);
            image.Add(layout1);
            Layout layout2 = new Layout(Color.FromArgb(244, 200, 111), Color.Black, l2);
            image.Add(layout2);
            Layout layout3 = new Layout(Color.FromArgb(244, 200, 111), Color.Black, l3);
            image.Add(layout3);
            Layout layout4 = new Layout(Color.FromArgb(244, 200, 111), Color.Black, l4);
            image.Add(layout4);

            Layout layout5 = new Layout(Color.FromArgb(244, 200, 111), Color.Black, l5);
            image.Add(layout5);

            Layout layout6 = new Layout(Color.FromArgb(244, 200, 111), Color.Black, l6);
            image.Add(layout6);
            Layout layout7 = new Layout(Color.FromArgb(244, 200, 111), Color.Black, l7);
            image.Add(layout7);
            Layout layout8 = new Layout(Color.FromArgb(244, 200, 111), Color.Black, l8);
            image.Add(layout8);
            Layout layout9 = new Layout(Color.FromArgb(244, 200, 111), Color.Black, l9);
            image.Add(layout9);
            Layout layout10 = new Layout(Color.FromArgb(244, 200, 111), Color.Black, l10);
            image.Add(layout10);
            Layout layout11 = new Layout(Color.FromArgb(244, 200, 111), Color.Black, l11);
            image.Add(layout11);
            Layout layout12 = new Layout(Color.FromArgb(244, 200, 111), Color.Black, l12);
            image.Add(layout12);
            Layout layout13 = new Layout(Color.FromArgb(244, 200, 111), Color.Black, l13);
            image.Add(layout13);
            Layout layout14 = new Layout(Color.FromArgb(255, 247, 202), Color.Black, l14);
            image.Add(layout14);
            Layout layout15 = new Layout(Color.FromArgb(244, 200, 111), Color.Black, l15);
            image.Add(layout15);
            Layout layout16 = new Layout(Color.FromArgb(244, 200, 111), Color.Black, l16);
            image.Add(layout16);
            Layout layout17 = new Layout(Color.FromArgb(244, 200, 111), Color.Black, l17);
            image.Add(layout17);

            Layout layout18 = new Layout(Color.FromArgb(244, 200, 111), Color.Black, l18);
            image.Add(layout18);
            Layout layout19 = new Layout(Color.FromArgb(247, 213, 150), Color.Black, l19);
            image.Add(layout19);
            Layout layout20 = new Layout(Color.Black, Color.Black, l20);
            image.Add(layout20);
            Layout layout21 = new Layout(Color.FromArgb(255, 247, 202), Color.Black, l21);
            image.Add(layout21);

            Layout layout22 = new Layout(Color.FromArgb(255, 247, 202), Color.Black, l22);
            image.Add(layout22);
            Layout layout23 = new Layout(Color.FromArgb(255, 247, 202), Color.Black, l23);
            image.Add(layout23);
            Layout layout24 = new Layout(Color.FromArgb(255, 247, 202), Color.Black, l24);
            image.Add(layout24);
            Layout layout25 = new Layout(Color.Black, Color.Black, l25);
            image.Add(layout25);
            Layout layout26 = new Layout(Color.Black, Color.Black, l26);
            image.Add(layout26);

            Layout layout27 = new Layout(Color.White, Color.Black, l27);
            image.Add(layout27);

            Layout layout28 = new Layout(Color.White, Color.Black, l28);
            image.Add(layout28);

            Layout layout29 = new Layout(Color.Black, Color.Black, l29);
            image.Add(layout29);

            Layout layout30 = new Layout(Color.White, Color.Black, l30);
            image.Add(layout30);

            Layout layout31 = new Layout(Color.White, Color.Black, l31);
            image.Add(layout31);

            Layout layout32 = new Layout(Color.Black, Color.Black, l32);
            image.Add(layout32);
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
            // Центр для отрисовки
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
                button1.Text = "Скрыть оси";
            }
            else
            {
                graphics.Clear(Color.White); // Очистить графику
                currentLayout = 0;
                button1.Text = "Показать оси";
            }

            pictureBox1.Image = bitmap;
        }

        private void DrawGrid(Graphics graphics, int width, int height, int scale)
        {
            // Перо для линий сетки
            Pen gridPen = new Pen(Color.Gray, 1);

            // Отрисовка вертикальных линий
            for (int x = 0; x <= width; x += scale)
            {
                graphics.DrawLine(gridPen, x, 0, x, height);
            }

            // Отрисовка горизонтальных линий
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
                button2.Text = "Скрыть сетку растра";
            }
            else
            {
                graphics.Clear(Color.White); // Очистить графику
                currentLayout = 0;
                button2.Text = "Включить сетку растра";
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
                    if (!(PnPoly(layout.visable, outline[i])))
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
                Console.WriteLine(currentLayout);

            }
            pictureBox1.Image = bitmap;

        }

        private void textBoxSpeed_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int newInterval) && newInterval > 0)
            {
                timer1.Interval = newInterval;
                Console.WriteLine($"Интервал таймера установлен на: {newInterval} мс");
            }
            else
            {
                Console.WriteLine("Введите корректное значение интервала (положительное число).");
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


        // Функция для проверки, лежит ли точка на отрезке
        public static bool IsPointOnSegment(Point p, Point p1, Point p2)
        {
            // Проверяем, что точка p лежит на отрезке p1p2
            return (p.X >= Math.Min(p1.X, p2.X) && p.X <= Math.Max(p1.X, p2.X) &&
                    p.Y >= Math.Min(p1.Y, p2.Y) && p.Y <= Math.Max(p1.Y, p2.Y) &&
                    (p2.Y - p1.Y) * (p.X - p1.X) == (p.Y - p1.Y) * (p2.X - p1.X));
        }

        public static bool PnPoly(List<Point> polygon, Point p)
        {
            bool inside = false;
            int n = polygon.Count;
            int j = n - 1;  // Индекс последней вершины

            for (int i = 0; i < n; i++)
            {
                float x1 = polygon[i].X, y1 = polygon[i].Y;
                float x2 = polygon[j].X, y2 = polygon[j].Y;

                // Проверка, лежит ли точка на одном из ребер
                if (IsPointOnSegment(p, polygon[i], polygon[j]))
                {
                    return true;  // Точка лежит на ребре
                }

                // Проверяем, пересекает ли горизонтальный луч, исходящий от точки p
                if (((y1 >= p.Y) != (y2 >= p.Y)) && // Если вершины находятся по разные стороны от линии y = p.Y
                    (p.X <= (x2 - x1) * (p.Y - y1) / (y2 - y1) + x1)) // Находим пересечение с линией
                {
                    inside = !inside;
                }

                j = i;  // Перемещаем j к i для следующей итерации
            }

            return inside;
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

                if (inputList.Count > 0)
                {
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
            }
            if (outputList.Count == 0) outputList = clipPolygon;

            return outputList;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int newScale) && newScale > 0)
            {
                scale = newScale;
                graphics.Clear(Color.White); // Очистить графику
                currentLayout = 0;
            }
            else
            {
                Console.WriteLine("Введите корректное значение интервала (положительное число).");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox3.Text, out int newOffsetX) &&
                int.TryParse(textBox4.Text, out int newOffsetY))
            {
                offsetX = newOffsetX;
                offsetY = newOffsetY;
                graphics.Clear(Color.White); // Очистить графику
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
                button6.Text = "Режим А";
            }
            else
            {
                graphics.Clear(Color.White); 
                currentLayout = 0;
                button6.Text = "Режим Б";
            }

            pictureBox1.Image = bitmap;
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
            Clipping.Wxlef = mainLayout.vertexs[0].X;
            Clipping.Wytop = mainLayout.vertexs[2].Y;

            Clipping.Wxrig = mainLayout.vertexs[2].X;
            Clipping.Wybot = mainLayout.vertexs[0].Y;
            List<Point> clipper = Clipping.ClipPolygon(layout.vertexs);
            layout.visable.AddRange(clipper);

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

    public class Layout
    {
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
            Form1.Clip(vertexs, layout.vertexs).ForEach((item) => list.Add(new Point(item.X, item.Y)));
            vertexsInvisable.Add(list);

        }
    }

    public class Clipping
    {
        // Координаты начала отрезка
        static float CSxn, CSyn;

        // Определяет код точки xn, yn
        static int CScode()
        {
            int i = 0;
            if (CSxn < Wxlef) i++;
            else if (CSxn > Wxrig) i += 2;
            if (CSyn < Wybot) i += 4;
            else if (CSyn > Wytop) i += 8;
            return i;
        }

        // Статические переменные для окна
        public static float Wxlef = 0, Wxrig = 100, Wybot = 0, Wytop = 100;

        // Функция отсечения
        public static int V_CSclip(ref float x0, ref float y0, ref float x1, ref float y1)
        {
            float CSxk = x1, CSyk = y1; // Coordinates for the second point of the line
            int cn, ck, visible = 0, ii = 4, s;
            float dx, dy, dxdy = 0, dydx = 0, r;

            // Initialize the points and their codes
            CSxn = x1; CSyn = y1;
            ck = CScode();

            CSxn = x0; CSyn = y0;
            cn = CScode();

            // Calculate the differences and slopes
            dx = CSxk - CSxn;
            dy = CSyk - CSyn;

            if (dx != 0)
                dydx = dy / dx;
            else
            {
                if (dy == 0)
                {
                    if (cn == 0 && ck == 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

            if (dy != 0)
                dxdy = dx / dy;

            // Main clipping loop
            do
            {
                if ((cn & ck) != 0) break; // Completely outside the window
                if (cn == 0 && ck == 0) // Completely inside the window
                {
                    visible++;
                    break;
                }

                if (cn == 0)
                {
                    // Swap points if necessary
                    s = cn; cn = ck; ck = s;
                    r = CSxn; CSxn = CSxk; CSxk = r;
                    r = CSyn; CSyn = CSyk; CSyk = r;
                }

                // Clipping the segment with window boundaries
                if ((cn & 1) != 0) // Intersection with left side
                {
                    CSyn = CSyn + dydx * (Wxlef - CSxn);
                    CSxn = Wxlef;
                }
                else if ((cn & 2) != 0) // Intersection with right side
                {
                    CSyn = CSyn + dydx * (Wxrig - CSxn);
                    CSxn = Wxrig;
                }
                else if ((cn & 4) != 0) // Intersection with bottom side
                {
                    CSxn = CSxn + dxdy * (Wybot - CSyn);
                    CSyn = Wybot;
                }
                else if ((cn & 8) != 0) // Intersection with top side
                {
                    CSxn = CSxn + dxdy * (Wytop - CSyn);
                    CSyn = Wytop;
                }

                cn = CScode(); // Recalculate the code for the new point

            } while (--ii >= 0);

            // Return the clipped segment if visible
            if (visible != 0)
            {
                x0 = CSxn;
                y0 = CSyn;
                x1 = CSxk;
                y1 = CSyk;
            }

            return visible;
        }

        public static List<Point> ClipPolygon(List<Point> polygon)
        {
            List<Point> clippedPolygon = new List<Point>();

            for (int i = 0; i < polygon.Count; i++)
            {
                Point p1 = polygon[i];
                Point p2 = polygon[(i + 1) % polygon.Count];

                float x0 = p1.X, y0 = p1.Y;
                float x1 = p2.X, y1 = p2.Y;

                // Вызываем метод с использованием ref
                int clippedSegment = Clipping.V_CSclip(ref x0, ref y0, ref x1, ref y1);


                if (clippedSegment != 0)
                {
                    Point po1 = new Point((int)x0, (int)y0);
                    Point po2 = new Point((int)x1, (int)y1);

                    if (cmpPoint(p1, po1) && cmpPoint(p2, po2)) clippedPolygon.Add(po2);
                    else
                    {
                        clippedPolygon.Add(po1);
                        clippedPolygon.Add(po2);
                    }
                }
                else
                {
                    if (p2.X >= Wxrig && p2.Y <= Wybot)
                    {
                        clippedPolygon.Add(new Point((int)Wxrig, (int)Wybot));
                    }
                    if (p2.X >= Wxrig && p2.Y >= Wytop)
                    {
                        clippedPolygon.Add(new Point((int)Wxrig, (int)Wytop));
                    }
                    if (p2.X <= Wxlef && p2.Y >= Wytop)
                    {
                        clippedPolygon.Add(new Point((int)Wxlef, (int)Wytop));
                    }
                    if (p2.X <= Wxlef && p2.Y <= Wybot)
                    {
                        clippedPolygon.Add(new Point((int)Wxlef, (int)Wybot));
                    }
                }
            }

            return clippedPolygon;
        }

        public static bool cmpPoint(Point a, Point b)
        {
            return a.X == b.X && b.Y == a.Y;
        }

    }

}