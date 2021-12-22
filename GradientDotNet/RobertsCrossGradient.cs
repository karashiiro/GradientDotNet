namespace GradientDotNet
{
    public class RobertsCrossGradient
    {
        private static readonly float[] flippedOperatorX = {
            -1, 0,
            0, 1,
        };

        private static readonly float[] flippedOperatorY = {
            0, -1,
            1, 0,
        };

        public static void CalculateX(float[] src, float[] dst, int rows, int cols)
        {
            LinAlg.Filter(flippedOperatorX, 2, 2, 0, 0, src, dst, rows, cols);
        }

        public static void CalculateX(IImage src, IImage dst)
        {
            LinAlg.Filter(flippedOperatorX, 2, 2, 0, 0, src, dst);
        }

        public static void CalculateY(float[] src, float[] dst, int rows, int cols)
        {
            LinAlg.Filter(flippedOperatorY, 2, 2, 0, 0, src, dst, rows, cols);
        }

        public static void CalculateY(IImage src, IImage dst)
        {
            LinAlg.Filter(flippedOperatorY, 2, 2, 0, 0, src, dst);
        }
    }
}