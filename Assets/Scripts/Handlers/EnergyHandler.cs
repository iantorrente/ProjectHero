using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyHandler : MonoBehaviour {
  //In order for a method to be called by another class, all you have to do is make it static
  public static void handleEnergy () {
    Debug.Log("HANDLING ENERGY");
  }
}