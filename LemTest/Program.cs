#region # using *.*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace LemTest
{
  static class Program
  {
    static void Main()
    {
      if (Environment.CommandLine.Contains(".vshost.exe"))
      {
        Console.WriteLine("Press any key to continue . . . ");
        Console.ReadKey(true);
      }
    }
  }
}
