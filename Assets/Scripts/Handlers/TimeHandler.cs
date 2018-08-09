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
    //Run SimulationHandler.handleSimulation() here
    EnergyHandler.handleEnergy("sleep");
    GlobalData.globalData.days += 1;
    GlobalData.globalData.dayCycle = "Morning";
    GlobalData.globalData.weekDay += 1;

    if (GlobalData.globalData.weekDay == 7) {
      GlobalData.globalData.weekDay = 0;
    }
    handleWeek();
    
    days = (double)GlobalData.globalData.days / 28;
    isInteger = unchecked(days == (int)days);
    if (isInteger) {
      handleMonthChange();
    }
    SimulationHandler.handleSimulation();
    SceneManager.LoadScene("The City", LoadSceneMode.Single);
  }

  public static void handleMonthChange () {
    GlobalData.globalData.months += 1;
    GlobalData.globalData.days = 0;
    months = (double)GlobalData.globalData.months / 12;
    isInteger = unchecked(months == (int)months);
    if (isInteger && months != 0) {
      handleYearChange();
    }

  }

  public static void handleYearChange () {
    GlobalData.globalData.years += 1;
    GlobalData.globalData.months = 0;
  }

  //TODO: work on week handler for calendar system
  public static void handleWeek () {
    int weekDay = GlobalData.globalData.weekDay;
    string[] weekDayNameArray = new string[] {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};

    GlobalData.globalData.weekDayName = weekDayNameArray[weekDay];
    Debug.Log(GlobalData.globalData.weekDayName);
  }

  //Make it so that it takes a string of what type of action was made "training", "job", "sleep", etc. and judge what to do from there
  public static void handleCycleChange (string action) {
    if (action == "nap") {
      EnergyHandler.handleEnergy(action);
    }

    //Check if the player napped. If they did then give them some energy back
    if (GlobalData.globalData.dayCycle == "Morning") {
      GlobalData.globalData.dayCycle = "Afternoon";
    } else if (GlobalData.globalData.dayCycle == "Afternoon") {
      GlobalData.globalData.dayCycle = "Night";
    } else if (GlobalData.globalData.dayCycle == "Night") {
      GlobalData.globalData.days += 1;
      GlobalData.globalData.weekDay += 1;
      GlobalData.globalData.dayCycle = "Morning";
      handleWeek();
    }

    SceneManager.LoadScene("The City", LoadSceneMode.Single);
  }
}