using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyHandler : MonoBehaviour {
  public static void handleEnergy (string action) {
    int baseStamina = 4;
    int maxStamina = baseStamina + Mathf.RoundToInt((float)PlayerData.playerData.playerPower.fortitude / 10);
    int stamina = PlayerData.playerData.stamina;
    
    if (stamina <= maxStamina) {
      if (action == "nap" && stamina != maxStamina) {
        stamina += 1;
      } else if (action == "sleep") {
        if (GlobalData.globalData.dayCycle == "Night") {
          //Sleeping at night is more restful
          stamina += (maxStamina - stamina);
        } else {
          //Sleeping at any other time will only give back half of the max stamina
          if (stamina > (int)(maxStamina / 2.0f)) {
            stamina = maxStamina;
          } else {
            stamina += (int)(maxStamina / 2.0f);
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