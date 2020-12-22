using System;
using System.Threading.Tasks;
using DesignPatterns;

namespace Singleton {
  class Program {

    private static readonly ILogger Logger = DesignPatterns.Logger.GetInstance;
    static void Main( string[] args ) {
      Parallel.Invoke( FirstMethod, SecondMethod );
      Console.ReadKey();
    }

    public static void FirstMethod() {

      Logger.WriteToFile( "500 Internal Error First" );
      Logger.WriteToConsole( "500 Internal Error First" );
    }

    public static void SecondMethod() {

      Logger.WriteToFile( "404 Not Found second" );
      Logger.WriteToConsole( "404 Not Found Second" );
    }
  }
}
