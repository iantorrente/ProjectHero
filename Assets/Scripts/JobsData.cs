using UnityEngine;

public class JobsData : MonoBehaviour {
  public static JobsData jobsData;
  public HeroJobsCollection heroJobsCollection { get; set; }

  void Awake () {
    if (jobsData == null) {
      DontDestroyOnLoad(gameObject);
      jobsData = this;
    } else if (jobsData != this) {
      Destroy(gameObject);
    }
  }
}