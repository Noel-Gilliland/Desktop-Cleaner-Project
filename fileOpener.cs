using System;
using System.Diagnostics;
using Gtk;

namespace MyGtkApp
{
    public class FileOpener
    {
        public static string? OpenDirectorySystem()
        {
            
            try
            {
                // Use Zenity to open a file or directory selection dialog
                Process process = new();
                process.StartInfo.FileName = "zenity";
                process.StartInfo.Arguments = "--file-selection --directory"; // Change `--directory` to omit folder selection
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                // Read the output (selected file or directory path)
                string result = process.StandardOutput.ReadToEnd().Trim();
                process.WaitForExit();

                if (string.IsNullOrEmpty(result))
                {
                    Console.WriteLine("No file or directory selected.");
                    return null;
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return null;
            }
        }
        public static string? place_path_in_ignore(){
            string? selectedpath = OpenDirectorySystem();
            if (!string.IsNullOrEmpty(selectedpath))
        {
            Console.WriteLine($"You selected: {selectedpath}");
            return selectedpath;
            
        }
        else
        {
            Console.WriteLine("No selection made.");
            return null;
        }
        }

        public static string? place_path_in_start(){
            string? selectedpath = OpenDirectorySystem();
            if (!string.IsNullOrEmpty(selectedpath))
        {
            Console.WriteLine($"You selected: {selectedpath}");
            return selectedpath;
            
        }
        else
        {
            Console.WriteLine("No selection made.");
            return null;
        }
        }

        
    }
}
