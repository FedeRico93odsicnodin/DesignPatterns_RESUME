using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Iterator
{
  /// <summary>
  /// BAD implementation: getting the different sets and scanning them using the 
  /// for loop without getting advantage of the iterator 
  /// </summary>
  public class DiscJockey
  {
    private SongsOfThe70s _songs70;
    private SongsOfThe80s _songs80;
    private SongsOfThe90s _songs90;

    public DiscJockey(SongsOfThe70s songs70, SongsOfThe80s songs80, SongsOfThe90s songs90)
    {
      _songs70 = songs70;
      _songs80 = songs80;
      _songs90 = songs90;
    }


    public void ShowTheSongs()
    {
      Console.WriteLine("'BAD' IMPLEMENTATION \n\n");
      // showing all songs of the 70s without using the Iterator 
      ArrayList all70Songs = _songs70.GetBestSongs();
      for(int i = 0; i < all70Songs.Count; i++)
      {
        SongInfo currSong = (SongInfo)all70Songs[i];
        Console.WriteLine(currSong.ToString()); // full description for the song 
      }
      Console.WriteLine("\n");

      // showing all the songs of the 80s without using the iterator 
      SongInfo[] all80Songs = _songs80.GetBestSongs();
      for(int j = 0; j < all80Songs.Count(); j++)
      {
        SongInfo currSong = all80Songs[j];
        Console.WriteLine(currSong.ToString()); // full description for the song 
      }
      Console.WriteLine("\n");

      // showing all the songs of the 90s without using the iterator 
      Dictionary<int, SongInfo> all90Songs = _songs90.GetBestSongs();
      for(int k = 0; k < all90Songs.Count; k++)
      {
        SongInfo currSong = all90Songs[k];
        if(currSong != null)
        {
          Console.WriteLine(currSong.ToString()); // full description for the song 
        }
      }
    }
  }
}
