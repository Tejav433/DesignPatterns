using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobScheduler.Models;

namespace JobScheduler.Services {
  class FPS {
    private int _threads;
    private List<Jobs> _jobs;
    public FPS( int threads, List<Jobs> jobs ) {
      _threads = threads;
      _jobs = jobs;
    }

    public void Execute() {
      _jobs.Sort( new Priority() );
    }
  }
  public class Priority: Comparer<Jobs> {
    public override int Compare( Jobs x, Jobs y ) {
      if ( x.Priority.CompareTo( y.Priority ) == 0 ) {
        if ( x.UserType.CompareTo( y.UserType ) == 0 ) {
          return x.Duration.CompareTo( y.Duration );
        }
        return x.UserType.CompareTo( y.UserType );
      }
      return x.Priority.CompareTo( y.Priority );
    }
  }
}
