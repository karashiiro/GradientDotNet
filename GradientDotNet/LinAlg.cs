using System;

namespace GradientDotNet
{
    internal static class LinAlg
    {
        public static void Filter(float[] flippedKernel, int kRows, int kCols, int kCenterR, int kCenterC, float[] src,
            float[] dst, int rows, int cols)
        {
            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < cols; c++)
                {
                    var sum = 0f;
                    for (var kR = 0; kR < kRows; kR++)
                    {
                        for (var kC = 0; kC < kCols; kC++)
                        {
                            var nextR = Math.Min(Math.Max(0, kR - kCenterR + r), rows - 1);
                            var nextC = Math.Min(Math.Max(0, kC - kCenterC + c), cols - 1);
                            sum += flippedKernel[kR * kRows + kC] * src[nextR * rows + nextC];
                        }
                    }

                    dst[r * rows + c] = sum;
                }
            }
        }
    }
}