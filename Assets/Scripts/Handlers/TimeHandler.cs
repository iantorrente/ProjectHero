using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Handles the flow of time. 
//handleDayChange() progresses the day by 1 and 
public class TimeHandler : MonoBehaviour {
  private static double days;
  private static double months;
  private static bool isInteger;
  
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

    if (GlobalData.globalData.months == 12) {
      GlobalData.globalData.months = 0;
      handleYearChange();
    }
    GlobalData.globalData.monthName = GlobalData.globalData.monthNameArray[GlobalData.globalData.months];
    Debug.Log(GlobalData.globalData.monthName);
  }

  public static void handleYearChange () {
    GlobalData.globalData.years += 1;
  }

  //TODO: work on week handler for calendar system
  public static void handleWeek () {
    int weekDay = GlobalData.globalData.weekDay;
    GlobalData.globalData.weekDayName = GlobalData.globalData.weekDayNameArray[weekDay];
  }

  public static void handleCycleChange (string action) {
    string dayCycle = GlobalData.globalData.dayCycle;
    if (action == "nap") {
      EnergyHandler.handleEnergy(action);
    } else if (action == "training" && dayCycle != "Midnight") {
      EnergyHandler.handleEnergy(action);
    }

    if (dayCycle == "Morning") {
      GlobalData.globalData.dayCycle = "Afternoon";
    } else if (dayCycle == "Afternoon") {
      GlobalData.globalData.dayCycle = "Evening";
    } else if (dayCycle == "Evening") {
      GlobalData.globalData.dayCycle = "Midnight";
    } else if (dayCycle == "Midnight") {
      handleDayChange(action);
    }

    SceneManager.LoadScene("The City", LoadSceneMode.Single);
  }
}