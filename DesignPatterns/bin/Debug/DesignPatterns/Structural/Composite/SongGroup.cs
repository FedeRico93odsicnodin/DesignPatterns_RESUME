using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Composite
{
  public class SongGroup : SongComponent
  {
    private ArrayList _songComponents = new ArrayList();

    private string _groupName;
    private string _groupDescription;

    public SongGroup(string groupName, string groupDescription)
    {
      _groupName = groupName;
      _groupDescription = groupDescription;
    }

    /// <summary>
    /// Getters for the band to which the song group is referred to 
    /// </summary>
    /// <returns></returns>
    public string GetGroupName() { return _groupName; }

    public string GetGroupDescription() { return _groupDescription; }

    /// <summary>
    /// Methods for working with the array list
    /// </summary>
    public override void Remove(SongComponent newSongComponent)
    {
      _songComponents.Remove(newSongComponent);
    }


    public SongComponent GetSongComponent(int componentIndex)
    {
      return (SongComponent)_songComponents[componentIndex];
    }

    public override void DisplaySongInfo()
    {
      Console.WriteLine(GetGroupName() + " " + GetGroupDescription());
      foreach(SongComponent currSong in _songComponents)
      {
        SongComponent songInfo = currSong;
        currSong.DisplaySongInfo();
      }
    }

    public override void Add(SongComponent newSongComponent)
    {
      _songComponents.Add(newSongComponent);
    }
    
    public override SongComponent GetComponent(int componentIndex)
    {
      return (SongComponent)_songComponents[componentIndex];
    }
    
    
  }
}
