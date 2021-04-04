using System.Windows;
using System.Windows.Input;

namespace AudioPlayer
{
    public partial class SongAddFrom : Window
    {
        private Playlist playlist;

        public SongAddFrom(Playlist playlist)
        {
            InitializeComponent();
            this.playlist = playlist;
        }


        private void addFromYoutube(object sender, RoutedEventArgs e)
        {
            playlist.downloadFromYoutube();
        }

        private void addFromFile(object sender, RoutedEventArgs e)
        {
            playlist.readFile();
        }
        
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}