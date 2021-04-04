using System.Diagnostics;
using System.IO;
using MediaToolkit;
using MediaToolkit.Model;
using VideoLibrary;

namespace AudioPlayer
{
    public class YoutubeAudio
    {
        /*
         * NuGet:
         * MediaToolkit
         * VideoLibrary
         */
        
        private const string PATH = @"./../../music/";
        
        
        public static string downloadAudioFromUrl(string url)
        {
            createDirectoryIfNotExists();
            
            var youtube = YouTube.Default;
            var vid = youtube.GetVideo(url);
            File.WriteAllBytes(PATH + vid.FullName, vid.GetBytes());
            

            var inputFile = new MediaFile(filename: PATH + vid.FullName);
            var outputFile = new MediaFile(filename: $"{PATH + vid.FullName.Replace(".mp4", ".mp3")}.mp3");
            
            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);
                engine.Convert(inputFile, outputFile);
            }
               
            File.Delete(PATH + vid.FullName);

            return outputFile.Filename;
        }
        
        public static string downloadAudioFromUrlAwait(string url)
        {
            createDirectoryIfNotExists();
            
            var youtube = YouTube.Default;
            var vid = youtube.GetVideo(url);
            File.WriteAllBytes(PATH + vid.FullName, vid.GetBytes());
            

            var inputFile = new MediaFile(filename: PATH + vid.FullName);
            var outputFile = new MediaFile(filename: $"{PATH + vid.FullName.Replace(".mp4", ".mp3")}.mp3");
            
            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);
                engine.Convert(inputFile, outputFile);
            }
               
            File.Delete(PATH + vid.FullName);

            return outputFile.Filename;
        }

        private static void createDirectoryIfNotExists()
        {
            if (!Directory.Exists(PATH))
            {
                Directory.CreateDirectory(PATH);
            }
        }
    }
}