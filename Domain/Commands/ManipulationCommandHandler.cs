using ImageManipulation.Api.Domain.Response;
using MediatR;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageManipulation.Api.Domain.Commands
{
    public class ManipulationCommandHandler : IRequestHandler<ManipulationCommand, ManipulationCommandResponse>
    {
        public async Task<ManipulationCommandResponse> Handle(ManipulationCommand request, CancellationToken cancellationToken)
        {
            byte[] imageArray = Convert.FromBase64String(request.image);
            string waterMark = "marca d'água";
            string imageWithWaterMark;

            using (MemoryStream ms = new MemoryStream(imageArray))
            {
                using (Image image = Image.FromStream(ms))
                {
                    // Adicionar a marca d'água
                    if((image.PixelFormat & PixelFormat.Indexed) != 0)
                    {
                        using (Bitmap nonIndexedBitmap = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb))
                        {
                            using (Graphics g = Graphics.FromImage(nonIndexedBitmap))
                            {
                                g.DrawImage(image, 0, 0, image.Width, image.Height);
                            }
                            imageWithWaterMark = AddWaterMark(nonIndexedBitmap, waterMark, request.format);
                        }
                    } 
                    else
                    {
                        imageWithWaterMark = AddWaterMark(image, waterMark, request.format);
                    }
                    return new ManipulationCommandResponse { image = imageWithWaterMark };
                }
            }
        }
        public static ImageFormat GetImageFormat(string format)
        {
            switch (format.ToLower())
            {
                case "bmp":
                    return ImageFormat.Bmp;
                case "emf":
                    return ImageFormat.Emf;
                case "exif":
                    return ImageFormat.Exif;
                case "gif":
                    return ImageFormat.Gif;
                case "icon":
                    return ImageFormat.Icon;
                case "jpeg":
                case "jpg":
                    return ImageFormat.Jpeg;
                case "png":
                    return ImageFormat.Png;
                case "tiff":
                    return ImageFormat.Tiff;
                case "wmf":
                    return ImageFormat.Wmf;
                default:
                    throw new ArgumentException("Invalid image format", nameof(format));
            }
        }
        public static string AddWaterMark(Image image, string waterMark, string format) 
        {
            using (Graphics graphics = Graphics.FromImage(image))
            {
                Font watermarkFont = new Font("Arial", 20, FontStyle.Bold);
                SizeF textSize = graphics.MeasureString(waterMark, watermarkFont);
                Point position = new Point(image.Width - ((int)textSize.Width + 10), image.Height - ((int)textSize.Height + 10));

                graphics.DrawString(waterMark, watermarkFont, Brushes.Black, position);

                // Criar um novo MemoryStream para a imagem resultante
                using (MemoryStream resultStream = new MemoryStream())
                {
                    image.Save(resultStream, GetImageFormat(format));
                    byte[] resultBytes = resultStream.ToArray();

                    // Codificar a imagem resultante em Base64
                    return Convert.ToBase64String(resultBytes);
                }
            }
        }
    }
}
