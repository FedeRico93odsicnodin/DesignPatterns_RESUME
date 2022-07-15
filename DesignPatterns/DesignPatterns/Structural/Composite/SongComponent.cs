using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Composite
{
  /// <summary>
  /// A song component with some methods not yet implemented 
  /// </summary>
  public abstract class SongComponent
  {
    public abstract void Add(SongComponent newSongComponent);

    public abstract void Remove(SongComponent newSongComponent);

    public abstract SongComponent GetComponent(int componentIndex);

    public string GetSongName()
    {
      throw new NotImplementedException();
    }

    public string GetBandName()
    {
      throw new NotImplementedException();
    }

    public string GetReleaseYear()
    {
      throw new NotImplementedException();
    }

    public abstract void DisplaySongInfo();
  }
}
