using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using ProjectClass.SetPlaylist;

class Radio
{
    static async Task Main()
    {
        PlayList playlist = new PlayList();
        DefaultPlaylist defaultPlaylist = new DefaultPlaylist();
        RadioStation radioStantion = new RadioStation();
        SwichList swichList = new SwichList();

        List<string> collection = playlist.GetList();
        List<string> defaultPath = defaultPlaylist.GetDefaultList();



        if (collection.Count == 0)
        {
            List<string> list = defaultPath;

        }
        else
        {
            List<string> list = collection;
        }
        while (true)
        {
            Console.WriteLine("chose an option:");
            Console.WriteLine("1. Wach a playlist");
            Console.WriteLine("2. Crate a playlist");
            Console.WriteLine("3. Add track to playlist");
            Console.WriteLine("4. Change ordmung");
            Console.WriteLine("5. Start");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    playlist.GetList();
                    Console.WriteLine(collection);
                    break;
                case "2":
                    playlist.SetList();
                    break;
                case "3":
                    playlist.AddToList();
                    break;
                case "4":
                    playlist.ChangeList();
                    break;
                case "5":
                    swichList.SwitchList();
                    RadioStation radioStation = new RadioStation();
                    await radioStation.Start();


                    break;
                
                default:
                    Console.WriteLine("Недійсний вибір. Спробуйте ще раз.");
                    break;
            };

            
            
        }

    }

    
}