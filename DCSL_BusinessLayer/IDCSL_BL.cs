using System;
using System.Collections.Generic;
using System.Text;

namespace DCSL_BusinessLayer
{
    public interface IDCSL_BL
    {
        string DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs);
        string TrackCopyStatus();
    }
}
