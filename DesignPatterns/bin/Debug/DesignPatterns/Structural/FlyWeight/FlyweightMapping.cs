using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.FlyWeight
{
  /// <summary>
  /// This is a mapping of every flyweight in the set of console rectangle 
  /// it will add the console rectangle only if not present in memory 
  /// it will return the console rectangle only if the properties matches
  /// this last rectangle returned will be used for the drawing instead of using a new one 
  /// </summary>
  public class FlyweightMapping
  {
    /// <summary>
    /// For this map in memory the key is the 
    /// </summary>
    private List<ConsoleRectangle> _currConsoleRectMapping;

    public FlyweightMapping()
    {
      _currConsoleRectMapping = new List<ConsoleRectangle>();
    }

    /// <summary>
    /// Adding a new rectangle to the set 
    /// </summary>
    /// <param name="currRectangle"></param>
    public void AddNewRectToMapper(ConsoleRectangle currRectangle)
    {
      // if the rectangle is alredy in the set there's no necessity to add it 
      if (CheckRectPresence(currRectangle.Width, currRectangle.Height, currRectangle.ColorID))
        return;
      // adding the rectangle to the set 
      _currConsoleRectMapping.Add(currRectangle);
    }

    /// <summary>
    /// Verify if the rectangle is already mapped in the set 
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="colorID"></param>
    /// <returns></returns>
    private bool CheckRectPresence(int width, int height, int colorID)
    {
      if (_currConsoleRectMapping.Where(
        x => x.Width == width
      && x.Height == height
      && x.ColorID == colorID).Count() > 0)
        return true;

      return false;
    }

    /// <summary>
    /// Getting the rectangle already in memory 
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="colorID"></param>
    /// <param name="memorizedRectangle"></param>
    /// <returns></returns>
    public bool GetRectangleFromTheSet(int width, int height, int colorID, out ConsoleRectangle memorizedRectangle)
    {
      memorizedRectangle = null;
      if (!CheckRectPresence(width, height, colorID))
        return false;
      // getting the rectangle already in memory
      memorizedRectangle = _currConsoleRectMapping.Where(
        x => x.Width == width
        && x.Height == height
        && x.ColorID == colorID).FirstOrDefault();
      return true;
    }
  }
}
