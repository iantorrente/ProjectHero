using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsHandler : MonoBehaviour {
  public static void increaseStat (string stat, decimal amount) {
    decimal flatMod = PlayerData.playerData.flatModifier;
    if (stat == "strength") {
      PlayerData.playerData.playerPower.strength += amount;
      PlayerData.playerData.strengthModifier = PlayerData.playerData.playerPower.strength * flatMod;
    } else if (stat == "agility") {
      PlayerData.playerData.playerPower.agility += amount;
      PlayerData.playerData.agilityModifier = PlayerData.playerData.playerPower.agility * flatMod;
    } else if (stat == "will") {
      PlayerData.playerData.playerPower.will += amount;
      PlayerData.playerData.willModifier = PlayerData.playerData.playerPower.will * flatMod;
    } else if (stat == "fortitude") {
      PlayerData.playerData.playerPower.fortitude += amount;
      PlayerData.playerData.fortitudeModifier = PlayerData.playerData.playerPower.fortitude * flatMod;
    }
    Debug.Log("New agility modifier: " + PlayerData.playerData.agilityModifier);
  }

  public static void decreaseStat (string stat, decimal amount) {
    decimal flatMod = PlayerData.playerData.flatModifier;
    if (stat == "strength") {
      PlayerData.playerData.playerPower.strength -= amount;
      PlayerData.playerData.strengthModifier = PlayerData.playerData.playerPower.strength * flatMod;
    } else if (stat == "agility") {
      PlayerData.playerData.playerPower.agility -= amount;
      PlayerData.playerData.strengthModifier = PlayerData.playerData.playerPower.agility * flatMod;
    } else if (stat == "will") {
      PlayerData.playerData.playerPower.will -= amount;
      PlayerData.playerData.strengthModifier = PlayerData.playerData.playerPower.will * flatMod;
    } else if (stat == "fortitude") {
      PlayerData.playerData.playerPower.fortitude -= amount;
      PlayerData.playerData.strengthModifier = PlayerData.playerData.playerPower.fortitude * flatMod;
    }
  }

  public static void increasePopularity (decimal popularity) {
    PlayerData.playerData.popularityExperience += popularity;
    PopularityHandler.handlePopularity();
  }

  public static void decreasePopularity (decimal popularity) {
    PlayerData.playerData.popularityExperience -= popularity;
    PopularityHandler.handlePopularity();
  }

  public static void increaseMoney (decimal money) {
    PlayerData.playerData.money += money;
  }

  public static void decreaseMoney (decimal money) {
    PlayerData.playerData.money -= money;
  }
}