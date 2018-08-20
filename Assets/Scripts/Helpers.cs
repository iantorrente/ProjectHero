using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class Helpers {
  public static bool isPositive (decimal pIndex) {
    if (pIndex >= 0) {
      return true;
    } else {
      return false;
    }
  }

  public static bool hasStamina (int stamina) {
    if (stamina > 0) {
      return true;
    } else {
      return false;
    }
  }

  public static decimal calculateSalary (decimal pay, decimal modifier) {
    return pay + (pay * modifier);
  }

  //USE CASE: getRandomNumbers(amount, 0, 10) -- 10 being the max length of number of jobs in array
  public static int[] getRandomNumbers (int amount, int min, int max) {
    //Needed because Next() is non-static
    System.Random rand = new System.Random();
    int[] intArray = new int[amount];
    List<int> possibleNumbers = Enumerable.Range(min, max).ToList();
    List<int> listNumbers = new List<int>();
    for (int i = 0; i < amount; i++) {
      int index = rand.Next(0, possibleNumbers.Count);
      intArray[i] = possibleNumbers[index];
      possibleNumbers.RemoveAt(index);
    }

    return intArray;
  }

  public static ParsedJob[] parseHeroJobs (Jobs[] jobs, int amount) {
    ParsedJob[] parsedJobs = new ParsedJob[amount];

    for (int i = 0; i < amount; i++) {
      parsedJobs[i] = new ParsedJob();
    }

    //WHEN YOU PARSE THE REWARDS JUST SEND IT BACK ALREADY RANDOMIZED
    for (int i = 0; i < amount; i++) {
      parsedJobs[i].type = jobs[i].type;
      parsedJobs[i].title = jobs[i].title;
      parsedJobs[i].description = jobs[i].description;
      parsedJobs[i].onSuccess = jobs[i].onSuccess;
      parsedJobs[i].onFail = jobs[i].onFail;
      parsedJobs[i].successesNeeded = jobs[i].successesNeeded;
      parsedJobs[i].moneyReward = parseRewards("money", jobs[i].reward);
      parsedJobs[i].renownReward = parseRewards("renown", jobs[i].reward);
    }

    return parsedJobs;
  }

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

  // public static ParsedCorpJob[] parseCorporateJobs (CorporateJobs[] corpJobs, int amount) {
  //   ParsedCorpJob[] parsedCorpJobs = new ParsedCorpJob[amount];

  //   return parsedCorpJobs;
  // }

  // public static ParsedHumanJob[] parseHumanitarianJobs (HumanitarianJobs[] corpJobs, int amount) {
  //   ParsedHumanJob[] parsedCorpJobs = new ParsedHumanJob[amount];

  //   return parsedCorpJobs;
  // }
}