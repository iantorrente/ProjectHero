using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyHandler : MonoBehaviour {
  public static void handleEnergy (string action) {
    int baseStamina = PlayerData.playerData.baseStamina;
    int maxStamina = baseStamina + Mathf.RoundToInt((float)PlayerData.playerData.playerPower.fortitude / 10);
    int stamina = PlayerData.playerData.stamina;
    string dayCycle = GlobalData.globalData.dayCycle;
    
    if (stamina <= maxStamina) {
      if (action == "nap" && stamina != maxStamina) {
        stamina += 1;
      } else if (action == "sleep") {
        if (dayCycle == "Midnight") {
          //Only give back enough stamina to do one action per cycle
          if (stamina <= maxStamina - 3) {
            stamina += 3;
          } else if (stamina > maxStamina - 3) {
            stamina = maxStamina;
          }
        } else {
          //Give back 1 extra stamina for each cycle they slept through
          if (dayCycle == "Morning") {
            if (maxStamina < 6 || stamina + 6 > maxStamina) {
              stamina = maxStamina;
            } else {
              stamina += 6;
            }
          } else if (dayCycle == "Afternoon") {
            if (maxStamina < 5 || stamina + 5 > maxStamina) {
              stamina = maxStamina;
            } else {
              stamina += 5;
            }
          } else if (dayCycle == "Evening") {
            if (maxStamina < 4 || stamina + 4 > maxStamina) {
              stamina = maxStamina;
            } else {
              stamina += 4;
            }
          }
        }
      } else if (action == "training") {
        //If the player is unhealthy take away more stamina
        stamina -= 1;
      }
    }
    PlayerData.playerData.stamina = stamina;
    Debug.Log("Stamina: " + stamina + "\nMax Stamina: " + maxStamina);
  }
}