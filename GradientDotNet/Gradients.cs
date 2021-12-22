namespace GradientDotNet
{
    public static class Gradients
    {
        /// <summary>
        /// Calculates the central difference gradients of the source image in each direction. The central
        /// difference gradient of each pixel in the image is the weighted difference between neighboring
        /// pixels.
        ///
        /// Referenced from <see href="https://www.mathworks.com/help/images/ref/imgradient.html"></see>.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dstX">The destination image, representing the gradient in the x-direction.</param>
        /// <param name="dstY">The destination image, representing the gradient in the y-direction.</param>
        /// <param name="rows">The number of rows in the image.</param>
        /// <param name="cols">The number of columns in the image.</param>
        public static void CentralDifference(float[] src, float[] dstX, float[] dstY, int rows, int cols)
        {
            CentralDifferenceGradient.CalculateX(src, dstX, rows, cols);
            CentralDifferenceGradient.CalculateY(src, dstY, rows, cols);
        }

        /// <summary>
        /// Calculates the intermediate difference gradients of the source image in each direction. The
        /// intermediate difference gradient of each pixel in the image is the difference between
        /// an adjacent pixel and the current pixel.
        ///
        /// Referenced from <see href="https://www.mathworks.com/help/images/ref/imgradient.html"></see>.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dstX">The destination image, representing the gradient in the x-direction.</param>
        /// <param name="dstY">The destination image, representing the gradient in the y-direction.</param>
        /// <param name="rows">The number of rows in the image.</param>
        /// <param name="cols">The number of columns in the image.</param>
        public static void IntermediateDifference(float[] src, float[] dstX, float[] dstY, int rows, int cols)
        {
            IntermediateDifferenceGradient.CalculateX(src, dstX, rows, cols);
            IntermediateDifferenceGradient.CalculateY(src, dstY, rows, cols);
        }

        /// <summary>
        /// Calculates the Sobel operator gradients of the source image in each direction using convolution.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dstX">The destination image, representing the gradient in the x-direction.</param>
        /// <param name="dstY">The destination image, representing the gradient in the y-direction.</param>
        /// <param name="rows">The number of rows in the image.</param>
        /// <param name="cols">The number of columns in the image.</param>
        public static void Sobel(float[] src, float[] dstX, float[] dstY, int rows, int cols)
        {
            SobelGradient.CalculateX(src, dstX, rows, cols);
            SobelGradient.CalculateY(src, dstY, rows, cols);
        }

        /// <summary>
        /// Calculates the Prewitt operator gradients of the source image in each direction using convolution.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dstX">The destination image, representing the gradient in the x-direction.</param>
        /// <param name="dstY">The destination image, representing the gradient in the y-direction.</param>
        /// <param name="rows">The number of rows in the image.</param>
        /// <param name="cols">The number of columns in the image.</param>
        public static void Prewitt(float[] src, float[] dstX, float[] dstY, int rows, int cols)
        {
            PrewittGradient.CalculateX(src, dstX, rows, cols);
            PrewittGradient.CalculateY(src, dstY, rows, cols);
        }

        /// <summary>
        /// Calculates the Roberts cross operator gradients of the source image in each direction using convolution.
        /// </summary>
        /// <param name="src">The source image.</param>
        /// <param name="dstX">The destination image, representing the gradient in the x-direction.</param>
        /// <param name="dstY">The destination image, representing the gradient in the y-direction.</param>
        /// <param name="rows">The number of rows in the image.</param>
        /// <param name="cols">The number of columns in the image.</param>
        public static void RobertsCross(float[] src, float[] dstX, float[] dstY, int rows, int cols)
        {
            RobertsCrossGradient.CalculateX(src, dstX, rows, cols);
            RobertsCrossGradient.CalculateY(src, dstY, rows, cols);
        }
    }
}
