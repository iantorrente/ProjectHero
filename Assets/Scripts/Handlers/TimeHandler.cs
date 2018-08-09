using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Handles the flow of time. 
//handleDayChange() progresses the day by 1 and 
public class TimeHandler : MonoBehaviour {
  static double days;
  static double months;
  static bool isInteger;
  
  public static void handleDayChange (string action) {
    //Run SimulationHandler.handleSimulation() here
    if (action == "sleep") {
      EnergyHandler.handleEnergy(action);
    } else if (action == "nap") {
      EnergyHandler.handleEnergy(action);
    } else if (action == "training") {
      EnergyHandler.handleEnergy(action);
    }
    GlobalData.globalData.days += 1;
    GlobalData.globalData.weekDay += 1;
    GlobalData.globalData.dayCycle = "Morning";

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

    GlobalData.globalData.weekDayName = GlobalData.globalData.WeekDayNameArray[weekDay];
  }

  //Make it so that it takes a string of what type of action was made "training", "job", "sleep", etc. and judge what to do from there
  public static void handleCycleChange (string action) {
    string dayCycle = GlobalData.globalData.dayCycle;
    if (action == "nap") {
      EnergyHandler.handleEnergy(action);
    } else if (action == "training" && dayCycle != "Night") {
      EnergyHandler.handleEnergy(action);
    }

    //Check if the player napped. If they did then give them some energy back
    if (dayCycle == "Morning") {
      GlobalData.globalData.dayCycle = "Afternoon";
    } else if (dayCycle == "Afternoon") {
      GlobalData.globalData.dayCycle = "Night";
    } else if (dayCycle == "Night") {
      handleDayChange(action);
    }

    SceneManager.LoadScene("The City", LoadSceneMode.Single);
  }
}