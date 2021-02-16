using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobScheduler.Models;

namespace JobScheduler.Services {
  class FCFS {
    private int _threads;
    private List<Jobs> _jobs;
    public FCFS( int threads, List<Jobs> jobs ) {
      _threads = threads;
      _jobs = jobs;
    }

    public void Execute() {
      
    }
  }
}
