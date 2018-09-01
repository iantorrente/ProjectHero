using System;
using UnityEngine;

public class PopularityHandler : MonoBehaviour {
  //When a player gets to Villain or Hero status they cannot do the actions attributed
  //to either opposing side any longer until their renown is brought down
  public static void handlePopularity () {
    string popularityTitle = PlayerData.playerData.popularityTitle;
    decimal popularityExperience = PlayerData.playerData.popularityExperience;
    string[] popularityArray = new string[] {
      "Iconoclast", "Ruiner", "Public Enemy", "Outlaw", "Villain",
      "Criminal", "Thug", "Troublemaker", "Ignored",
      "Nameless", "Whispered", "Known", "Recognized", "Respected", 
      "Hero", "Adored", "Loved", "Idolized", "Savior"
    };
    calculatePopularity(popularityArray, popularityTitle, popularityExperience);
  }


  //Need to find a more efficient way to do this
  private static void calculatePopularity (string[] pArray, string pTitle, decimal pExp) {
    bool isPositive = Helpers.isPositive(pExp);
    decimal rModifier = 0;
    int rIndex = 0;
    int maxJobs = 0;

    if (isPositive) {
      if (pExp >= 0 && pExp < 500) {
        pTitle = pArray[9];
        rIndex = 0;
        rModifier = 0.05m;
        maxJobs = 1;
      } else if (pExp >= 500 && pExp < 1250) {
        pTitle = pArray[10];
        rIndex = 1;
        rModifier = 0.1m;
        maxJobs = 1;
      } else if (pExp >= 1250 && pExp < 3125) {
        pTitle = pArray[11];
        rIndex = 2;
        rModifier = 0.25m;
        maxJobs = 2;
      } else if (pExp >= 3125 && pExp < 7800) {
        pTitle = pArray[12];
        rIndex = 3;
        rModifier = 0.40m;
        maxJobs = 2;
      } else if (pExp >= 7800 && pExp < 19500) {
        pTitle = pArray[13];
        rIndex = 4;
        rModifier = 0.65m;
        maxJobs = 2;
      } else if (pExp >= 19500 && pExp < 48800) {
        pTitle = pArray[14];
        rIndex = 5;
        rModifier = 1;
        maxJobs = 3;
      } else if (pExp >= 48800 && pExp < 122000) {
        pTitle = pArray[15];
        rIndex = 6;
        rModifier = 1.35m;
        maxJobs = 3;
      } else if (pExp >= 122000 && pExp < 305000) {
        pTitle = pArray[16];
        rIndex = 7;
        rModifier = 1.75m;
        maxJobs = 3;
      } else if (pExp >= 305000 && pExp < 762500) {
        pTitle = pArray[17];
        rIndex = 8;
        rModifier = 2.10m;
        maxJobs = 4;
      } else if (pExp >= 762500) {
        pTitle = pArray[18];
        rIndex = 9;
        rModifier = 2.5m;
        maxJobs = 4;
      }
    } else {
      if (pExp <= -500 && pExp > -1250) {
        pTitle = pArray[8];
        rModifier = 0.1m;
      } else if (pExp <= -1250 && pExp > -3125) {
        pTitle = pArray[7];
        rModifier = 0.25m;
      } else if (pExp <= -3125 && pExp > -7800) {
        pTitle = pArray[6];
        rModifier = 0.40m;
      } else if (pExp <= -7800 && pExp > -19500) {
        pTitle = pArray[5];
        rModifier = 0.65m;
      } else if (pExp <= -19500 && pExp > -48800) {
        pTitle = pArray[4];
        rModifier = 1;
      } else if (pExp <= -48800 && pExp > -122000) {
        pTitle = pArray[3];
        rModifier = 1.35m;
      } else if (pExp <= -122000 && pExp > -305000) {
        pTitle = pArray[2];
        rModifier = 1.75m;
      } else if (pExp <= -305000 && pExp > -762500) {
        pTitle = pArray[1];
        rModifier = 2.10m;
      } else if (pExp <= -762500) {
        pTitle = pArray[0];
        rModifier = 2.50m;
      }
    }
    PlayerData.playerData.renownIndex = rIndex;
    PlayerData.playerData.renownModifier = rModifier;
    PlayerData.playerData.popularityTitle = pTitle;
    PlayerData.playerData.maxJobs = maxJobs;
  }
}