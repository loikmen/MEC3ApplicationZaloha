using System;
using System.Collections.Generic;
using System.Text;
using MEC3AppSample.Model.Events;

namespace MEC3AppSample.Interfaces
{
   public interface IFilesService
    {
        string StorageDirectory { get; }

        void DownloadFile(string url, string folder);
        event EventHandler<DownloadEventArgs> OnFileDownloaded;

        void OpenFile(string path);
        


    }
}
