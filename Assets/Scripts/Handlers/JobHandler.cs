using System;
using System.Collections.Generic;
using UnityEngine;

//Handles job interactions and consequences
public class JobHandler : MonoBehaviour {

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

  public static void progressJob () {
    List<ParsedJob> jobs = GlobalData.globalData.jobsToday;

    if (jobs.Count > 1) {
      Debug.Log("You've got two jobs and only enough time to work one of them. You, my friend, are hamboned.");
    } else if (jobs.Count == 1) {
      Debug.Log("You are working on " + jobs[0].title);
      jobs[0].successes = 1;

      if (jobs[0].successes == jobs[0].successesNeeded) {
        StatsHandler.increaseMoney(jobs[0].moneyReward);
        StatsHandler.increasePopularity(jobs[0].renownReward);
        GlobalData.globalData.jobsToday.RemoveAt(0);
        PlayerData.playerData.takenJobs.RemoveAt(0);
        PlayerData.playerData.jobsTaken = 0;

        Debug.Log(jobs[0].onSuccess);
        Debug.Log("You got $" + jobs[0].moneyReward + " and " + jobs[0].renownReward + " renown from accomplishing that job!");
      }
    } else if (jobs.Count == 0) {
      Debug.Log("No jobs to work on");
    }
  }

  public static void checkJobStatus () {
    string date = GlobalData.globalData.date;
    string dayCycle = GlobalData.globalData.dayCycle;
    bool hasWork = false;
    List<ParsedJob> playerJobs = PlayerData.playerData.takenJobs;

    for (int i = 0; i < playerJobs.Count; i++) {
      for (int j = 0; j < playerJobs[i].activeDays.Count; j++) {
        if (playerJobs[i].activeDays[j] == date && playerJobs[i].timeOfDay == dayCycle) {
          Debug.Log("YOU HAVE WORK!");
          hasWork = true;
        } else {
          hasWork = false;
        }
      }

      if (hasWork) {
        GlobalData.globalData.jobsToday.Add(playerJobs[i]);
      }
      
    }
  }
}