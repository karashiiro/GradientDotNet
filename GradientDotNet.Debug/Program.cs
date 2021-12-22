using GradientDotNet;
using GradientDotNet.Debug;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

static async Task SaveAsMagnitudesImage(string path, IReadOnlyList<float> gradX, IReadOnlyList<float> gradY, int rows, int cols)
{
    var magImg = new Image<L8>(cols, rows);
    for (var r = 0; r < rows; r++)
    {
        for (var c = 0; c < cols; c++)
        {
            magImg[c, r] = new L8((byte)(Math.Sqrt(gradX[r * cols + c] * gradX[r * cols + c] +
                                                   gradY[r * cols + c] * gradY[r * cols + c]) *
                                         255));
        }
    }
    await magImg.SaveAsJpegAsync(path);
}

// Download greyscale image to test with
using var http = new HttpClient();

// Davidwkennedy, CC BY-SA 3.0 <https://creativecommons.org/licenses/by-sa/3.0>, via Wikimedia Commons
await using var raw = await http.GetStreamAsync("https://upload.wikimedia.org/wikipedia/commons/3/3f/Bikesgray.jpg");

using var img = Image.Load<L8>(raw);

// Convert image to raw value array
var greyPixels = new float[img.Height * img.Width];
for (var r = 0; r < img.Height; r++)
{
    for (var c = 0; c < img.Width; c++)
    {
        greyPixels[r * img.Width + c] = img[c, r].PackedValue / 255f;
    }
}

// Create a shim for the buffer
var greyShim = new ShimImage(greyPixels, img.Height, img.Width);

// Calculate and save central difference gradient magnitudes image
var centDiffX = new ShimImage(new float[greyPixels.Length], img.Height, img.Width);
var centDiffY = new ShimImage(new float[greyPixels.Length], img.Height, img.Width);
Gradients.CentralDifference(greyShim, centDiffX, centDiffY);
await SaveAsMagnitudesImage("central_diff.jpg", centDiffX.Buffer, centDiffY.Buffer, img.Height, img.Width);

// Calculate and save intermediate difference gradient magnitudes image
var intDiffX = new ShimImage(new float[greyPixels.Length], img.Height, img.Width);
var intDiffY = new ShimImage(new float[greyPixels.Length], img.Height, img.Width);
Gradients.IntermediateDifference(greyShim, intDiffX, intDiffY);
await SaveAsMagnitudesImage("intermediate_diff.jpg", intDiffX.Buffer, intDiffY.Buffer, img.Height, img.Width);

// Calculate and save Sobel magnitudes image
var sobelX = new ShimImage(new float[greyPixels.Length], img.Height, img.Width);
var sobelY = new ShimImage(new float[greyPixels.Length], img.Height, img.Width);
Gradients.Sobel(greyShim, sobelX, sobelY);
await SaveAsMagnitudesImage("sobel.jpg", sobelX.Buffer, sobelY.Buffer, img.Height, img.Width);

// Calculate and save Prewitt magnitudes image
var prewittX = new ShimImage(new float[greyPixels.Length], img.Height, img.Width);
var prewittY = new ShimImage(new float[greyPixels.Length], img.Height, img.Width);
Gradients.Prewitt(greyShim, prewittX, prewittY);
await SaveAsMagnitudesImage("prewitt.jpg", prewittX.Buffer, prewittY.Buffer, img.Height, img.Width);

// Calculate and save Roberts cross magnitudes image
var robertsCrossX = new ShimImage(new float[greyPixels.Length], img.Height, img.Width);
var robertsCrossY = new ShimImage(new float[greyPixels.Length], img.Height, img.Width);
Gradients.RobertsCross(greyShim, robertsCrossX, robertsCrossY);
await SaveAsMagnitudesImage("roberts_cross.jpg", robertsCrossX.Buffer, robertsCrossY.Buffer, img.Height, img.Width);