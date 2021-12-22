namespace GradientDotNet
{
    public class IntermediateDifferenceGradient
    {
        // Definition taken from https://www.mathworks.com/help/images/ref/imgradient.html

        public static void CalculateX(float[] src, float[] dst, int rows, int cols)
        {
            for (var r = 0; r < rows; r++)
            {
                // Calculate gradient for the first column
                dst[r * cols] = src[r * cols + 1] - src[r * cols];

                // Calculate gradient for the middle columns
                for (var c = 1; c < cols - 1; c++)
                {
                    dst[r * rows + c] = src[r * cols + c + 1] - src[r * cols + c];
                }

                // Calculate gradient for the last column
                dst[r * cols + (cols - 1)] = src[r * cols + (cols - 1)] - src[r * cols + (cols - 2)];
            }
        }

        public static void CalculateY(float[] src, float[] dst, int rows, int cols)
        {
            // Calculate gradient for the first row
            for (var c = 0; c < cols; c++)
            {
                dst[c] = src[1 + c] - src[c];
            }

            // Calculate gradient for the middle rows
            for (var r = 1; r < rows - 1; r++)
            {
                for (var c = 0; c < cols; c++)
                {
                    dst[r * cols + c] = src[(r + 1) * cols + c] - src[r * cols + c];
                }
            }

            // Calculate gradient for the last row
            for (var c = 0; c < cols; c++)
            {
                dst[(rows - 1) * cols + c] = src[(rows - 1) * cols + c] - src[(rows - 2) * cols + c];
            }
        }
    }
}