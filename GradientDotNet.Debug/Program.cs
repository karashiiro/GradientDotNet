using GradientDotNet;
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

// Calculate and save central difference gradient magnitudes image
var centDiffX = new float[greyPixels.Length];
var centDiffY = new float[greyPixels.Length];
Gradients.CentralDifference(greyPixels, centDiffX, centDiffY, img.Height, img.Width);
await SaveAsMagnitudesImage("central_diff.jpg", centDiffX, centDiffY, img.Height, img.Width);

// Calculate and save intermediate difference gradient magnitudes image
var intDiffX = new float[greyPixels.Length];
var intDiffY = new float[greyPixels.Length];
Gradients.IntermediateDifference(greyPixels, intDiffX, intDiffY, img.Height, img.Width);
await SaveAsMagnitudesImage("intermediate_diff.jpg", intDiffX, intDiffY, img.Height, img.Width);

// Calculate and save Sobel magnitudes image
var sobelX = new float[greyPixels.Length];
var sobelY = new float[greyPixels.Length];
Gradients.Sobel(greyPixels, sobelX, sobelY, img.Height, img.Width);
await SaveAsMagnitudesImage("sobel.jpg", sobelX, sobelY, img.Height, img.Width);

// Calculate and save Prewitt magnitudes image
var prewittX = new float[greyPixels.Length];
var prewittY = new float[greyPixels.Length];
Gradients.Prewitt(greyPixels, prewittX, prewittY, img.Height, img.Width);
await SaveAsMagnitudesImage("prewitt.jpg", prewittX, prewittY, img.Height, img.Width);

// Calculate and save Roberts cross magnitudes image
var robertsCrossX = new float[greyPixels.Length];
var robertsCrossY = new float[greyPixels.Length];
Gradients.RobertsCross(greyPixels, robertsCrossX, robertsCrossY, img.Height, img.Width);
await SaveAsMagnitudesImage("roberts_cross.jpg", robertsCrossX, robertsCrossY, img.Height, img.Width);