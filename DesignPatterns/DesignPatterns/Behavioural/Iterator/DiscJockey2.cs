using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Iterator
{
  public class DiscJockey2
  {
    private SongsOfThe70s2 _songs70;
    private SongsOfThe80s2 _songs80;
    private SongsOfThe90s2 _songs90;

    public DiscJockey2(SongsOfThe70s2 songs70, SongsOfThe80s2 songs80, SongsOfThe90s2 songs90)
    {
      _songs70 = songs70;
      _songs80 = songs80;
      _songs90 = songs90;
    }


    public void ShowTheSongs()
    {
      Console.WriteLine("'GOOD' IMPLEMENTATION \n\n");
      // showing all songs of the 70s using the Iterator 
      OrderIterator currIterator70s = (OrderIterator)_songs70.GetEnumerator();
      while(currIterator70s.MoveNext())
      {
        SongInfo currSong = (SongInfo)currIterator70s.Current();
        Console.WriteLine(currSong.ToString()); // full description for the song 
      }
      Console.WriteLine("\n");
      // showing all the songs of the 80s using the iterator 
      OrderIterator currIterator80s = (OrderIterator)_songs80.GetEnumerator();
      while (currIterator80s.MoveNext())
      {
        SongInfo currSong = (SongInfo)currIterator80s.Current();
        Console.WriteLine(currSong.ToString()); // full description for the song 
      }
      Console.WriteLine("\n");
      // showing all the songs of the 90s using the iterator 
      OrderIterator currIterator90s = (OrderIterator)_songs90.GetEnumerator();
      while (currIterator90s.MoveNext())
      {
        SongInfo currSong = (SongInfo)currIterator90s.Current();
        Console.WriteLine(currSong.ToString()); // full description for the song 
      }
      Console.WriteLine("\n");

    }
  }
}
