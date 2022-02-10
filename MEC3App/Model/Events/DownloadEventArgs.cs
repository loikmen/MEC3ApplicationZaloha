using System;
using System.Collections.Generic;
using System.Text;

namespace MEC3AppSample.Model.Events
{

    

    public class DownloadEventArgs : EventArgs
    {
        public bool FileSaved = false;

        public DownloadEventArgs(bool fileSaved)
        {

        }


    }
}
