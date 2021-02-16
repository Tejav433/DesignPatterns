using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobScheduler.Models;

namespace JobScheduler.Services {
  class EDF {
    private int _threads;
    private List<Jobs> _jobs;
    public EDF( int threads, List<Jobs> jobs ) {
      _threads = threads;
      _jobs = jobs;
    }

    public void Execute() {
      _jobs.Sort( new Dealine() );
    }

  }
  public class Dealine: Comparer<Jobs> {
    public override int Compare( Jobs x, Jobs y ) {
      if ( x.DeadLine.CompareTo( y.DeadLine ) == 0 ) {
        if ( x.Priority.CompareTo( y.Priority ) == 0 ) {
          return x.Duration.CompareTo( y.Duration );
        }
        return x.Priority.CompareTo( y.Priority );
      }
      return x.DeadLine.CompareTo( y.DeadLine );
    }
  }
}
