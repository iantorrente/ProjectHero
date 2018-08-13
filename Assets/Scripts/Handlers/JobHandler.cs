using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobHandler : MonoBehaviour {
  /*
    Create jobs based on crimes (victims of violent crimes/2
    and victims of proprety crimes/10)

    Should also have jobs based on private/domestic/corporate
    needs, as well as internal hero jobs, like (fight villain, 
    do hero job x, or fight against global disasters)

    Will most likely take generic jobs from a JSON file and then
    interpret the fields to be created as jobs
  */

  /*
    Probably generate jobs each day so that jobs can be reflective
    of what's happening in the game world
  */
  public static void generateAgencyJobs () {
    //Need to create a class for jobs so that I can store each job
    //generated in here as an array of jobs
    int maxJobs = 5;
    int vCJobs = Mathf.RoundToInt(GlobalData.globalData.prevVictimsOfVC/3);
    int pCJobs = Mathf.RoundToInt(GlobalData.globalData.prevVictimsOfPC/10);
    int humanitarianJobs;
    int heroJobs;
    int corporateJobs;
    if (GlobalData.globalData.days == 0) {
      vCJobs = 2;
      pCJobs = 1;
    }
    Debug.Log("# of violent crimes jobs: " + vCJobs + "\n# of property crimes jobs: " + pCJobs);
  }

  //Moonlighting gives minimal money compared to hero jobs but they do
  //begin to help train your stats
  public static void handleMoonlight (string job) {
    decimal playerMoney = PlayerData.playerData.money;

    if (job == "KofeeHausWork") {
      double salary = 13.25;
      PlayerData.playerData.money = decimal.Add(playerMoney, (decimal)salary);
      //Increase a stat by an amount
      Debug.Log("You work at Kofee Haus for a shift and earned $" + salary);
    }
      
    TimeHandler.handleCycleChange("job");
  }
}