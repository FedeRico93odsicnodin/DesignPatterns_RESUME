using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Iterator
{
  public class Main_Iterator
  {
    public static void RunExample()
    {
      ////////// FIRST BLOCK //////////
      // lists of songs which do not implement the iterator definition
      SongsOfThe70s songs70s = new SongsOfThe70s();
      SongsOfThe80s songs80s = new SongsOfThe80s();
      SongsOfThe90s songs90s = new SongsOfThe90s();

      // showing the result of the bad implementation: it is correct but using the iterator 
      // is more clear 
      DiscJockey discJockeyMike = new DiscJockey(songs70s, songs80s, songs90s);
      discJockeyMike.ShowTheSongs();
      
      ////////// SECOND BLOCK //////////
      // creation of the new iterator without using the definition of the songs
      // the iteration could be 
      Collection aSetOfSongs = new Collection();
      aSetOfSongs.AddItem(new SongInfo("Losing My Religion", "REM", 1991));
      aSetOfSongs.AddItem(new SongInfo("Roam", "B 52s", 1989));
      aSetOfSongs.AddItem(new SongInfo("Imagine", "John Lennon", 1971));

      // iteration forward 
      OrderIterator songIterator = (OrderIterator)aSetOfSongs.GetEnumerator();
      while(songIterator.MoveNext())
      {
        SongInfo songInfo = (SongInfo)songIterator.Current();
        Console.WriteLine(songInfo.ToString());
      }
      // configuring for going behind and reset for the iterator 
      aSetOfSongs.ReverseDirection();
      songIterator = (OrderIterator)aSetOfSongs.GetEnumerator();
      while (songIterator.MoveNext())
      {
        SongInfo songInfo = (SongInfo)songIterator.Current();
        Console.WriteLine(songInfo.ToString());
      }
      
      ////////// THIRD BLOCK //////////
      // lists of songs which implement the iterator definition 
      SongsOfThe70s2 songs70s2 = new SongsOfThe70s2();
      SongsOfThe80s2 songs80s2 = new SongsOfThe80s2();
      SongsOfThe90s2 songs90s2 = new SongsOfThe90s2();

      // showing the result of the good implementation: this is the standardazed implementation
      // on all possible collection sets
      DiscJockey2 discJockeyTom = new DiscJockey2(songs70s2, songs80s2, songs90s2);
      discJockeyTom.ShowTheSongs();
      
    }
  }
}
