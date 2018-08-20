using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobHandler : MonoBehaviour {
  /*
    Create jobs based on crimes (victims of violent crimes/2
    and victims of proprety crimes/10)

    Should also have jobs based on private/domestic/corporate
    needs, as well as internal hero jobs, like (fight villain, 
    do hero job x, or fight against global disasters)

    Will most likely take generic jobs from a JSON file and then
    interpret the fields to be created as jobs
  */

  /*
    Probably generate jobs each day so that jobs can be reflective
    of what's happening in the game world
  */
  public static void generateAgencyJobs () {
    int maxJobs = 5; //Number of displayed jobs
    int vCJobs = Mathf.RoundToInt(GlobalData.globalData.prevVictimsOfVC / 3);
    int pCJobs = Mathf.RoundToInt(GlobalData.globalData.prevVictimsOfPC / 10);
    int humanitarianJobs;
    int heroJobs = 3;
    int corporateJobs;
    if (GlobalData.globalData.days == 0) {
      vCJobs = 2;
      pCJobs = 1;
    }
    //Only do this if the job data for the day is null
    getRandomHeroJobs(heroJobs);
    Debug.Log("# of violent crimes jobs: " + vCJobs + "\n# of property crimes jobs: " + pCJobs);
  }

  public static void getRandomHeroJobs (int amount) {
    int rIndex = PlayerData.playerData.renownIndex; //Player's renown level
    HeroJobs heroJobs = JobsData.jobsData.heroJobsCollection.heroJobs[rIndex]; //Gets possible jobs from data
    Jobs[] jobArray = new Jobs[amount]; //To store jobs
    int[] randomNumbers = Helpers.getRandomNumbers(amount, 0, heroJobs.jobs.Length);
    for (int i = 0; i < amount; i++) {
      jobArray[i] = heroJobs.jobs[randomNumbers[i]];
      Debug.Log(heroJobs.jobs[randomNumbers[i]].title);
    }

    ParsedJob[] parsedJobs = Helpers.parseHeroJobs(jobArray, jobArray.Length);
    AvailableJobs.availableJobs.heroJobsArray = parsedJobs;
  }

  //Moonlighting gives minimal money compared to hero jobs but they do
  //begin to help train your stats
  public static void handleMoonlight (string job) {
    decimal rMod = PlayerData.playerData.renownModifier;
    decimal sMod = PlayerData.playerData.strengthModifier;
    decimal aMod = PlayerData.playerData.agilityModifier;
    decimal wMod = PlayerData.playerData.willModifier;
    decimal fMod = PlayerData.playerData.fortitudeModifier;
    decimal playerMoney = PlayerData.playerData.money;
    decimal minimumWage = GlobalData.globalData.minimumWage;
    bool hasStamina = Helpers.hasStamina(PlayerData.playerData.stamina);

    if (hasStamina) {
      if (job == "KofeeHausWork") {
        StatsHandler.increaseMoney(Helpers.calculateSalary(minimumWage, aMod)); //Multiply by agility modifier
        StatsHandler.increasePopularity(5 * rMod);
        StatsHandler.increaseStat("agility", 0.10m);
        Debug.Log("You made $" + String.Format("{0:0.00}", Helpers.calculateSalary(minimumWage, aMod)) + " working a shift at the Kofee Haus!");
      } else if (job == "NightclubWork") {
        StatsHandler.increaseMoney(Helpers.calculateSalary(minimumWage, sMod));
        StatsHandler.increasePopularity(5 * rMod);
        StatsHandler.increaseStat("strength", 0.10m);
        Debug.Log("You made $" + String.Format("{0:0.00}", Helpers.calculateSalary(minimumWage, sMod)) + " working a shift at the Nightclub!");     
      } else if (job == "GymWork") {
        StatsHandler.increaseMoney(Helpers.calculateSalary(minimumWage, fMod));
        StatsHandler.increasePopularity(5 * rMod);
        StatsHandler.increaseStat("fortitude", 0.10m);
        Debug.Log("You made $" + String.Format("{0:0.00}", Helpers.calculateSalary(minimumWage, fMod)) + " working a shift at the Gym!"); 
      }
    
      TimeHandler.handleCycleChange("job");
    } else {
      Debug.Log("You're much too tired to be working right now");
    }
    
  }
}