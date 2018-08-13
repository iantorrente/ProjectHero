using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sets the global persistent data before the player gets into the game
public class DataSetter : MonoBehaviour {
  public static void setGlobalData () {
    //All these numbers are placeholders. They'll be tweaked
    //based on gameplay balances
    GlobalData.globalData.serialKillerActive = false;
    GlobalData.globalData.generalPopulation = Random.Range(450000, 500000);
    GlobalData.globalData.heroPopulation = Random.Range(99, 110);
    GlobalData.globalData.villainPopulation = Random.Range(100, 120);
    GlobalData.globalData.impoverishedPopulation = Random.Range(10000, 12000);
    GlobalData.globalData.criminalPopulation = Random.Range(1000, 3000);
    GlobalData.globalData.homelessPopulation = Random.Range(3000, 6000);
    GlobalData.yearlyBirthRate = 0.019f;
    GlobalData.yearlyDeathRate = 0.008f;
    GlobalData.yearlyViolentCrimeRate = 0.00735f;
    GlobalData.yearlyPropertyCrimeRate = 0.0256f;
    GlobalData.globalData.dailyBirthRate = GlobalData.yearlyBirthRate / 336;
    GlobalData.globalData.dailyDeathRate = GlobalData.yearlyDeathRate / 336;
    GlobalData.globalData.dailyVCRate = GlobalData.yearlyViolentCrimeRate / 336;
    GlobalData.globalData.dailyPCRate = GlobalData.yearlyPropertyCrimeRate / 336;
    GlobalData.globalData.dayCycle = "Morning";
    GlobalData.globalData.weekDayName = "Monday";
    GlobalData.globalData.monthName = "January";
    GlobalData.globalData.seasonName = "Spring";
    GlobalData.globalData.weatherName = "Sunny";
    GlobalData.globalData.weekDayNameArray = new string[] {
      "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", 
      "Saturday", "Sunday"
    };
    GlobalData.globalData.monthNameArray = new string[] {
      "January", "February", "March", "April", "May", "June", 
      "July", "August", "September", "October", "November", "December"
    };
  }

  public static void setPlayerData () {
    PlayerData.playerData.playerPower = Main.childPower;
    PlayerData.playerData.fatherPower = Main.fatherPower;
    PlayerData.playerData.motherPower = Main.motherPower;
    PlayerData.playerData.money = 500;
    PlayerData.playerData.popularityTitle = "Nameless";
    PlayerData.playerData.popularity = 0;
    PlayerData.playerData.baseStamina = 3;
    PlayerData.playerData.stamina = 3;
  }
}