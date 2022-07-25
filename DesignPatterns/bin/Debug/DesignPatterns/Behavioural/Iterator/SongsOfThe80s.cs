using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Iterator
{
  public class SongsOfThe80s
  {
    private SongInfo[] _bestSongs;

    private int _maxNum = 3;

    private int _currNum = 0;


    
    public SongsOfThe80s()
    {
      _bestSongs = new SongInfo[3];

      AddSong("Roam", "B 52s", 1989);
      AddSong("Cruel Summer", "Bananarama", 1984);
      AddSong("Head Over Heels", "Tears For Fears", 1985);
    }

    public void AddSong(string songName, string bandName, int yearRelease)
    {
      SongInfo songInfo = new SongInfo(songName, bandName, yearRelease);

      if(_currNum < _maxNum)
        _bestSongs[_currNum] = songInfo;
      // incremento su array di partenza 
      else
      {
        SongInfo[] _newSongs = new SongInfo[_maxNum + 1];
        _newSongs[_currNum] = songInfo;
        for(int i = 0; i < _bestSongs.Length; i++)
          _newSongs[i] = _bestSongs[i];

        _bestSongs = _newSongs;
      }
      _currNum++;
    }


    public SongInfo[] GetBestSongs()
    {
      return _bestSongs;
    }
  }
}
