using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

//Generates jobs
public class JobGenerator : MonoBehaviour {
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

  private static void getRandomHeroJobs (int amount) {
    int rIndex = PlayerData.playerData.renownIndex; //Player's renown level
    HeroJobs heroJobs = JobsData.jobsData.heroJobsCollection.heroJobs[rIndex]; //Gets possible jobs from data
    Jobs[] jobArray = new Jobs[amount]; //To store jobs
    int[] randomNumbers = Helpers.getRandomNumbers(amount, 0, heroJobs.jobs.Length);
    
    for (int i = 0; i < amount; i++) {
      jobArray[i] = heroJobs.jobs[randomNumbers[i]];
    }
    addJobs(jobArray);
  }

  private static void  getRandomCorpJobs (int amount) {
    Jobs[] corpJobs = JobsData.jobsData.corpJobsCollection.jobs;
    Jobs[] jobArray = new Jobs[amount];
    int[] randomNumbers = Helpers.getRandomNumbers(amount, 0, corpJobs.Length);
    
    for (int i = 0; i < amount; i++) {
      jobArray[i] = corpJobs[randomNumbers[i]];
    }
    addJobs(jobArray);    
  }

  private static void getRandomHumanJobs (int amount) {
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

  private static ParsedJob[] parseHeroJobs (Jobs[] jobs, int amount) {
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
  private static decimal parseRewards (string type, string stringReward) {
    decimal rModifier = PlayerData.playerData.renownModifier;
    decimal rawReward = 0;
    decimal reward = 0;
    Regex rx = new Regex(@"(0|[1-9][0-9]*)");
    MatchCollection matches = rx.Matches(stringReward);
    int[] rewardArray = new int[matches.Count];
    
    for (int i = 0; i < matches.Count; i++) {
      rewardArray[i] = Int32.Parse(matches[i].ToString());
    }

    if (type == "money") {
      rawReward = UnityEngine.Random.Range(rewardArray[0], rewardArray[1]);
      reward = rawReward + (rawReward * rModifier);
    } else if (type == "renown") {
      reward = UnityEngine.Random.Range(rewardArray[2], rewardArray[3]);
    }

    return reward;
  }

  //Splits json time into 3 separate strings
  private static string parseTime (string type, string stringTime) {
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

  //Returns a list of dates formatted d/m/yyyy
  private static List<string> parseDate (Jobs job) {
    List<string> dates = new List<string>();
    int day = GlobalData.globalData.days;
    int weekDay = GlobalData.globalData.weekDay;
    int month = GlobalData.globalData.months;
    int year = GlobalData.globalData.years;
    string activeDays = parseTime("activeDays", job.time);
    string lengthOfWork = parseTime("lengthOfWork", job.time);
    string dateToAdd = "";
    string[] weekDayNames = GlobalData.globalData.weekDayNameArray;

    //Takes out the word identifiers in the time string
    Regex rx = new Regex(@"[\w]+");
    MatchCollection daysMatch = rx.Matches(activeDays);
    MatchCollection lengthMatch = rx.Matches(lengthOfWork);
    int length = 0;

    //Checks how many weeks the job is for
    if (lengthMatch[1].ToString() == "week") {
      length = 1 * Int32.Parse(lengthMatch[0].ToString());
    } else if (lengthMatch[1].ToString() == "month" || lengthMatch[1].ToString() == "months") {
      length = 4 * Int32.Parse(lengthMatch[0].ToString());
    }

    //TODO: STILL NEED TO CHECK THE LENGTH OF THE WORK
    //dayToAdd + (7 * length) then need to make sure it doesn't
    //go over bounds of the month
    if (daysMatch.Count > 2 && daysMatch[1].ToString() == "to") {
      int indexOfOne = Array.IndexOf(weekDayNames, daysMatch[0].ToString());
      int indexOfTwo = Array.IndexOf(weekDayNames, daysMatch[2].ToString());
      int dayToAdd = 0;
      List<string> dayNames = new List<string>();

      for (int i = 0; i <= indexOfTwo - indexOfOne; i++) {
        int _month = month;
        int _year = year;
        dayNames.Add(weekDayNames[indexOfOne + i]);
        
        if (day > 21) {
          dayToAdd = Array.IndexOf(weekDayNames, dayNames[i]) + 1;
          _month += 1;

          if (month == 12) {
            _year += 1;
          }
        } else if (weekDay < indexOfOne) {
          //The date is coming up
          dayToAdd = day + (Array.IndexOf(weekDayNames, dayNames[i]) - weekDay);
        } else {
          //Add it for next week
          dayToAdd = day + (7 - weekDay) + Array.IndexOf(weekDayNames, dayNames[i]);
        }

        dateToAdd = _month.ToString() + "/" + dayToAdd.ToString() + "/" + _year.ToString();
        dates.Add(dateToAdd);
      }
    } else if (daysMatch.Count > 2 && daysMatch[1].ToString() == "and") {
        int indexOfOne = Array.IndexOf(weekDayNames, daysMatch[0].ToString());
        int indexOfTwo = Array.IndexOf(weekDayNames, daysMatch[2].ToString());
        int firstDay = 0;
        int secondDay = 0;

        if (daysMatch[0].ToString() == weekDayNames[weekDay] 
        || daysMatch[2].ToString() == weekDayNames[weekDay] 
        || weekDay > indexOfOne) {

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
          //If the job is coming up in the week
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

    return dates;
  }
}