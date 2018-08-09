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
  public int heroPopulation = 107;
  public int villainPopulation = 111;
  public int impoverishedPopulation;
  public int criminalPopulation;
  public int homelessPopulation;
  public static float yearlyBirthRate = 0.019f;
  public static float yearlyDeathRate = 0.008f;
  public float dailyBirthRate = yearlyBirthRate / 112; //Daily
  public float dailyDeathRate = yearlyDeathRate / 112; //Daily
  public float crimeRate;
  public string dayCycle = "Morning";
  public string weekDayName = "Monday";

  void Awake () {
    if (globalData == null) {
      DontDestroyOnLoad(gameObject);
      globalData = this;
    } else if (globalData != this) {
      Destroy(gameObject);
    }
  }
}