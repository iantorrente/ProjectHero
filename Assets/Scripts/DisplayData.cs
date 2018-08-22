using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayData : MonoBehaviour {
  //Gets initialized every time player goes into The City scene. Might want to change it
  private void initialize () {
    string activeScene = SceneManager.GetActiveScene().name;
    if (activeScene == "Home") {
      displayPlayerStats();
    } else if (activeScene == "City Hall") {
      displayGlobalStats();
    } else if (activeScene == "Agency Jobs") {
      displayAgencyJobs();
    } else if (activeScene == "Agency Display Job") {
      displayJobInfo();
    } else {
      displayInformation();
    }
  }

  private void displayInformation () {
    GameObject.Find("Time").GetComponent<Text>().text = ((GlobalData.globalData.weekDayName).ToUpper() + " " + GlobalData.globalData.dayCycle).ToUpper();
    GameObject.Find("Stamina").GetComponent<Text>().text = ("Stamina: " + PlayerData.playerData.stamina);
  }

  private void displayPlayerStats () {
    ChildPower playerPower = PlayerData.playerData.playerPower;
    List<ParsedJob> jobs = PlayerData.playerData.takenJobs;
    string jobsString = "";
    for (int i = 0; i < jobs.Count; i++) {
      jobsString += i+1 + ") " + jobs[i].title + " ";
    }
		GameObject.Find("Player Data Text").GetComponent<Text>().text = (
      playerPower.powerName + "\nSTATS:"
      + "\nStrength: " + (int)playerPower.strength
      + "\nAgility: " + (int)playerPower.agility
      + "\nWill: " + (int)playerPower.will
      + "\nFortitude: " + (int)playerPower.fortitude
      + "\nTime: " + GlobalData.globalData.years + " years, " + GlobalData.globalData.months + " months, " + GlobalData.globalData.days + " days"
      + "\nMoney: $" + String.Format("{0:0.00}", PlayerData.playerData.money)
      + "\nPopularity: " + PlayerData.playerData.popularityTitle
      + "\n\nTaken Jobs: " + jobsString
    );
  }

  private void displayGlobalStats () {
    int popBirth = (int)(GlobalData.globalData.generalPopulation * GlobalData.globalData.dailyBirthRate);
    int popDeath = (int)(GlobalData.globalData.generalPopulation * GlobalData.globalData.dailyDeathRate);
    GameObject.Find("Global Stats").GetComponent<Text>().text = (
      "Population: " + GlobalData.globalData.generalPopulation
      + "\nRegistered Heroes: " + GlobalData.globalData.heroPopulation
      + "\nKnown Villains: " + GlobalData.globalData.villainPopulation
      + "\nRegistered Criminals: " + GlobalData.globalData.criminalPopulation
      + "\nCitizens Considered Impoverished: " + GlobalData.globalData.impoverishedPopulation
      + "\nRegistered Homeless: " + GlobalData.globalData.homelessPopulation
      + "\nBirths per day: " + popBirth
      + "\nDeaths per day: " + popDeath
      + "\nYearly Violent Crime Rate per 1,000 Residents: " + GlobalData.yearlyViolentCrimeRate * 100 + "%"
      + "\nYearly Property Crime Rate per 1,000 Residents: " + GlobalData.yearlyPropertyCrimeRate * 100 + "%"
      + "\nVictims of Violent Crimes: " + GlobalData.globalData.victimsOfVC
      + "\nVictims of Property Crimes: " + GlobalData.globalData.victimsOfPC

    );
  }

  private void displayAgencyJobs () {
    //TODO: dynamically display buttons only when they're needed
    for (int i = 0; i < AvailableJobs.availableJobs.heroJobsArray.Count; i++) {
      GameObject.Find(i.ToString()).GetComponentsInChildren<Text>()[0].text = (
        AvailableJobs.availableJobs.heroJobsArray[i].title
      );
    }
  }

  public static void displayJobInfo () {
    string pressedButton = GlobalData.globalData.pressedButton;
    getJob(Int32.Parse(pressedButton));
  }

  private static void getJob (int index) {
    ParsedJob job = AvailableJobs.availableJobs.heroJobsArray[index];
    PlayerData.playerData.consideredJob = job;
    GameObject.Find("Job Title").GetComponent<Text>().text = (
        job.title
      );
    GameObject.Find("Job Description").GetComponent<Text>().text = (
      job.description
      + "\n\nJob Type: " + job.type
      + "\nRewards: $" + job.moneyReward + " and " + job.renownReward + " renown"
      +"\nThe job will be every " + job.timeOfDay + ", " + job.activeDays + " for " + job.lengthOfWork
    );
  }

	// Use this for initialization
	void Awake () {
    initialize();
  }
}
