using System;

namespace GradientDotNet
{
    public static class CentralDifferenceGradient
    {
        // Definition taken from https://www.mathworks.com/help/images/ref/imgradient.html

        public static void CalculateX(float[] src, float[] dst, int rows, int cols)
        {
            for (var r = 0; r < rows; r++)
            {
                // Calculate gradient for the first column
                dst[r * cols] = (src[r * cols + 1] - src[r * cols]) / 2;

                // Calculate gradient for the middle columns
                for (var c = 1; c < cols - 1; c++)
                {
                    dst[r * cols + c] = (src[r * cols + c + 1] - src[r * cols + (c - 1)]) / 2;
                }

                // Calculate gradient for the last column
                dst[r * cols + (cols - 1)] = (src[r * cols + (cols - 1)] - src[r * cols + (cols - 2)]) / 2;
            }
        }

        public static void CalculateX(IImage src, IImage dst)
        {
            var rows = src.Height;
            var cols = src.Width;
            for (var r = 0; r < rows; r++)
            {
                // Calculate gradient for the first column
                dst.SetPixel(r, 0, (src.GetPixel(r, 1) - src.GetPixel(r, 0)) / 2);

                // Calculate gradient for the middle columns
                for (var c = 1; c < cols - 1; c++)
                {
                    dst.SetPixel(r, c, (src.GetPixel(r, c + 1) - src.GetPixel(r, c - 1)) / 2);
                }

                // Calculate gradient for the last column
                dst.SetPixel(r, cols - 1, (src.GetPixel(r, cols - 1) - src.GetPixel(r, cols - 2)) / 2);
            }
        }

        public static void CalculateY(float[] src, float[] dst, int rows, int cols)
        {
            // Calculate gradient for the first row
            for (var c = 0; c < cols; c++)
            {
                dst[c] = (src[c + 1] - src[c]) / 2;
            }

            // Calculate gradient for the middle rows
            for (var r = 1; r < rows - 1; r++)
            {
                for (var c = 0; c < cols; c++)
                {
                    dst[r * cols + c] = (src[(r + 1) * cols + c] - src[(r - 1) * cols + c]) / 2;
                }
            }

            // Calculate gradient for the last row
            for (var c = 0; c < cols; c++)
            {
                dst[(rows - 1) * cols + c] = (src[(rows - 1) * cols + c] - src[(rows - 2) * cols + c]) / 2;
            }
        }

        public static void CalculateY(IImage src, IImage dst)
        {
            var rows = src.Height;
            var cols = src.Width;

            // Calculate gradient for the first row
            for (var c = 0; c < cols; c++)
            {
                dst.SetPixel(0, c, (src.GetPixel(0, c + 1) - src.GetPixel(0, c)) / 2);
            }

            // Calculate gradient for the middle rows
            for (var r = 1; r < rows - 1; r++)
            {
                for (var c = 0; c < cols; c++)
                {
                    dst.SetPixel(r, c, (src.GetPixel(r + 1, c) - src.GetPixel(r - 1, c)) / 2);
                }
            }

            // Calculate gradient for the last row
            for (var c = 0; c < cols; c++)
            {
                dst.SetPixel(rows - 1, c, (src.GetPixel(rows - 1, c) - src.GetPixel(rows - 2, c)) / 2);
            }
        }
    }
}