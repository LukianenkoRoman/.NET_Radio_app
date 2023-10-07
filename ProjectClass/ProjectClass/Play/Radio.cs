using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using ProjectClass.SetPlaylist;

namespace ProjectClass.SetPlaylist
{
    class RadioStation
    {
        

        private int currentIndex = 0;     //defining index for controlling tracks order
        private HttpListener radio;       //creating an HttpListener object

        public RadioStation()
        {
            radio = new HttpListener();         
            radio.Prefixes.Add("http://localhost:8000/");   //setting host
        }

        public async Task Start()
        {
            radio.Start();                                         //start listening for incoming requests
            Console.WriteLine("Server have been started...");

            while (true)
            {
                HttpListenerContext context = await radio.GetContextAsync();         //get an incoming request context
                _ = HandleClientAsync(context);             //asynchronously handle the client request
            }
        }

        private async Task HandleClientAsync(HttpListenerContext context)
        {
            SwichList swichList = new SwichList();                //create an object of SwichList class

            swichList.SwitchList();                           //rxecute the SwitchList method
            List<string> lists = swichList.GetPlayList(); 

            List<string> playList = swichList.GetPlayList(); //getter to get a chosen playlist 

            HttpListenerResponse response = context.Response;

            currentIndex++;           //uploading file with next index
            if (currentIndex >= playList.Count)
            {
                currentIndex = 0;                        //reset the index if it exceeds the playlist length         
            }
            string trackPath = playList[currentIndex];       //get the path of the current track

            if (File.Exists(trackPath))
            {
                response.ContentType = "audio/mpeg";     //seting fileformat

                using (FileStream fs = File.OpenRead(trackPath))
                {
                    await fs.CopyToAsync(response.OutputStream);       //vopy the audio file to the response stream

                }

                response.Close();
            }
            else
            {
                response.StatusCode = 404;
                response.StatusDescription = "Not Found";
                response.Close();
            }
        }
    }
}



