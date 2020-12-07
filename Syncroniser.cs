using FileSyncer.Control;
using FluentFTP;
using System;
using System.Net;

namespace FileSyncer.Entity
{
    static class Syncroniser
    {
        private static int ftp_minute = 1;  // set from GUI
        private static int rsync_minute = 1;

        internal static int Ftp_minute { get => ftp_minute; set => ftp_minute = value; }
        public static int Rsync_minute { get => rsync_minute; set => rsync_minute = value; }

        static internal async void FTP(FTPFolderPair fp)
        {
            bool inBetweenSyncBoundary = fp.StartSync <= DateTime.Now && DateTime.Now <= fp.StopSync;
            if (fp.Enabled && inBetweenSyncBoundary)
                try
                {
                    using (FtpClient ftp = new FtpClient(fp.SourceIP, fp.Port, new NetworkCredential(fp.UserName, fp.PassWord)))
                    {
                        await ftp.SetWorkingDirectoryAsync(fp.SharedFolder);
                        FtpListItem[] remoteFiles = await ftp.GetListingAsync();
                        ftp.Connect();
                        await ftp.DownloadDirectoryAsync(fp.DestinationFolder, fp.SharedFolder, FtpFolderSyncMode.Update, FtpLocalExists.Append, FtpVerify.Retry);

                        var permission = ftp.GetFilePermissions(ftp.GetWorkingDirectory());
                        try
                        {
                            if (fp.DeleteSourceFiles)
                            {
                                foreach (var item in remoteFiles)
                                {
                                    ftp.DeleteFile(item.FullName);
                                }
                            }
                        }
                        catch (Exception)
                        {
                            Logger.AddLog($"Deletion is not allowed in {fp.FriendlyName} Remote Folder");
                        }
                    }
                }
                catch (Exception)
                {
                    Logger.AddLog($"Error while FTP syncing {fp.FriendlyName}");
                }
        }
    }
}
