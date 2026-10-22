namespace VanDerWaals
{
    internal static class Maths
    {
        public static float Floor(float x)
        {
            return (float)(Math.Floor(x));
        }

        public static float Ceiling(float x)
        {
            return Floor(x) + 1.0f;
        }

        public static float FloorToInt(float x)
        {
            return (int)(Floor(x));
        }

        public static float CeilingToInt(float x)
        {
            return (int)(Ceiling(x));
        }

        public static float Sine(float degrees)
        {
            return (float)(Math.Sin(degrees));
        }

        public static float Cosine(float degrees)
        {
            return (float)(Math.Cos(degrees));
        }
    }
}
