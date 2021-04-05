using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;
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
                    var thread = new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;

                        string fileName = YoutubeAudio.downloadAudioFromUrlAwait(text);
                        MessageBox.Show("Track downloaded at " + fileName);
                        
                        // playlist.addTrackItem(fileName);
                    });
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
            
            
                    MessageBox.Show("File will be downloaded soon");
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