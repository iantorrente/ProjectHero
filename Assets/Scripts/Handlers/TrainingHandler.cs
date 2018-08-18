using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Might want to rework this flow. It gets convoluted and too complex
public class TrainingHandler : MonoBehaviour {
  public static bool tooPoor { get; set; }

  public static void handleTraining (string action) {
    int stamina = PlayerData.playerData.stamina;
    bool hasStamina = Helpers.hasStamina(stamina);
    string activeScene = SceneManager.GetActiveScene().name;
    tooPoor = false;
    
    if (stamina > 0) {
      if (action == "strength") {
        StatsHandler.increaseStat(action, handleTrainingLevel(activeScene));
      } else if (action == "agility") {
        StatsHandler.increaseStat(action, handleTrainingLevel(activeScene));
      } else if (action == "fortitude") {
        StatsHandler.increaseStat(action, handleTrainingLevel(activeScene));
      } else if (action == "will") {
        //Will might just need to be handled differently than the physical ones
        StatsHandler.increaseStat(action, handleTrainingLevel(activeScene));
      }

      if (!tooPoor) {
        TimeHandler.handleCycleChange("training");
      } else {
        Debug.Log("You\'re too poor, kid");
      }
    } else if (!hasStamina) {
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
      StatsHandler.decreaseMoney(15m);
    } else if (scene == "Gym Normal" && !(money - 45 < 0)) {
      value = 0.65m;
      StatsHandler.decreaseMoney(45m);
    } else if (scene == "Gym Expensive" && !(money - 100 < 0)) {
      value = 1;
      StatsHandler.decreaseMoney(100m);
    } else {
      tooPoor = true;
    }
    return value;
  }
}
