using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace ProjectClass.SetPlaylist
{
    public class SwichList
    {
        PlayList playlist = new PlayList();
        DefaultPlaylist defaultPlaylist = new DefaultPlaylist();
        RadioStation radioStantion = new RadioStation();

        List<string> collection;
        List<string> defaultPath;
        List<string> play;

        public SwichList()
        {
            List<string> defaultPath = defaultPlaylist.GetDefaultList();
            collection = playlist.GetList();
        }

        public void SwitchList()
        {

                if (collection.Count == 0)                 //cheacking if collection is empty
                {
                    play = defaultPath;
                }
                else
                {
                    play = collection;
                }
        }
        
        public List<string> GetPlayList()
        {
            return play;
        }
    }
}

