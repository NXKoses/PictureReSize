using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace PictureReSize
{
    static class Data
    {
        public static string GetAppPath() => Application.StartupPath;
        public static string? Appname;

        public static bool converting;

        public static string? InputFolderPath;
        public static string? OutputFolderPath;
        public static string? InputFileType;
        public static ImageFormat? OutputFileType;
        public static List<string> inputFolderListPath = new();

        public static int X;
        public static int Y;

        public static bool aspect_lock;
        public static bool fukusu = false;

        public static int thread_Value = 10;
    }

    public static class OutputDataType
    {
        public static ImageFormat GetImageFormatOutputDataType(string? name)
        {
            ImageFormat format = name switch
            {
                "bmp" => ImageFormat.Bmp,
                "icon" => ImageFormat.Icon,
                "jpeg" => ImageFormat.Jpeg,
                "png" => ImageFormat.Png,
                _ => ImageFormat.Jpeg,
            }; ;
            return format;
        }
        public static int GetIntOutputDataType(string name)
        {
            int intformat = name switch
            {
                "bmp" => 0,
                "icon" => 1,
                "jpeg" => 2,
                "png" => 3,
                _ => 2,
            }; ;
            return intformat;
        }
        public static string GetNameOutputDataType(int v)
        {
            string intformat = v switch
            {
                0 => "bmp",
                1 => "icon",
                2 => "jpeg",
                3 => "png",
                _ => "jpeg",
            }; ;
            return intformat;
        }
    }
}
