using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace AudioPlayer
{
    public partial class TrackItem : UserControl
    {
        public string path;
        // public static Playlist playlist;

        //Getters
        public int index => (int) Button.Tag;
        public string title => Title.Content.ToString();
        public string author => Author.Content.ToString();
        public int length => (int) Lenght.Content;
        public TrackItem(int index, string title, string author, int lenght, string path)
        {
            InitializeComponent();
            Button.Tag = index;

            Title.Content = title;
            Author.Content = author;
            Lenght.Content = lenght;

            this.path = path;

        }

        public void changeIconToPlay()
        {
            ButtonIcon.Source = new BitmapImage(new Uri(@"\images\pause.png", UriKind.Relative));
        }

        public void changeIconToPause()
        {
            ButtonIcon.Source = new BitmapImage(new Uri(@"\images\play.png", UriKind.Relative));
        }
        
        
        private void playStopTrack(object sender, RoutedEventArgs e)
        {
            Playlist._mainWindow.playTrack(this);
        }
    }
}