using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Input;

namespace GMF.Directory.ViewModel
{
    class SpotifyControlModuleLoginViewModel : BaseViewModel
    {
        private string authUrl = "http://5.189.129.153:7500/spotify/login";

        public System.Windows.Visibility ConnectToSpotifyButtonVisibility { get; set; }
    public ICommand OpenAuthWebsiteCommmand { get; set; }

        public SpotifyControlModuleLoginViewModel()
        {
            ConnectToSpotifyButtonVisibility = System.Windows.Visibility.Hidden;
            OpenAuthWebsiteCommmand = new RelayCommand(OpenAuthWebsite);
            CheckIfSpotifyIsConnected();

        }

        private void CheckIfSpotifyIsConnected()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(authUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (String.IsNullOrWhiteSpace(response.CharacterSet))
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                string data = readStream.ReadToEnd();
                if (data.Contains("<!DOCTYPE html>"))
                {
                    ConnectToSpotifyButtonVisibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    ConnectToSpotifyButtonVisibility = System.Windows.Visibility.Hidden;

                }
                response.Close();
                readStream.Close();

                
            }
        }

        public void OpenAuthWebsite()
        {

            var startInfo = new ProcessStartInfo();
            startInfo.WorkingDirectory = "C:\\Windows\\System32";// working directory
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/c start " + authUrl;// set additional properties 
            
            Process proc = Process.Start(startInfo);
        }

    }
}
