using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;


// Flip для картинки

void FlipImageHorizontal(string inputPath, string outputPath)
{
    using var img = Image.Load<Rgba32>(inputPath);
    img.Mutate(x => x.Flip(FlipMode.Horizontal));
    img.Save(outputPath);
}