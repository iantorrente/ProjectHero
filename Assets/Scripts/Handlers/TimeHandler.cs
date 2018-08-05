using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeHandler : MonoBehaviour {
  double days;
  double months;
  bool isInteger;
  public void handleDayChange () {
    PlayerData.playerData.days += 1;
    PlayerData.playerData.dayCycle = "Morning";
    handleMonthChange();
    SceneManager.LoadScene("The City", LoadSceneMode.Single);
  }

  public void handleMonthChange () {
    days = (double)PlayerData.playerData.days / 30;
    isInteger = unchecked(days == (int)days);
    if (isInteger) {
      Debug.Log("Month is changing");
      PlayerData.playerData.months += 1;
    }
    handleYearChange();
  }

  public void handleYearChange () {
    months = (double)PlayerData.playerData.months / 12;
    isInteger = unchecked(months == (int)months);
    Debug.Log(months);
    if (isInteger && months != 0) {
      Debug.Log("Year is changing");
      PlayerData.playerData.years += 1;
      PlayerData.playerData.months = 0;
    }
  }

  public void handleCycleChange () {
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