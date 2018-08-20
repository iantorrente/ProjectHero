using UnityEngine;

//Persists through the day until a new day is started
public class AvailableJobs : MonoBehaviour {
  public static AvailableJobs availableJobs;
  //Want to make this class into the parsed data class
  public ParsedJob[] heroJobsArray { get; set; }
  public CorporateJobs[] corporateJobsArray { get; set; }

  private void Awake() {
    availableJobs = this;
  }
}