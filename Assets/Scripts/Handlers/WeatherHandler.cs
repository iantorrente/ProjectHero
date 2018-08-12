using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles weather variability between days and seasons
//Make this system reliant on temperature for weather changes
//so that it's pretty close to how rain is formed under real
//life conditions
public class WeatherHandler : MonoBehaviour {
  public static void handleWeather () {
    string[] weatherArray = new string[] {
      "The Ocean's Falling", "Thunderstorm", "Raining", 
      "Cloudy", "Warm", "Sunny", "Glaring Heat", "Inferno"
    };
    string season = GlobalData.globalData.seasonName;
    int index = System.Array.IndexOf(weatherArray, GlobalData.globalData.weatherName);
    float wModifier;
    
    if (season == "Spring") {
      wModifier = 1.75f; //High variance. Sometimes it's raining sometimes it's sunny
    } else if (season == "Summer") {
      wModifier = 0.25f; //If it stays hot it stays hot
    } else if (season == "Autumn") {
      wModifier = 1.25f;
    } else if (season == "Winter") {
      wModifier = 0.5f; //Has a chance to snow and such
    }

  }

  private static void handleTemperature () {

  }
}