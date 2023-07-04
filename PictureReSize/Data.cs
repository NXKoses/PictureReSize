using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace PictureReSize
{
    struct AppData
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
        public static bool multiple_folder_entry = false;
        public static bool multiple_folder_synchronous_entry = false;

        public static int thread_Value = 10;
    }

    public static class OutputDataType
    {
        public static ImageFormat GetImageFormatOutputDataType(string? name)
        {
            ImageFormat format = name switch
            {
                "bmp" => ImageFormat.Bmp,
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
                "jpeg" => 1,
                "png" => 2,
                _ => 2,
            }; ;
            return intformat;
        }
        public static string GetNameOutputDataType(int v)
        {
            string intformat = v switch
            {
                0 => "bmp",
                1 => "jpeg",
                2 => "png",
                _ => "jpeg",
            }; ;
            return intformat;
        }
    }
}
