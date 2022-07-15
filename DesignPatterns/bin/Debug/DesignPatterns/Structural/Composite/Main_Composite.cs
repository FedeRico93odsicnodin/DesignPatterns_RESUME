using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.Composite
{
  public class Main_Composite
  {
    public static void RunExample()
    {
      // defining the music genres (by the means of songgroup implementation of the composition)
      SongComponent industrialMusic = new SongGroup("Industrial", "description of music 1");
      SongComponent heavyMetalMusic = new SongGroup("Heavy Metal", "some other descriptions for the second genre");
      SongComponent dubstepMusic = new SongGroup("Dubstep", "the last description for the music to play");

      // defining the list of every available song 
      SongComponent everySong = new SongGroup("SongList", "every song available");

      // adding the different music (before to the list of available list and then the songs to the different songlists)
      // adding for the industrial music
      everySong.Add(industrialMusic);
      industrialMusic.Add(new Song("Head like a hole", "NIN", 1990));
      industrialMusic.Add(new Song("Headhunter", "Front 242", 1988));

      // adding the dubsteps songs as a second branch of the industrial music 
      industrialMusic.Add(dubstepMusic);
      // adding songs for the dubstep music 
      dubstepMusic.Add(new Song("Centipede", "Knife Party", 2012));
      dubstepMusic.Add(new Song("Tetris", "Doctor P", 2011));

      // adding the branch of Metal Music to all the songs 
      everySong.Add(heavyMetalMusic);
      // adding songs to heavy metal 
      heavyMetalMusic.Add(new Song("War Pigs", "Black Sabbath", 1970));
      heavyMetalMusic.Add(new Song("Ace of Spades", "Motorhead", 1980));

      // instance of the DiscJockey which is able to play every song available
      DiscJockey crazyLarry = new DiscJockey(everySong);
      crazyLarry.GetSongList();
    }
  }
}
