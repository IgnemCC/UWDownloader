using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.IO;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace UWDownloader
{
    class UWD
    {
        static void Main(string[] args)
        {
            //Main Menue
            int choice = 9;
            while(choice != 1 && choice != 2 && choice !=3)
            {
                
                Console.WriteLine("Uni Wien Downloader:\n");
                Console.WriteLine("Main Menue:");
                Console.WriteLine("1.) Read Links from links.txt");
                Console.WriteLine("2.) Paste Link");
                Console.WriteLine("3.) Exit");
                int.TryParse(Console.ReadLine(), out choice);

                if(choice != 1 && choice != 2 && choice != 3)
                Console.WriteLine("Please select a valid Option!");

            }
            
            switch(choice)
            {
                case 1:
                    Console.WriteLine("Downloading Links in links.txt");
                    MultiDownload("links.txt");
                    break;

                case 2:
                    Console.WriteLine("Please enter a Link to download from:");
                    String inputLink = Console.ReadLine();
                    Console.WriteLine("Please enter the desired file output name:");
                    String output = Console.ReadLine();
                    SingleDownload(inputLink, output);
                    break;

                case 3:
                    Console.WriteLine("Terminating...");
                    Environment.Exit(0);
                    break;
            }
          
        }

        static bool SingleDownload(String link, String outputName)
        {
            
            try
            {
                Console.WriteLine("Downloading...");
                var client = new WebClient();

                //getting video id from link and feeding it to Downloader
                String[] ids = link.Split('=');
                VO video = new VO(ids[1], outputName);

                client.DownloadFile(video.getCam(), outputName + "_audio.webm");
                client.DownloadFile(video.getScreen(), outputName + "_video.webm");

            }

            catch(Exception e)
            {
                Console.WriteLine("Error while Downloading!\n");
                Console.WriteLine(e.Message);
                return false;
            }

            Console.WriteLine("Successfully downloaded " + outputName + "!");
            Console.WriteLine("Starting Conversion using ffmpeg.exe...");

            try
            {
                //feeding downloaded videos to ffmpeg
                Process ffmpeg = new Process();
                ffmpeg.StartInfo.FileName = "ffmpeg.exe";
                String arguments = "-i " + outputName + "_video.webm" + " -i " + outputName + "_audio.webm" + " -c:v copy -c:a aac " + outputName + ".mp4";
                ffmpeg.StartInfo.Arguments = arguments;
                ffmpeg.StartInfo.UseShellExecute = false;
                ffmpeg.StartInfo.RedirectStandardOutput = true;
                ffmpeg.Start();

                ffmpeg.WaitForExit();

                Console.WriteLine("\nConversion successful!");
                Console.WriteLine("File saved as " + outputName + ".mp4");

            }
            
            catch (Exception e)
            {
                //Exception handling
                Console.WriteLine("Error while loading ffmpeg.exe!");
                Console.WriteLine(e.Message);
                Console.WriteLine("Did you check if the file is present and has the correct the file name (ffmpeg.exe)?");
                return false;
            }

            try
            {
                //deleting unwanted files
                Console.WriteLine("Cleaning up files...");
                File.Delete(outputName + "_video.webm");
                File.Delete(outputName + "_audio.webm");
            }

            catch(Exception e)
            {
                Console.WriteLine("Error while cleaning up files!");
                Console.WriteLine(e.Message);
            }

            return true;
        }

        static bool MultiDownload(String filename)
        {
            //run SingleDownload for every link and name the files accordingly
            int counter = 1;
            String[] links = File.ReadAllLines(filename);

            foreach (String link in links)
            {
                String c = counter.ToString();
                if (!SingleDownload(link, "Vorlesung" + c))
                Console.WriteLine("Error while downloading Link " + c + "!");

                counter++;
            }

            return true;
        }

    }

}
