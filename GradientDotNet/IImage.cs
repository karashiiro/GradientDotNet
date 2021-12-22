namespace GradientDotNet;

public interface IImage
{
    public int Width { get; set; }

    public int Height { get; set; }

    public float GetPixel(int row, int col);

    public void SetPixel(int row, int col, float value);
}