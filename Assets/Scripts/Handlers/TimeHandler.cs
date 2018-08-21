using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Handles the flow of time. 
//handleDayChange() progresses the day by 1 and 
public class TimeHandler : MonoBehaviour {
  
  public static void handleDayChange (string action) {
    //SavePlayerHandler.saveCharacter();
    if (action == "sleep") {
      EnergyHandler.handleEnergy(action);
    } else if (action == "nap") {
      EnergyHandler.handleEnergy(action);
    } else if (action == "training") {
      EnergyHandler.handleEnergy(action);
    }
    Helpers.clearHeroJobsList();
    GlobalData.globalData.days += 1;
    GlobalData.globalData.weekDay += 1;
    GlobalData.globalData.dayCycle = "Morning";

    if (GlobalData.globalData.weekDay == 7) {
      GlobalData.globalData.weekDay = 0;
    }
    handleWeek();
    
    if (GlobalData.globalData.days == 29) {
      handleMonthChange();
    }
    SimulationHandler.handleSimulation();
    //Generate jobs after running the simulation so that
    //jobs can react to global dynamic events
    SceneManager.LoadScene("The City", LoadSceneMode.Single);
  }

  public static void handleWeek () {
    int weekDay = GlobalData.globalData.weekDay;
    GlobalData.globalData.weekDayName = GlobalData.globalData.weekDayNameArray[weekDay];
  }

  public static void handleMonthChange () {
    GlobalData.globalData.months += 1;
    GlobalData.globalData.days = 0;

    if (GlobalData.globalData.months == 12) {
      GlobalData.globalData.months = 0;
      handleYearChange();
    }
    GlobalData.globalData.monthName = GlobalData.globalData.monthNameArray[GlobalData.globalData.months];
    handleSeasonChange();
    Debug.Log(GlobalData.globalData.monthName);
    Debug.Log(GlobalData.globalData.seasonName);
  }

  public static void handleYearChange () {
    GlobalData.globalData.years += 1;
  }

  public static void handleSeasonChange () {
    int month = GlobalData.globalData.months;

    if (month == 0 || month == 1 || month == 2) {
      GlobalData.globalData.seasonName = "Spring";
    } else if (month == 3 || month == 4 || month == 5) {
      GlobalData.globalData.seasonName = "Summer";
    } else if (month == 6 || month == 7 || month == 8) {
      GlobalData.globalData.seasonName = "Autumn";
    } else if (month == 9 || month == 10 || month == 11) {
      GlobalData.globalData.seasonName = "Winter";
    }
  }

  public static void handleCycleChange (string action) {
    string dayCycle = GlobalData.globalData.dayCycle;
    if (action == "nap") {
      EnergyHandler.handleEnergy(action);
    } else if (action == "job") {
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