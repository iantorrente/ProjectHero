using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingHandler : MonoBehaviour {
  public static void handleTraining (string action) {
    int stamina = PlayerData.playerData.stamina;
    
    if (stamina > 0) {
      if (action == "strength") {
        PlayerData.playerData.playerPower.strength += 1;
      } else if (action == "agility") {
        PlayerData.playerData.playerPower.agility += 1;
      } else if (action == "fortitude") {
        PlayerData.playerData.playerPower.fortitude += 1;
      }
      TimeHandler.handleCycleChange("training");
      EnergyHandler.handleEnergy("training");
    } else if (stamina == 0) {
      Debug.Log("Rest up, " + PlayerData.playerData.playerPower.powerName);
    }
  }
}
