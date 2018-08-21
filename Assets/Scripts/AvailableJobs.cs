using UnityEngine;
using System.Collections.Generic;

//Persists through the day until a new day is started
public class AvailableJobs : MonoBehaviour {
  public static AvailableJobs availableJobs;
  public List<ParsedJob> heroJobsArray = new List<ParsedJob>();

  private void Awake() {
    availableJobs = this;
  }
}