using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using VkNet.Utils;

namespace AudioPlayer.forms
{
    public partial class YoutubeDownloader : Window
    {
        private Playlist playlist;
        public YoutubeDownloader(Playlist playlist)
        {
            InitializeComponent();
            this.Topmost = true;

            this.playlist = playlist;
        }

        private void download(object sender, RoutedEventArgs e)
        {
            string text = UrlTextBox.Text;
            if (text != String.Empty)
            {
                try
                {
                    new Thread(() =>
                    {
                        string fileName = YoutubeAudio.downloadAudioFromUrlAwait(text);
                        MessageBox.Show("Track downloaded at " + fileName);
                        // playlist.addNewTrackItem(fileName.Split('/')[fileName.Split('/').Length - 1].Replace(".mp3", ""), "Unknown", 0, fileName);
                    }).Start();
                    MessageBox.Show("File will be downloaded soon and added to playlist soon.");
                }
                catch (Exception exception)
                {
                    //TODO: Custom Dark MessageBox
                    MessageBox.Show("Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
                playlist.saf.Close();
            }

            this.Close();
        }
        
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}