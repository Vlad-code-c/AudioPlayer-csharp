using System;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Timer = System.Timers.Timer;

namespace AudioPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private static Playlist playlist;
        private static bool playListIsClosed = true;
        private static AudioPlayerClass player = new AudioPlayerClass();
        public static Timer timer;

        public MainWindow()
        {
            InitializeComponent();
            
            // this.Topmost = true;
            playlist = new Playlist(this);

            initTimer();

            audioPlayerStateChangedInit();
            
        }


        private void audioPlayerStateChangedInit()
        {
            AudioPlayerClass.pl.PlayStateChange += state =>
            {
                //0 = Undefined, 1 = Stopped (by User), 2 = Paused, 3 = Playing, 4 = Scan Forward,5 = Scan Backwards,
                //6 = Buffering, 7 = Waiting, 8 = Media Ended, 9 = Transitioning, 10 = Ready, 11 = Reconnecting,12 = Last
                
                if (state == 8)
                {
                    player.Next();
                }

                if (state == 10)
                {
                    player.Play();
                }
            };
        }
        
        #region Timer

        private void initTimer()
        {
            timer = new Timer(1000);
            timer.Elapsed += TimerOnElapsed;
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                StartLabel.Content = AudioPlayerClass.pl.controls.currentPositionString;

                SliderAudio.ValueChanged -= SliderAudio_OnValueChanged;
                SliderAudio.Value = AudioPlayerClass.pl.controls.currentPosition;
                SliderAudio.ValueChanged += SliderAudio_OnValueChanged;
            });
        }

        #endregion


        public void playTrack(TrackItem trackItem)
        {
            player.Play(trackItem);
            PlayPauseButtonImage.Source = new BitmapImage(new Uri(@"\images\pause.png", UriKind.Relative));
        }


        #region XmlEvents

        private void prevSong(object sender, RoutedEventArgs e)
        {
            player.Prev();
        }

        private void nextSong(object sender, RoutedEventArgs e)
        {
            player.Next();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    
        private void showPlaylist_MouseDown(object sender, RoutedEventArgs e)
        {
            if (playListIsClosed)
            {
                // playlist.Left = (double) (playlist.Left - 400);
                // playlist.Topmost = true;;
                playlist.Show();

                playListIsClosed = false;
            }
            else
            {
                playlist.Hide();
                playListIsClosed = true;
            }
        }

        private void PlayPause(object sender, RoutedEventArgs e)
        {
            if (AudioPlayerClass.isPlaying)
            {
                player.Pause();
                PlayPauseButtonImage.Source = new BitmapImage(new Uri(@"\images\play.png", UriKind.Relative));
            }
            else
            {
                player.Play();
                PlayPauseButtonImage.Source = new BitmapImage(new Uri(@"\images\pause.png", UriKind.Relative));
            }
        }

        private void exitApp(object sender, RoutedEventArgs e)
        {
            // Close();
            Application.Current.Shutdown();
        }

        private void SliderAudio_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.currentPositionChanged((int) SliderAudio.Value);
        }

        #endregion
    }
}