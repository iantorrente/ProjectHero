using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeHandler : MonoBehaviour {
  double days;
  bool isInteger;
  public void handleDayChange () {
    PlayerData.playerData.days += 1;
    PlayerData.playerData.dayCycle = "Morning";
    handleMonthChange();
    SceneManager.LoadScene("The City", LoadSceneMode.Single);
  }

  public void handleMonthChange () {
    days = (double)PlayerData.playerData.days / 30;
    Debug.Log(days);
    isInteger = unchecked(days == (int)days);
    Debug.Log(isInteger);
    if (isInteger) {
      Debug.Log("Month is changing");
      PlayerData.playerData.months += 1;
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