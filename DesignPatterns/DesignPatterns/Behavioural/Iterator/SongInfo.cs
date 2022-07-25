using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Iterator
{
  public class SongInfo
  {
    private string _songName;
    private string _bandName;
    private int _yearRelease;

    public SongInfo(string newSongName, string newBandName, int newYearRelase)
    {
      _songName = newSongName;
      _bandName = newBandName;
      _yearRelease = newYearRelase;
    }

    public string GetSongName() { return _songName; }
    public string GetBandName() { return _bandName; }
    public int GetYearRelease() { return _yearRelease; }

    /// <summary>
    /// Returning a full description for the current song 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return GetSongName() + " " + GetBandName() + " " + GetYearRelease();
    }
  }
}
