using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using AudioPlayer.forms;
using Microsoft.Win32;
using File = TagLib.File;

namespace AudioPlayer
{
    public partial class Playlist : Window
    {
        public static PlayListList playList;
        public static MainWindow _mainWindow;
        public static int currentTrackIndex = -1;
        public SongAddFrom saf;

        public Playlist(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;

            // TrackItem.playlist = this;

        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            initPlaylist();
        }


        /// <summary>
        /// Init playlistList, and add all saved tracks from db to playlist
        /// </summary>
        private void initPlaylist()
        {
            playList = new PlayListList();

            foreach (var trackItem in playList)
            {
                trackItem.Width = Grid.Width;

                ListBox.Items.Add(trackItem);
            }
        }
        
        /// <summary>
        ///     Add a new UserControl->TrackItem to playlist list
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="lenght"></param>
        /// <param name="path"></param>
        public void addNewTrackItem(string title, string author, int lenght, string path)
        {
            TrackItem trackItem = new TrackItem(playList.Count, title, author, lenght, path);
            
            trackItem.Width = Grid.Width;
            
            playList.Add(trackItem);
            ListBox.Items.Add(trackItem);
            
        }

        /// <summary>
        /// Read mp3 file and add it to playlist
        /// </summary>
        public void readFile()
        {
            var filePath = string.Empty;
            
            if (saf != null)
            {
                saf.Close();
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "mp3 files (*.mp3)|*.mp3";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            ofd.Multiselect = true;

            ofd.ShowDialog();
            
            
            for (var i = 0; i < ofd.FileNames.Length; i++)
            {
                filePath = ofd.FileNames[i];
                if (filePath.Equals(string.Empty))
                {
                    break;
                }
                
                File tagFile = File.Create(filePath);
                string artist = tagFile.Tag.AlbumArtists.Length > 0 ? tagFile.Tag.AlbumArtists[0] : "";

                addNewTrackItem(ofd.SafeFileNames[i], artist, 0, filePath);            
            }
            
        }

        public void downloadFromYoutube()
        {
            YoutubeDownloader ytd = new YoutubeDownloader(this);
            ytd.Show();
        }
        
        
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            // readFile();
            saf = new SongAddFrom(this);
            saf.ShowDialog();
        }
    }
}