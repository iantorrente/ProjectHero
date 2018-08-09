using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles ALL of the global simulation stuff
public class SimulationHandler : MonoBehaviour {
  public static void handleSimulation () {
    handlePopulation();
    handleCrimes();
  }

  public static void handlePopulation () {
    int increasePop = (int)(GlobalData.globalData.generalPopulation * GlobalData.globalData.dailyBirthRate);
    int decreasePop = (int)(GlobalData.globalData.generalPopulation * GlobalData.globalData.dailyDeathRate);
    GlobalData.globalData.generalPopulation += (increasePop - decreasePop);
    Debug.Log("Births today: " + increasePop + "\nDeaths today: " + decreasePop + "\nTotal population: " + GlobalData.globalData.generalPopulation);
  }

  public static void handleCrimes () {

  }
}