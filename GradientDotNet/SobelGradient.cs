namespace GradientDotNet
{
    public static class SobelGradient
    {
        private static readonly float[] flippedOperatorX = {
            -1, 0, 1,
            -2, 0, 2,
            -1, 0, 1,
        };

        private static readonly float[] flippedOperatorY = {
            -1, -2, -1,
            0, 0, 0,
            1, 2, 1,
        };

        public static void CalculateX(float[] src, float[] dst, int rows, int cols)
        {
            LinAlg.Filter(flippedOperatorX, 3, 3, 1, 1, src, dst, rows, cols);
        }

        public static void CalculateX(IImage src, IImage dst)
        {
            LinAlg.Filter(flippedOperatorX, 3, 3, 1, 1, src, dst);
        }

        public static void CalculateY(float[] src, float[] dst, int rows, int cols)
        {
            LinAlg.Filter(flippedOperatorY, 3, 3, 1, 1, src, dst, rows, cols);
        }

        public static void CalculateY(IImage src, IImage dst)
        {
            LinAlg.Filter(flippedOperatorY, 3, 3, 1, 1, src, dst);
        }
    }
}