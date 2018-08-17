using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpers : MonoBehaviour {
  public static bool isPositive (decimal pIndex) {
    if (pIndex >= 0) {
      return true;
    } else {
      return false;
    }
  }

  public static bool hasStamina (int stamina) {
    if (stamina > 0) {
      return true;
    } else {
      return false;
    }
  }

  public static decimal calculateSalary (decimal pay, decimal modifier) {
    return pay + (pay * modifier);
  }
}