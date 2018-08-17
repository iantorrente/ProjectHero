using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles player healthiness and illnesses
public class HealthinessHandler : MonoBehaviour {
  static int hIndex { get; set; }

  public static void handleHealthiness (string action) {
    hIndex = PlayerData.playerData.healthinessIndex;
    string[] healthArray = new string[] {
      "Healthy", "Strained", "Weak", "Exhausted"
    };
    string[] sicknessArray = new string[] {
      "Cold", "Flu", "Bronchitis", "Migraine"
    };

    if (action == "reduce") {
      hIndex -= 1;
    } else if (action == "increase") {
      hIndex += 1;
    }

    string healthiness = healthArray[hIndex];
    PlayerData.playerData.healthiness = healthiness;
  }
}