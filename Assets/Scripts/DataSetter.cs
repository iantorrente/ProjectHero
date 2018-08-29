using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//Sets the global persistent data before the player gets into the game
public class DataSetter : MonoBehaviour {
  public static void setGlobalData () {
    //All these numbers are placeholders. They'll be tweaked
    //based on gameplay balances
    GlobalData.globalData.serialKillerActive = false;
    GlobalData.globalData.jobsGenerated = false;
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
    GlobalData.globalData.minimumWage = (decimal)13.25;
    GlobalData.globalData.dayCycle = "Morning";
    GlobalData.globalData.weekDayName = "Monday";
    GlobalData.globalData.monthName = "January";
    GlobalData.globalData.seasonName = "Spring";
    GlobalData.globalData.weatherName = "Sunny";
    GlobalData.globalData.days = 1;
    GlobalData.globalData.months = 1;
    GlobalData.globalData.years = 2091;
    GlobalData.globalData.date = "1/1/2091";
    
    //Don't need to store this in persistent data
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
    PlayerData.playerData.maxJobs = 1;
    PlayerData.playerData.fans = 0;
    PlayerData.playerData.money = 500;
    PlayerData.playerData.popularityTitle = "Nameless";
    PlayerData.playerData.popularityExperience = 0;
    PlayerData.playerData.baseStamina = 3;
    PlayerData.playerData.stamina = 3;
    PlayerData.playerData.healthinessIndex = 0;
    PlayerData.playerData.flatModifier = (decimal)0.0275;
    PlayerData.playerData.renownModifier = (decimal)0.05;
    PlayerData.playerData.strengthModifier = Main.childPower.strength * PlayerData.playerData.flatModifier;
    PlayerData.playerData.agilityModifier = Main.childPower.agility * PlayerData.playerData.flatModifier;
    PlayerData.playerData.willModifier = Main.childPower.will * PlayerData.playerData.flatModifier;
    PlayerData.playerData.fortitudeModifier = Main.childPower.fortitude * PlayerData.playerData.flatModifier;
  }
}