using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Composite
{
  /// <summary>
  /// For him the songcomponent just represents a list of songs
  /// </summary>
  public class DiscJockey
  {
    private SongComponent _songList;

    public DiscJockey(SongComponent newSongList)
    {
      _songList = newSongList;
    }

    public void GetSongList()
    {
      _songList.DisplaySongInfo();
    }
  }
}
