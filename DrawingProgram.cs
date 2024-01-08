using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace RefactorMe
{
    public static class Drawer
    {
        static float x, y;
        static Graphics graphics;

        public static void PreparingBackground(Graphics newGraphics)
        {
            graphics = newGraphics;
            graphics.SmoothingMode = SmoothingMode.None;
            graphics.Clear(Color.Black);
        }

        public static void Set_position(float x0, float y0)
        { x = x0; y = y0; }

        public static void MakeIt(Pen pen, double length, double angle)
        {
            var x1 = (float)(x + length * Math.Cos(angle));
            var y1 = (float)(y + length * Math.Sin(angle));
            graphics.DrawLine(pen, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void Change(double length, double angle)
        {
            x = (float)(x + length * Math.Cos(angle));
            y = (float)(y + length * Math.Sin(angle));
        }
    }

    public static class ImpossibleSquare
    {
        public static void Draw(int width, int height, double rotationAngle, Graphics graphx)
        {
            // rotationAngle пока не используется, но будет использоваться в будущем
            Drawer.PreparingBackground(graphx);

            var size = Math.Min(width, height);
            float pi = (float)Math.PI;

            var diagonal_length = Math.Sqrt(2) * (size * 0.375f + size * 0.04f) / 2;
            var x0 = (float)(diagonal_length * Math.Cos(pi / 4 + pi)) + width / 2f;
            var y0 = (float)(diagonal_length * Math.Sin(pi / 4 + pi)) + height / 2f;

            Drawer.Set_position(x0, y0);

            //Рисуем 1-ую сторону
            FirstSide(size, pi);

            //Рисуем 2-ую сторону
            SecondSide(size, pi);

            //Рисуем 3-ю сторону
            ThirdSide(size, pi);

            //Рисуем 4-ую сторону
            FourthSide(size, pi);
        }

        private static void FourthSide(int size, float pi)
        {
            Drawer.MakeIt(Pens.Yellow, size * 0.375f, pi / 2);
            Drawer.MakeIt(Pens.Yellow, size * 0.04f * Math.Sqrt(2), pi / 2 + pi / 4);
            Drawer.MakeIt(Pens.Yellow, size * 0.375f, pi / 2 + pi);
            Drawer.MakeIt(Pens.Yellow, size * 0.375f - size * 0.04f, pi / 2 + pi / 2);

            Drawer.Change(size * 0.04f, pi / 2 - pi);
            Drawer.Change(size * 0.04f * Math.Sqrt(2), pi / 2 + 3 * pi / 4);
        }

        private static void ThirdSide(int size, float pi)
        {
            Drawer.MakeIt(Pens.Yellow, size * 0.375f, pi);
            Drawer.MakeIt(Pens.Yellow, size * 0.04f * Math.Sqrt(2), pi + pi / 4);
            Drawer.MakeIt(Pens.Yellow, size * 0.375f, pi + pi);
            Drawer.MakeIt(Pens.Yellow, size * 0.375f - size * 0.04f, pi + pi / 2);

            Drawer.Change(size * 0.04f, pi - pi);
            Drawer.Change(size * 0.04f * Math.Sqrt(2), pi + 3 * pi / 4);
        }

        private static void SecondSide(int size, float pi)
        {
            Drawer.MakeIt(Pens.Yellow, size * 0.375f, -pi / 2);
            Drawer.MakeIt(Pens.Yellow, size * 0.04f * Math.Sqrt(2), -pi / 2 + pi / 4);
            Drawer.MakeIt(Pens.Yellow, size * 0.375f, -pi / 2 + pi);
            Drawer.MakeIt(Pens.Yellow, size * 0.375f - size * 0.04f, -pi / 2 + pi / 2);

            Drawer.Change(size * 0.04f, -pi / 2 - pi);
            Drawer.Change(size * 0.04f * Math.Sqrt(2), -pi / 2 + 3 * pi / 4);
        }

        private static void FirstSide(int size, float pi)
        {
            Drawer.MakeIt(Pens.Yellow, size * 0.375f, 0);
            Drawer.MakeIt(Pens.Yellow, size * 0.04f * Math.Sqrt(2), pi / 4);
            Drawer.MakeIt(Pens.Yellow, size * 0.375f, pi);
            Drawer.MakeIt(Pens.Yellow, size * 0.375f - size * 0.04f, pi / 2);

            Drawer.Change(size * 0.04f, -pi);
            Drawer.Change(size * 0.04f * Math.Sqrt(2), 3 * pi / 4);
        }
    }
}