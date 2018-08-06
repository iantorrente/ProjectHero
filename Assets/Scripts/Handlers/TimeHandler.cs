using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeHandler : MonoBehaviour {
  public static EnergyHandler EnergyHandler;
  double days;
  double months;
  bool isInteger;
  
  public void handleDayChange () {
    PlayerData.playerData.days += 1;
    PlayerData.playerData.dayCycle = "Morning";
    days = (double)PlayerData.playerData.days / 28;
    isInteger = unchecked(days == (int)days);
    if (isInteger) {
      handleMonthChange();
    }
    SceneManager.LoadScene("The City", LoadSceneMode.Single);
  }

  public void handleMonthChange () {
    Debug.Log("Month is changing");
    PlayerData.playerData.months += 1;
    PlayerData.playerData.days = 0;
    months = (double)PlayerData.playerData.months / 12;
    isInteger = unchecked(months == (int)months);
    if (isInteger && months != 0) {
      handleYearChange();
    }

  }

  public void handleYearChange () {
    PlayerData.playerData.years += 1;
    PlayerData.playerData.months = 0;
  }

  //TODO: work on week handler for calendar system
  public static void handleWeek () {
  }

  //Can't be used by unity components if it's static. Check into it
  public void handleCycleChange () {
    if (PlayerData.playerData.dayCycle == "Morning") {
      PlayerData.playerData.dayCycle = "Afternoon";
    } else if (PlayerData.playerData.dayCycle == "Afternoon") {
      PlayerData.playerData.dayCycle = "Night";
    } else if (PlayerData.playerData.dayCycle == "Night") {
      PlayerData.playerData.days += 1;
      PlayerData.playerData.dayCycle = "Morning";
    }
    //EnergyHandler.handleEnergy();
    SceneManager.LoadScene("The City", LoadSceneMode.Single);
  }
}