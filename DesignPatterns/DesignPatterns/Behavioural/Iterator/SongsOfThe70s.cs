﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Iterator
{
  public class SongsOfThe70s
  {
    private ArrayList _bestSongs;

    /// <summary>
    /// Implementing the method songs of the 70s by the mean of the array list 
    /// </summary>
    public SongsOfThe70s()
    {
      _bestSongs = new ArrayList();

      AddSong("Imagine", "John Lennon", 1971);
      AddSong("American Pie", "Don McLean", 1971);
      AddSong("I Will Survive", "Gloria Gaynor", 1979);
    }

    public void AddSong(string songName, string bandName, int yearRelease)
    {
      SongInfo songInfo = new SongInfo(songName, bandName, yearRelease);

      _bestSongs.Add(songInfo);
    }

    /// <summary>
    /// BAD way: implementing directly the method which will return the arraylist for this case
    /// </summary>
    /// <returns></returns>
    public ArrayList GetBestSongs()
    {
      return _bestSongs;
    }
  }
}
