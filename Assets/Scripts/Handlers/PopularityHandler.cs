using System;
using UnityEngine;

public class PopularityHandler : MonoBehaviour {
  //Whenever you give popularityExperience, invoke this method
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
  }

  //Need to find a more efficient way to do this
  private static void calculatePopularity (string[] pArray, string pTitle, int pIndex, decimal pExp) {
    Debug.Log("Player exp: " + pExp + "\npIndex: " + pIndex);
    bool isPositive = Helpers.isPositive(pExp);
    if (isPositive) {
      Debug.Log("pExp is positive");
      if (pExp >= 0 && pExp < 500) {
        pTitle = pArray[9];
      } else if (pExp >= 500 && pExp < 1250) {
        pTitle = pArray[10];
      } else if (pExp >= 1250 && pExp < 3125) {
        pTitle = pArray[11];
      } else if (pExp >= 3125 && pExp < 7800) {
        pTitle = pArray[12];
      } else if (pExp >= 7800 && pExp < 19500) {
        pTitle = pArray[13];
      } else if (pExp >= 19500 && pExp < 48800) {
        pTitle = pArray[14];
      } else if (pExp >= 48800 && pExp < 122000) {
        pTitle = pArray[15];
      } else if (pExp >= 122000 && pExp < 305000) {
        pTitle = pArray[16];
      } else if (pExp >= 305000 && pExp < 762500) {
        pTitle = pArray[17];
      } else if (pExp >= 762500) {
        pTitle = pArray[18];
      }
    } else {
      Debug.Log("pExp is negative");
      if (pExp <= -500 && pExp > -1250) {
        pTitle = pArray[8];
      } else if (pExp <= -1250 && pExp > -3125) {
        pTitle = pArray[7];
      } else if (pExp <= -3125 && pExp > -7800) {
        pTitle = pArray[6];
      } else if (pExp <= -7800 && pExp > -19500) {
        pTitle = pArray[5];
      } else if (pExp <= -19500 && pExp > -48800) {
        pTitle = pArray[4];
      } else if (pExp <= -48800 && pExp > -122000) {
        pTitle = pArray[3];
      } else if (pExp <= -122000 && pExp > -305000) {
        pTitle = pArray[2];
      } else if (pExp <= -305000 && pExp > -762500) {
        pTitle = pArray[1];
      } else if (pExp <= -762500) {
        pTitle = pArray[0];
      }
    }
    PlayerData.playerData.popularityTitle = pTitle;
  }
}