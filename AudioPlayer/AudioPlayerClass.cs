using WMPLib;

namespace AudioPlayer
{
    public class AudioPlayerClass
    {
        // private static int PlayPause = 0;
        public static WindowsMediaPlayer pl = new WindowsMediaPlayer() {settings = { volume = 30}};
        public static bool isPlaying = false;
        

        public void Play(TrackItem trackItem)
        {
            //Verify if traskItem is, arleady, current playing song
            if (Playlist.playList.IndexOf(trackItem) == Playlist.currentTrackIndex && isPlaying)
            {
                Pause();
                return;
            } else if (Playlist.playList.IndexOf(trackItem) == Playlist.currentTrackIndex && !isPlaying)
            {
                Play();
                return;
            }
         
            Playlist.currentTrackIndex = Playlist.playList.IndexOf(trackItem);
            Playlist._mainWindow.TitleLabel.Content = trackItem.title;
            Playlist._mainWindow.AuthorLabel.Content = trackItem.author;
            
            trackItem.changeIconToPlay();

            pl.URL = trackItem.path;
            pl.controls.play();
            isPlaying = true;
            
            MainWindow.timer.Start();
        }

        public void Play()
        {
            Playlist.playList[Playlist.currentTrackIndex].changeIconToPlay();

            pl.controls.play();
            isPlaying = true;

            MainWindow.timer.Start();
        }
        
        public void Pause()
        {
            Playlist.playList[Playlist.currentTrackIndex].changeIconToPause();

            pl.controls.pause();
            isPlaying = false;
            MainWindow.timer.Stop();
        }

        

        public void Next()
        {
            if (Playlist.currentTrackIndex < Playlist.playList.Count - 1 && Playlist.currentTrackIndex >= 0)
            {
                   Play(Playlist.playList[Playlist.currentTrackIndex + 1]);
                   
            } else if (Playlist.currentTrackIndex == Playlist.playList.Count - 1) //Last item from list
            {
                Play(Playlist.playList[0]);
            }
        }

        public void Prev()
        {
            if (Playlist.currentTrackIndex < Playlist.playList.Count && Playlist.currentTrackIndex > 0)
            {
                Play(Playlist.playList[Playlist.currentTrackIndex - 1]);
                   
            } else if (Playlist.currentTrackIndex == 0) //Last item from list
            {
                Play(Playlist.playList[Playlist.playList.Count - 1]);
            }
        }
        

        public void currentPositionChanged(int currentPosition)
        {
            pl.controls.currentPosition = currentPosition;
        }
        
        
    }
}