using System.Collections.Generic;
using JobScheduler.Models;

namespace JobScheduler.Services {
  class SJF {
    private int _threads;
    private List<Jobs> _jobs;
    public SJF( int threads, List<Jobs> jobs ) {
      _threads = threads;
      _jobs = jobs;

    }

    public void Execute() {

    }

    private void PriortizeTheJobs() {
      _jobs.Sort( new ExecutionTime() );

    }
  }

  public class ExecutionTime: Comparer<Jobs> {
    public override int Compare( Jobs x, Jobs y ) {
      if ( x.Duration.CompareTo( y.Duration ) == 0 ) {

        return x.Priority.CompareTo( y.Priority );
      }
      return x.UserType.CompareTo( y.UserType );

    }
  }
}

