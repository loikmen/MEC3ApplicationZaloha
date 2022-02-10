using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Xamarin.Forms;
using MEC3AppSample.Interfaces;
using MEC3AppSample.Model.Events;

[assembly: Dependency(typeof(MEC3AppSample.Droid.Services.AndroidFileService))]
namespace MEC3AppSample.Droid.Services
{
    public class AndroidFileService : IFilesService
    {
        public string StorageDirectory => Android.App.Application.Context.GetExternalFilesDir(null).AbsolutePath;

        public event EventHandler<DownloadEventArgs> OnFileDownloaded;

        public void DownloadFile(string url, string folder)
        {
            string pathToNewFolder = Path.Combine(StorageDirectory, folder);
            Directory.CreateDirectory(pathToNewFolder);

            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
                string pathToNewFile = Path.Combine(pathToNewFolder, Path.GetFileName(url));
                webClient.DownloadFileAsync(new Uri(url), pathToNewFile);

            } catch (Exception exp)
            {

                if(OnFileDownloaded != null)
                {
                    OnFileDownloaded.Invoke(this, new DownloadEventArgs(false));
                }

            }
        }

        public void OpenFile(string path)
        {
            string extension = Android.Webkit.MimeTypeMap.GetFileExtensionFromUrl(Android.Net.Uri.FromFile(new Java.IO.File(path)).ToString());
            string mimeType = Android.Webkit.MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);

            Context context = Android.App.Application.Context;
            Android.Net.Uri uri = FileProvider.GetUriForFile(context, context.PackageName + ".provider", new Java.IO.File(path));
            Intent intent = new Intent(Intent.ActionView);
            intent.SetDataAndType(uri, mimeType);
            intent.AddFlags(ActivityFlags.NewTask);
            intent.AddFlags(ActivityFlags.GrantReadUriPermission);
            Intent chooserInten = Intent.CreateChooser(intent, "Open with:");
            chooserInten.AddFlags(ActivityFlags.NewTask);

            try
            {
                context.StartActivity(intent);
            }
            catch 
            {
                Toast.MakeText(context, "No application available to View PDF", ToastLength.Short).Show();
            }
        }

        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {

            if (e.Error != null)
            {
                if(OnFileDownloaded != null)
                {
                    OnFileDownloaded.Invoke(this, new DownloadEventArgs(false));
                }      
            }
            else
            {

                if (OnFileDownloaded != null)
                {
                    OnFileDownloaded.Invoke(this, new DownloadEventArgs(true));
                }


            }
        }
    }
}