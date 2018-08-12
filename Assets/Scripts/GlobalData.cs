using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Hold all of the global variables in here, things like population, death rates, prices, healthiness levels of The City/its districts, hero populations, crime rate, etc.
public class GlobalData : MonoBehaviour {
  public static GlobalData globalData;
  public int years { get; set; }
  public int months;
  public int weekDay { get; set; }
  public int days;
  public int generalPopulation { get; set; } //Arbitrary values for now 
  public int heroPopulation { get; set; } //Arbitrary values for now 
  public int villainPopulation { get; set; } //Arbitrary values for now 
  public int impoverishedPopulation { get; set; }
  public int criminalPopulation { get; set; }
  public int homelessPopulation { get; set; }
  public int victimsOfVC { get; set; }
  public int victimsOfPC { get; set; }
  public static float yearlyBirthRate { get; set; } //Based on world
  public static float yearlyDeathRate { get; set; } //Based on world
  public static float yearlyViolentCrimeRate { get; set; } //Based on Los Angeles
  public static float yearlyPropertyCrimeRate { get; set; } //Based on Los Angeles
  public float dailyBirthRate { get; set; }
  public float dailyDeathRate { get; set; }
  public float dailyVCRate { get; set; }
  public float dailyPCRate { get; set; }
  public string dayCycle { get; set; }
  public string weekDayName { get; set; }
  public string monthName { get; set; }
  public string[] weekDayNameArray { get; set; }
  public string[] monthNameArray { get; set; }

  void Awake () {
    if (globalData == null) {
      DontDestroyOnLoad(gameObject);
      globalData = this;
    } else if (globalData != this) {
      Destroy(gameObject);
    }
  }
}