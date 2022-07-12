using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Model
{
  public class DesignPattern_DEMOStep
  {
    public int ID { get; set; }

    public string Description { get; set; }

    public int Num_Step { get; set; }

    public int DesPattern_ID { get; set; }

    public string Ref_File_RelativePath { get; set; }

    public string Ref_File_Name { get; set; }

    public List<int[]> File_Lines { get; set; }

    public bool See_Effect { get; set; }
  }
}
