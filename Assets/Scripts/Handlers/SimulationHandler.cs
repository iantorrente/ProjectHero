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
    //Based on the number of criminals, the crime rate, and the last instance of a serious reported crime, generate crimes
    //Also generate 'crime waves' that can sporadically happen
    int criminalPopulation = GlobalData.globalData.criminalPopulation;
    int generalPopulation = GlobalData.globalData.generalPopulation;
    float violentCrimeRate = Random.Range(0, GlobalData.globalData.dailyVCRate);
    float propertyCrimeRate = Random.Range(0, GlobalData.globalData.dailyPCRate);

    //Calculate number of victims by multipling crime rate with general pop
    int vCVictims = (int)(generalPopulation * violentCrimeRate);
    int pCVictims = (int)(generalPopulation * propertyCrimeRate);
    GlobalData.globalData.victimsOfVC += vCVictims;
    GlobalData.globalData.victimsOfPC += pCVictims;

    //Calculate what types of violent/property crimes happened that day based on the upper limit of how many victims there were on the day
    Debug.Log(vCVictims + " Victims of Violent Crimes Today" + "\n" + pCVictims + " Victims of Property Crimes Today");
  }
}