using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {
  public ChildPower playerPower;
  public ParentalPower fatherPower;
  public ParentalPower motherPower;
  public string playerName;
  public string dayCycle = "Morning";
  public string weekDayName = "Monday";
  public double money;
  public int years = 0;
  public int months = 0;
  public int weekDay = 0;
  public int days = 0;
  public int stamina = 4;
  public static PlayerData playerData;
	// Use this for initialization
	void Awake () {
		if (playerData == null) {
      DontDestroyOnLoad(gameObject);
      playerData = this;
    } else if (playerData != this) {
      Destroy(gameObject);
    }
	}
}
