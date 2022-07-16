using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Structural.FlyWeight
{
  public class Main_Flyweight
  {
    public static void RunExample()
    {
      // declaring the array of possible colors for random rectangles
      ConsoleColor[] possibleColors = {
        ConsoleColor.Blue,
        ConsoleColor.Cyan,
        ConsoleColor.Gray,
      ConsoleColor.Green,
        ConsoleColor.Magenta,
        ConsoleColor.White,
        ConsoleColor.Yellow};

      // asking to the user how many rectangles to print 
      // NB: more rectangles are printed, more is the accuracy of the test 
      int numRectangles = 0;
      do
      {
        Console.WriteLine("please insert the number of rectangles to print:");
        string input = String.Empty;
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        do
        {
          input += keyInfo.KeyChar.ToString();
          keyInfo = Console.ReadKey();
        }
        while (keyInfo.Key != ConsoleKey.Enter);
       
          
        int.TryParse(input, out numRectangles);
      }
      while (numRectangles == 0);

      // declaring the time span variables for the time 
      TimeSpan stopWatchResult1;
      TimeSpan stopWatchResult2;
      
      // having some parameters initialization 
      int w = Console.WindowWidth;
      int h = Console.WindowHeight;
      Random rnd = new Random();
      // this is for monitoring the elapsed time 
      Stopwatch stopWatch = new Stopwatch();

      // running the first part of the DEMO - without the optimization 
      Console.Clear();
      Console.WriteLine("writing " + numRectangles + " random rectangles without optimized structure... this might takes sometime");
      // starting the time on the print rectangles functionality
      stopWatch.Start();
      for (int i = 0; i < numRectangles; i++)
      {
        int widthRect = rnd.Next(3, 7);
        int heightRect = rnd.Next(3, 7);
        int posW = rnd.Next(1, w - 11);
        int posH = rnd.Next(2, h - 15);
        int consoleColorInd = rnd.Next(0, possibleColors.Length - 1);
        ConsoleRectangle currRect = new ConsoleRectangle(widthRect, heightRect, new System.Drawing.Point() { X = posW, Y = posH }, possibleColors[consoleColorInd]);
        currRect.Draw();
      }
      // stopping the time on the print rectangles functionality 
      stopWatch.Stop();
      Console.CursorTop = h - 5;
      Console.WriteLine("\n\nemployed time: " + stopWatch.Elapsed);
      stopWatchResult1 = stopWatch.Elapsed; // storing the result of the first run
      Console.WriteLine("press ENTER to continue");
      Console.ReadKey();
      // running the second part with the optimization 
      Console.Clear();
      
      // getting the structure of the map of rectangles already in memory
      FlyweightMapping currMapping = new FlyweightMapping();
      Console.WriteLine("writing " + numRectangles + " random rectangles with optimized structure... this might takes sometime");
      stopWatch.Reset();
      // starting the time on the print rectangles functionality
      stopWatch.Start();
      for (int i = 0; i < numRectangles; i++)
      {
        int widthRect = rnd.Next(3, 7);
        int heightRect = rnd.Next(3, 7);
        int posW = rnd.Next(1, w - 11);
        int posH = rnd.Next(2, h - 15);
        int consoleColorInd = rnd.Next(0, possibleColors.Length - 1);
        if (!currMapping.GetRectangleFromTheSet(widthRect, heightRect, consoleColorInd, out ConsoleRectangle foundRect))
        {
          ConsoleRectangle currRect = new ConsoleRectangle(widthRect, heightRect, new System.Drawing.Point() { X = posW, Y = posH }, possibleColors[consoleColorInd]);
          // setting the colorID for the rectangle 
          currRect.ColorID = consoleColorInd;
          // adding the rectangle to the set 
          currMapping.AddNewRectToMapper(currRect);
          currRect.Draw();
        }
        else
        {
          // using the rectangle already in memory
          foundRect.Draw();
        }
      }
      // stopping the time on the print rectangles functionality 
      stopWatch.Stop();
      Console.CursorTop = h - 5;
      //Console.CursorLeft = hLocation.X;
      Console.WriteLine("\n\nemployed time: " + stopWatch.Elapsed);
      stopWatchResult2 = stopWatch.Elapsed; // storing the result of the second time elapsed
      Console.ReadKey();

      // comparing the 2 results by the mean of the elapsed timespans
      if(stopWatchResult2 > stopWatchResult1)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("the test not ended well... try with another larger number of rectangles");
      }
      else
      {

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("the test ended well... the elapsed time for the optimized case is less than the first one! (difference " + 
          (stopWatchResult1 - stopWatchResult2)
          + ")");
      }
      Console.ReadKey();
    }
  }
}
