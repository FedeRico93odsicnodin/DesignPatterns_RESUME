using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Composite
{
  public class Song : SongComponent
  {
    private string _songName;
    private string _bandName;
    private int _releaseYear;

    public Song(string newSongName, string newBandName, int newYearReleased)
    {
      this._songName = newSongName;
      this._bandName = newBandName;
      this._releaseYear = newYearReleased;
    }
    
    /// <summary>
    /// Getters for class property
    /// </summary>
    /// <returns></returns>
    public string GetSongName() { return _songName; }
    public string GetBandName() { return _bandName; }

    public int GetReleaseYear() { return _releaseYear; }

    public override void Add(SongComponent newSongComponent)
    {
      throw new NotImplementedException();
    }

    public override void DisplaySongInfo()
    {
      Console.WriteLine(GetSongName() + " was recorded by " + GetBandName() + " in year " + GetReleaseYear());
    }

    public override SongComponent GetComponent(int componentIndex)
    {
      throw new NotImplementedException();
    }

    public override void Remove(SongComponent newSongComponent)
    {
      throw new NotImplementedException();
    }
  }
}
