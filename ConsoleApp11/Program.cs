using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Image image = Image.FromFile("02-zero-two.gif");
        FrameDimension dimension = new FrameDimension(
                           image.FrameDimensionsList[0]);
        int frameCount = image.GetFrameCount(dimension);
        StringBuilder sb;

        // Remember cursor position
        int left = Console.WindowLeft, top = Console.WindowTop;

        char[] chars = { '*', '#', '@', '%', '=', ' ',
                         ' ', ':', '-', '.', '#', '$', '(', '1' , ')','2', '3', '4', '5', '6','7','8','9',':','`',':', 'q', 'p'};
        for (int i = 0; ; i = (i + 1) % frameCount)
        {
            sb = new StringBuilder();
            image.SelectActiveFrame(dimension, i);

            for (int h = 0; h < image.Height; h++)
            { 
                for (int w = 0; w < image.Width; w++)
                {
                    Color cl = ((Bitmap)image).GetPixel(w, h);
                    int gray = (cl.A + cl.B + cl.R) / 3;
                    int index = (gray * (chars.Length)) / 256;

                    sb.Append(chars[index]);
                }
                sb.Append('\n');
            }

            Console.SetCursorPosition(left, top);
            Console.Write(sb.ToString());
            Console.SetCursorPosition(left, top);


        }
    }
}