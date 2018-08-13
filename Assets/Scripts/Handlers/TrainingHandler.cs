using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Might want to rework this flow. It gets convoluted and too complex
public class TrainingHandler : MonoBehaviour {
  public static bool tooPoor { get; set; }
  public static void handleTraining (string action) {
    int stamina = PlayerData.playerData.stamina;
    string activeScene = SceneManager.GetActiveScene().name;
    tooPoor = false;
    
    if (stamina > 0) {
      if (action == "strength") {
        PlayerData.playerData.playerPower.strength += handleTrainingLevel(activeScene);
        Debug.Log("Strength" + PlayerData.playerData.playerPower.strength);
      } else if (action == "agility") {
        PlayerData.playerData.playerPower.agility += handleTrainingLevel(activeScene);
        Debug.Log("Agility" + PlayerData.playerData.playerPower.agility);
      } else if (action == "fortitude") {
        PlayerData.playerData.playerPower.fortitude += handleTrainingLevel(activeScene);
        Debug.Log("Fortitude" + PlayerData.playerData.playerPower.fortitude);
      } else if (action == "will") {
        //Will might just need to be handled differently than the physical ones
        PlayerData.playerData.playerPower.will += handleTrainingLevel(activeScene);
        Debug.Log(PlayerData.playerData.playerPower.will);
      }

      if (!tooPoor) {
        TimeHandler.handleCycleChange("training");
      } else {
        Debug.Log("You\'re too poor, kid");
      }
    } else if (stamina == 0) {
      Debug.Log("Now is not the time to be training, " + PlayerData.playerData.playerPower.powerName);
    }
  }

  //Have to think of a better way to do this
  private static decimal handleTrainingLevel (string scene) {
    decimal value = 0;
    decimal money = PlayerData.playerData.money;
    if (scene == "Gym Free") {
      value = 0.25m;
    } else if (scene == "Gym Cheap" && !(money - 15 < 0)) {
      value = 0.35m;
      PlayerData.playerData.money -= 15m;
    } else if (scene == "Gym Normal" && !(money - 45 < 0)) {
      value = 0.65m;
      PlayerData.playerData.money -= 45m;
    } else if (scene == "Gym Expensive" && !(money - 100 < 0)) {
      value = 1;
      PlayerData.playerData.money -= 100m;
    } else {
      tooPoor = true;
    }
    return value;
  }
}
