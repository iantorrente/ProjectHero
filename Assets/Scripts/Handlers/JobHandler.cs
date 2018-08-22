using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class JobHandler : MonoBehaviour {
  
  /*
    Create jobs based on crimes (victims of violent crimes/2
    and victims of proprety crimes/10).
    Probably generate jobs each day so that jobs can be reflective
    of what's happening in the game world
  */
  public static void generateAgencyJobs () {
    GlobalData.globalData.jobsGenerated = true;
    int maxJobs = 8; //Number of displayed jobs
    //It's possible for jobs for a day to be zero. Do we want this?
    int heroJobs = UnityEngine.Random.Range(2, maxJobs);
    int humanJobs = UnityEngine.Random.Range(0, (maxJobs - heroJobs));
    int corpJobs = UnityEngine.Random.Range(0, (maxJobs - (heroJobs + humanJobs)));

    //Only do this if the job data for the day is null
    getRandomHeroJobs(heroJobs);
    getRandomCorpJobs(corpJobs);
    getRandomHumanJobs(humanJobs);

    for (int i = 0; i < AvailableJobs.availableJobs.heroJobsArray.Count; i++) {
      Debug.Log(AvailableJobs.availableJobs.heroJobsArray[i].title);
    }
  }

  public static void getRandomHeroJobs (int amount) {
    int rIndex = PlayerData.playerData.renownIndex; //Player's renown level
    HeroJobs heroJobs = JobsData.jobsData.heroJobsCollection.heroJobs[rIndex]; //Gets possible jobs from data
    Jobs[] jobArray = new Jobs[amount]; //To store jobs
    int[] randomNumbers = Helpers.getRandomNumbers(amount, 0, heroJobs.jobs.Length);
    for (int i = 0; i < amount; i++) {
      jobArray[i] = heroJobs.jobs[randomNumbers[i]];
    }
    addJobs(jobArray);
  }

  public static void getRandomCorpJobs (int amount) {
    Jobs[] corpJobs = JobsData.jobsData.corpJobsCollection.jobs;
    Jobs[] jobArray = new Jobs[amount];
    int[] randomNumbers = Helpers.getRandomNumbers(amount, 0, corpJobs.Length);
    for (int i = 0; i < amount; i++) {
      jobArray[i] = corpJobs[randomNumbers[i]];
    }
    addJobs(jobArray);    
  }

  public static void getRandomHumanJobs (int amount) {
    Jobs[] humanJobs = JobsData.jobsData.humanJobsCollection.jobs;
    Jobs[] jobArray = new Jobs[amount];
    int[] randomNumbers = Helpers.getRandomNumbers(amount, 0, humanJobs.Length);
    for (int i = 0; i < amount; i++) {
      jobArray[i] = humanJobs[randomNumbers[i]];
    }
    addJobs(jobArray);    
  }

  private static void addJobs (Jobs[] job) {
    ParsedJob[] parsedJobs = parseHeroJobs(job, job.Length);
    for (int i = 0; i < parsedJobs.Length; i++) {
      AvailableJobs.availableJobs.heroJobsArray.Add(parsedJobs[i]);
    }
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

  public static ParsedJob[] parseHeroJobs (Jobs[] jobs, int amount) {
    ParsedJob[] parsedJobs = new ParsedJob[amount];
    
    for (int i = 0; i < amount; i++) {
      parsedJobs[i] = new ParsedJob();
      parsedJobs[i].type = jobs[i].type;
      parsedJobs[i].title = jobs[i].title;
      parsedJobs[i].description = jobs[i].description;
      parsedJobs[i].onSuccess = jobs[i].onSuccess;
      parsedJobs[i].onFail = jobs[i].onFail;
      parsedJobs[i].successesNeeded = jobs[i].successesNeeded;
      parsedJobs[i].moneyReward = parseRewards("money", jobs[i].reward);
      parsedJobs[i].renownReward = parseRewards("renown", jobs[i].reward);
      parsedJobs[i].timeOfDay = parseTime("timeOfDay", jobs[i].time);
      parsedJobs[i].activeDays = parseTime("activeDays", jobs[i].time);
      parsedJobs[i].lengthOfWork = parseTime("lengthOfWork", jobs[i].time);
    }

    return parsedJobs;
  }

  //TODO: Turn this into a generic, dynamic parser so that whatever is put in it can parse
  //without any issues, even if some fields are missing
  public static int parseRewards (string type, string stringReward) {
    int reward = 0;
    Regex rx = new Regex(@"(0|[1-9][0-9]*)");
    MatchCollection matches = rx.Matches(stringReward);
    int[] rewardArray = new int[matches.Count];
    for (int i = 0; i < matches.Count; i++) {
      rewardArray[i] = Int32.Parse(matches[i].ToString());
    }

    if (type == "money") {
      reward = UnityEngine.Random.Range(rewardArray[0], rewardArray[1]);
    } else if (type == "renown") {
      reward = UnityEngine.Random.Range(rewardArray[2], rewardArray[3]);
    }

    return reward;
  }

  //Splits json time into 3 separate strings
  public static string parseTime (string type, string stringTime) {
    string time = "";
    string[] timeArray = stringTime.Split(',');

    if (type == "timeOfDay") {
      time = timeArray[0];
    } else if (type == "activeDays") {
      time = timeArray[1];
    } else if (type == "lengthOfWork") {
      time = timeArray[2];
    }
    return time;
  }

  //Returns a list of dates formatted dd/mm/yyyy
  public static List<int> parseDate (ParsedJob job) {
    List<int> dates = new List<int>();
    string activeDays = job.activeDays;
    string lengthOfWork = job.lengthOfWork;

    //If activeDays has 'to' then get every date between the first string and the second string
    Regex cycleRegex = new Regex(@"");

    //If lengthOfWork has day, only schedule it for the day, if it's week, schedule it for however
    //many weeks are involved, if it's month then schedule it for however many months
    Regex lengthRegex = new Regex(@"");

    return dates;
  }
}