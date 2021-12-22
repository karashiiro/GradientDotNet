# GradientDotNet
Image gradient functions implemented in C#.

## Installation
`Install-Package GradientDotNet`

## Gradient algorithms
- Central difference
- Intermediate difference
- Sobel operator
- Prewitt operator
- Roberts cross operator

## Usage
```csharp
var greyPixels = new float[img.Height * img.Width];

// Fill your greyscale image

// Or intermediate difference, or Sobel...
var centDiffX = new float[greyPixels.Length];
var centDiffY = new float[greyPixels.Length];
Gradients.CentralDifference(greyPixels, centDiffX, centDiffY, img.Height, img.Width);
```

You can also create an implementation of `IImage` that maps get/set calls to another image
library to calls that this library can understand, and use that implementation instead of
a direct buffer:
```csharp
var greyImage = new YourImageInterfaceImplementation(img);

// Or intermediate difference, or Sobel...
var centDiffX = new YourImageInterfaceImplementation(centDiffXImg);
var centDiffY = new YourImageInterfaceImplementation(centDiffYImg);
Gradients.CentralDifference(greyImage, centDiffX, centDiffY);
```

Alternatively, you can use the X and Y gradient calculation functions directly, as follows:
```csharp
var centDiffX = new float[greyPixels.Length];
var centDiffY = new float[greyPixels.Length];
CentralDifferenceGradient.CalculateX(greyPixels, centDiffX, img.Height, img.Width);
CentralDifferenceGradient.CalculateY(greyPixels, centDiffY, img.Height, img.Width);
```
