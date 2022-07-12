using System;
using System.IO;

namespace DCSL_BusinessLayer
{
    public class DCSL_BL : IDCSL_BL
    {
        public string opStatus { get; set; } = String.Empty;
        public string DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            string result = string.Empty;
            try
            {
                // Get the subdirectories for the specified directory.
                DirectoryInfo dir = new DirectoryInfo(sourceDirName);

                if (!dir.Exists)
                {
                    result = "Source directory does not exist or could not be found: " + sourceDirName;
                    return result;
                }

                DirectoryInfo[] dirs = dir.GetDirectories();

                // If the destination directory doesn't exist, create it.       
                Directory.CreateDirectory(destDirName);

                // Get the files in the directory and copy them to the new location.
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string tempPath = Path.Combine(destDirName, file.Name);
                    file.CopyTo(tempPath, false);
                    opStatus = file.Name + " copied to " + destDirName + "\r\n" + Environment.NewLine;
                }

                // If copying subdirectories, copy them and their contents to new location.
                if (copySubDirs)
                {
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        string tempPath = Path.Combine(destDirName, subdir.Name);
                        DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                    }
                }
                result = "All files copied successfully";
            }
            catch (OperationCanceledException ex)
            {
                result = "Copy file cancelled : " + ex.Message;
            }
            catch (Exception ex)
            {
                result = "Copy file cancelled : " + ex.Message;
            }
            return result;
        }

        public string TrackCopyStatus()
        {
            return opStatus;
        }
    }
}
