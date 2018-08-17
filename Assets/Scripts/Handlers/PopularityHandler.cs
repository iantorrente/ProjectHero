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

    int pArrayLength = popularityArray.Length;
    int pIndex = Array.IndexOf(popularityArray, popularityTitle);
    calculatePopularity(popularityArray, popularityTitle, pIndex, popularityExperience);
    Debug.Log(PlayerData.playerData.popularityTitle);
    Debug.Log("Popularity Experience: " + popularityExperience);
  }


  //Need to find a more efficient way to do this
  private static void calculatePopularity (string[] pArray, string pTitle, int pIndex, decimal pExp) {
    bool isPositive = Helpers.isPositive(pExp);
    decimal rModifier = 0;
    if (isPositive) {
      if (pExp >= 0 && pExp < 500) {
        pTitle = pArray[9];
        rModifier = (decimal)0.05;
      } else if (pExp >= 500 && pExp < 1250) {
        pTitle = pArray[10];
        rModifier = (decimal)0.1;
      } else if (pExp >= 1250 && pExp < 3125) {
        pTitle = pArray[11];
        rModifier = (decimal)0.25;
      } else if (pExp >= 3125 && pExp < 7800) {
        pTitle = pArray[12];
        rModifier = (decimal)0.40;
      } else if (pExp >= 7800 && pExp < 19500) {
        pTitle = pArray[13];
        rModifier = (decimal)0.65;
      } else if (pExp >= 19500 && pExp < 48800) {
        pTitle = pArray[14];
        rModifier = 1;
      } else if (pExp >= 48800 && pExp < 122000) {
        pTitle = pArray[15];
        rModifier = (decimal)1.35;
      } else if (pExp >= 122000 && pExp < 305000) {
        pTitle = pArray[16];
        rModifier = (decimal)1.75;
      } else if (pExp >= 305000 && pExp < 762500) {
        pTitle = pArray[17];
        rModifier = (decimal)2.10;
      } else if (pExp >= 762500) {
        pTitle = pArray[18];
        rModifier = (decimal)2.5;
      }
    } else {
      if (pExp <= -500 && pExp > -1250) {
        pTitle = pArray[8];
        rModifier = (decimal)0.1;
      } else if (pExp <= -1250 && pExp > -3125) {
        pTitle = pArray[7];
        rModifier = (decimal)0.25;
      } else if (pExp <= -3125 && pExp > -7800) {
        pTitle = pArray[6];
        rModifier = (decimal)0.40;
      } else if (pExp <= -7800 && pExp > -19500) {
        pTitle = pArray[5];
        rModifier = (decimal)0.65;
      } else if (pExp <= -19500 && pExp > -48800) {
        pTitle = pArray[4];
        rModifier = 1;
      } else if (pExp <= -48800 && pExp > -122000) {
        pTitle = pArray[3];
        rModifier = (decimal)1.35;
      } else if (pExp <= -122000 && pExp > -305000) {
        pTitle = pArray[2];
        rModifier = (decimal)1.75;
      } else if (pExp <= -305000 && pExp > -762500) {
        pTitle = pArray[1];
        rModifier = (decimal)2.10;
      } else if (pExp <= -762500) {
        pTitle = pArray[0];
        rModifier = (decimal)2.50;
      }
    }
    PlayerData.playerData.renownModifier = rModifier;
    PlayerData.playerData.popularityTitle = pTitle;
  }
}