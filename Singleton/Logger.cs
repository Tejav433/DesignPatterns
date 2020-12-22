using System;
using System.IO;
using System.Text;
using System.Threading;

namespace DesignPatterns {

  //Sealed class restricts Inheritance
  public sealed class Logger: ILogger {

    //private static int _counter = 0;

    //Eager Initialization
    //private static Logger _instance = new Logger();


    //Lazy Initialization
    private static readonly Lazy<Logger> Instance = new Lazy<Logger>( () => new Logger() );


    ///<Summary>
    /// Represents a lock that is used to manage access to a resource,
    /// allowing multiple threads for reading or exclusive access for writing
    /// <see href="https://docs.microsoft.com/en-us/dotnet/api/system.threading.readerwriterlockslim?view=netcore-3.1">HERE</see>
    ///</Summary>
    private static readonly ReaderWriterLockSlim Lock = new ReaderWriterLockSlim();


    private Logger() { }


    public static Logger GetInstance => Instance.Value;


    /// <summary>
    /// Writes the data to Log File
    /// </summary>
    /// <param name="data"></param>
    public void WriteToFile( string data ) {
      var fileName = $"Log_{DateTime.Now.ToShortDateString()}";
      var logPath = $"{AppDomain.CurrentDomain.BaseDirectory}\\{fileName}";
      var sb = new StringBuilder();
      sb.AppendLine( $"{DateTime.Now.ToShortDateString()}" );
      sb.AppendLine( data );
      WriteData( sb.ToString(), logPath );

    }

    /// <summary>
    /// Writes the data on Console
    /// </summary>
    /// <param name="data"></param>
    public void WriteToConsole( string data ) {
      Console.WriteLine( data );

    }

    /// <summary>
    /// Writes the data to DB
    /// </summary>
    /// <param name="data"></param>
    public void WriteToDb( string data ) {
      throw new NotImplementedException();
    }


    /// <summary>
    /// Writes the given data to file allows multiple threads
    /// </summary>
    /// <param name="data"></param>
    /// <param name="filePath"></param>
    private static void WriteData( string data, string filePath ) {
      Lock.EnterWriteLock();
      try {
        using ( var fs = new StreamWriter( filePath, true ) ) {

          fs.Write( data );
        }
      }
      finally {
        Lock.ExitWriteLock();
      }
    }
  }


}
