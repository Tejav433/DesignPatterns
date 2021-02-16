namespace JobScheduler.Models {
  public class Jobs {
    public string JobName { get; set; }
    public double Duration { get; set; }
    public int Priority { get; set; }
    public double DeadLine { get; set; }
    public User.Types UserType { get; set; }
  }


}
