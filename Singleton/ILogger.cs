using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton {
  public interface ILogger {

    void WriteToFile(string data);
    void WriteToConsole(string data);
    void WriteToDb(string data);
  }
}
