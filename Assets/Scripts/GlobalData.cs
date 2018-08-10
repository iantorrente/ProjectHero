using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Hold all of the global variables in here, things like population, death rates, prices, healthiness levels of The City/its districts, hero populations, crime rate, etc.
public class GlobalData : MonoBehaviour {
  public static GlobalData globalData;
  public int years = 0;
  public int months = 0;
  public int weekDay = 0;
  public int days = 0;
  public int generalPopulation = 500000; //Arbitrary values for now 
  public int heroPopulation = 107; //Arbitrary values for now 
  public int villainPopulation = 111; //Arbitrary values for now 
  public int impoverishedPopulation;
  public int criminalPopulation;
  public int homelessPopulation;
  public int victimsOfVC;
  public int victimsOfPC;
  public static float yearlyBirthRate = 0.019f; //Based on world
  public static float yearlyDeathRate = 0.008f; //Based on world
  public static float yearlyViolentCrimeRate = 0.00735f; //Based on Los Angeles
  public static float yearlyPropertyCrimeRate = 0.0256f; //Based on Los Angeles
  public float dailyBirthRate = yearlyBirthRate / 112; 
  public float dailyDeathRate = yearlyDeathRate / 112; 
  public float dailyVCRate = yearlyViolentCrimeRate / 112;
  public float dailyPCRate = yearlyPropertyCrimeRate / 112;
  public string dayCycle = "Morning";
  public string weekDayName = "Monday";
  public string[] WeekDayNameArray = new string[] {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};

  void Awake () {
    if (globalData == null) {
      DontDestroyOnLoad(gameObject);
      globalData = this;
    } else if (globalData != this) {
      Destroy(gameObject);
    }
  }
}