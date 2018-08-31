using System.Collections.Generic;

public class ParsedJob {
  public string type { get; set; }
  public string title { get; set; }
  public string description { get; set; }
  public string onSuccess { get; set; }
  public string onFail { get; set; }
  public int successesNeeded { get; set; }
  public int successes { get; set; }
  public int moneyReward { get; set; }
  public int renownReward { get; set; }
  public string timeOfDay { get; set; }
  public List<string> activeDays = new List<string>();
  public string lengthOfWork { get; set; }
}