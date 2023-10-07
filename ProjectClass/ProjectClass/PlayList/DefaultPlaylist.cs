using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DefaultPlaylist
{
    private static List<string> defaultPath = new List<string>
    {
        @"C:\Users\Asus\Desktop\Music\Audio1.mp3.mp3",           //definging default playlist
        @"C:\Users\Asus\Desktop\Music\Audio2.wav",
        @"C:\Users\Asus\Desktop\Music\Metallica - The Unforgiven.mp3",
    };

    private static int currentIndex = 0;        //definding currentIndex

    public List<string> GetDefaultList()        //getter method to get a collection value
    {
        return defaultPath;
    }
}