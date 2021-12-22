namespace GradientDotNet.Debug;

public class ShimImage : IImage
{
    public int Width { get; set; }
    public int Height { get; set; }

    public float[] Buffer { get; }

    public ShimImage(float[] buf, int rows, int cols)
    {
        Buffer = buf;
        Height = rows;
        Width = cols;
    }

    public float GetPixel(int row, int col)
    {
        return Buffer[row * Width + col];
    }

    public void SetPixel(int row, int col, float value)
    {
        Buffer[row * Width + col] = value;
    }
}