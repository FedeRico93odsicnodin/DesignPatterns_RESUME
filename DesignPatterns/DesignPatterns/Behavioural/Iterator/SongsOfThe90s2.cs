using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Iterator
{
  public class SongsOfThe90s2 : Collection
  {
    private Dictionary<int, SongInfo> _bestSongs;

    private int _currKey = 0;


    public SongsOfThe90s2()
    {
      _bestSongs = new Dictionary<int, SongInfo>();

      AddSong("Losing My Religion", "REM", 1991);
      AddSong("Creep", "Radiohead", 1993);
      AddSong("Walk on the Ocean", "Toad the Wet Sprocket", 1991);
    }

    public void AddSong(string songName, string bandName, int yearRelease)
    {
      SongInfo songInfo = new SongInfo(songName, bandName, yearRelease);

      _bestSongs[_currKey] = songInfo;

      _currKey++;
    }


    public Dictionary<int, SongInfo> GetBestSongs()
    {
      return _bestSongs;
    }

    /// <summary>
    /// Customization of the enumerator for the current used set 
    /// </summary>
    /// <returns></returns>
    public override IEnumerator GetEnumerator()
    {
      List<SongInfo> currSongs = _bestSongs.Values.ToList();
      SetItems(currSongs);
      return new OrderIterator(this, Direction);
    }
  }
}
