using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DesignPatterns.Behavioural.Strategy
{
  public class Animal_Implementation2
  {
    private string _name;
    private double _height;
    private int _weight;
    private string _favFood;
    private double _speed;
    private string _sound;

    public Flys FlyingType;

    public string Name { get => _name; set => _name = value; }

    public double Height { get => _height; set => _height = value; }

    private int Weight { get => _weight; set => _weight = value; }

    private string FavFood { get => _favFood; set => _favFood = value; }

    private double Speed { get => _speed; set => _speed = value; }

    private string Sound { get => _sound; set => _sound = value; }
  }
}
