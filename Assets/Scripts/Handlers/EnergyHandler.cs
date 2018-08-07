using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyHandler : MonoBehaviour {
  public static void handleEnergy (string action) {
    int baseStamina = 4;
    int maxStamina = baseStamina + Mathf.RoundToInt((float)PlayerData.playerData.playerPower.fortitude / 10);
    int stamina = PlayerData.playerData.stamina;
    //Handles giving energy back
    if (action == "nap") {
      stamina += 1;
    } else if (action == "sleep") {
      //if stamina is at 0 then only give back a little bit of stamina. Exhausting your body must mean it takes longer to get stamina back
      if (stamina == 0) {
        //Increase the player's health by 1 level
        stamina += (int)(maxStamina / 2.0f);
      } else {
        stamina += (maxStamina - stamina); //Will give back all of the player's stamina
      }
    } else if (action == "training") {
      stamina -= 1;
    }
    PlayerData.playerData.stamina = stamina;
  }
}