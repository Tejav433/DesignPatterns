using System.Collections.Generic;

namespace JobScheduler.Models {
  public class InputDetails {
    public int Threads { get; set; }

    public List<Jobs> Jobs { get; set; }
  }
}
