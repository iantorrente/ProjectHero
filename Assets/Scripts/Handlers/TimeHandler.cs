using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeHandler : MonoBehaviour {
  static double days;
  static double months;
  static bool isInteger;
  
  public static void handleDayChange () {
    PlayerData.playerData.days += 1;
    PlayerData.playerData.dayCycle = "Morning";
    days = (double)PlayerData.playerData.days / 28;
    isInteger = unchecked(days == (int)days);
    if (isInteger) {
      handleMonthChange();
    }
    EnergyHandler.handleEnergy("sleep");
    SceneManager.LoadScene("The City", LoadSceneMode.Single);
  }

  public static void handleMonthChange () {
    PlayerData.playerData.months += 1;
    PlayerData.playerData.days = 0;
    months = (double)PlayerData.playerData.months / 12;
    isInteger = unchecked(months == (int)months);
    if (isInteger && months != 0) {
      handleYearChange();
    }

  }

  public static void handleYearChange () {
    PlayerData.playerData.years += 1;
    PlayerData.playerData.months = 0;
  }

  //TODO: work on week handler for calendar system
  public static void handleWeek () {
  }

  //Make it so that it takes a string of what type of action was made "training", "job", "sleep", etc. and judge what to do from there
  public static void handleCycleChange (string action) {
    if (action == "nap") {
      EnergyHandler.handleEnergy(action);
    }

    //Check if the player napped. If they did then give them some energy back
    if (PlayerData.playerData.dayCycle == "Morning") {
      PlayerData.playerData.dayCycle = "Afternoon";
    } else if (PlayerData.playerData.dayCycle == "Afternoon") {
      PlayerData.playerData.dayCycle = "Night";
    } else if (PlayerData.playerData.dayCycle == "Night") {
      PlayerData.playerData.days += 1;
      PlayerData.playerData.dayCycle = "Morning";
    }

    SceneManager.LoadScene("The City", LoadSceneMode.Single);
  }
}