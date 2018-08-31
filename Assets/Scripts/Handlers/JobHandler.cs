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
      parsedJobs[i].lengthOfWork = parseTime("lengthOfWork", jobs[i].time);
      //For active days may want to return a list of dates
      parsedJobs[i].activeDays = parseDate(jobs[i]);
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
  public static List<string> parseDate (Jobs job) {
    List<string> dates = new List<string>();
    int day = GlobalData.globalData.days;
    int weekDay = GlobalData.globalData.weekDay;
    int month = GlobalData.globalData.months;
    int year = GlobalData.globalData.years;
    string activeDays = parseTime("activeDays", job.time);
    string lengthOfWork = parseTime("lengthOfWork", job.time);
    string dateToAdd = "";
    string[] weekDayNames = GlobalData.globalData.weekDayNameArray;

    Regex rx = new Regex(@"[\w]+");
    MatchCollection daysMatch = rx.Matches(activeDays);
    MatchCollection lengthMatch = rx.Matches(lengthOfWork);

    //TODO: STILL NEED TO CHECK THE LENGTH OF THE WORK
    if (daysMatch.Count > 2 && daysMatch[1].ToString() == "to") {
      /* 
        1) get the days between the daysMatch[0] and daysMatch[2]
        2) figure out the length of work
        3) create dates and add them to dates as long as there are dates left
        to add
      */
      
      //IndexOf current day - 7 = the next week day
    } else if (daysMatch.Count > 2 && daysMatch[1].ToString() == "and") {
        int indexOfOne = Array.IndexOf(weekDayNames, daysMatch[0].ToString());
        int indexOfTwo = Array.IndexOf(weekDayNames, daysMatch[2].ToString());
        int firstDay = 0;
        int secondDay = 0;
        Debug.Log("Indexes: " + indexOfOne + " , " + indexOfTwo);

        if (daysMatch[0].ToString() == weekDayNames[weekDay] 
        || daysMatch[2].ToString() == weekDayNames[weekDay]) {
          Debug.Log("Scheduling job for the next week");

          if (daysMatch[0].ToString() == weekDayNames[weekDay] ) {
            firstDay = day + 7;
            secondDay = day + 7 + (7 - indexOfTwo);
          } else if (daysMatch[2].ToString() == weekDayNames[weekDay]) {
            firstDay = day + (7 - indexOfTwo);
            secondDay = day + 7;
          }

          if (day > 21) {
          firstDay = indexOfOne + 1;
          secondDay = indexOfTwo + 1;
          month += 1;

            if (month == 12) {
              year += 1;
            }
          }
        } else if (weekDay > indexOfOne) {
          Debug.Log("Scheduling job for next week because it's too late");
          firstDay = day + (7 - weekDay) + indexOfOne;
          secondDay = day + (7 - weekDay) + indexOfTwo;

          if (day > 21) {
          firstDay = indexOfOne + 1;
          secondDay = indexOfTwo + 1;
          month += 1;

          if (month == 12) {
            year += 1;
          }
        }
        } else {
          Debug.Log("Scheduling job for this week");
          //Make this more efficient
          firstDay = day + (indexOfOne - weekDay);
          secondDay = day + (indexOfTwo - weekDay);
        }

        string dateToAddOne = month.ToString() + "/" + firstDay.ToString() + "/" + year.ToString();
        string dateToAddTwo = month.ToString() + "/" + secondDay.ToString() + "/" + year.ToString();
        dates.Add(dateToAddOne);
        dates.Add(dateToAddTwo);
    } else {
      int randDay = day + UnityEngine.Random.Range(1, 6);
      dateToAdd = month + "/" + randDay.ToString() + "/" + year;
      dates.Add(dateToAdd);
    }

    //If lengthOfWork has day, only schedule it for the day, if it's 
    //week, schedule it for however many weeks are involved, if it's 
    //month then schedule it for however many months

    return dates;
  }

  private string addDate (MatchCollection match) {
    string dateToAdd = "";

    return dateToAdd;
  }
}