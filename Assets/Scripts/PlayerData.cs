using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {
  public ChildPower playerPower;
  public ParentalPower fatherPower;
  public ParentalPower motherPower;
  public string playerName;
  public double money;
  public int stamina = 4;
  public static PlayerData playerData;
  //Make a new health field that tracks health as a string (healthy, fatigued, exhausted, etc.)

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
