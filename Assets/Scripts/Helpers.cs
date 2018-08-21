using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

  public static void clearHeroJobsList () {
    GlobalData.globalData.jobsGenerated = false;
    AvailableJobs.availableJobs.heroJobsArray.Clear();
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