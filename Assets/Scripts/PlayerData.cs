using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {
  public static PlayerData playerData;
  public ChildPower playerPower { get; set; }
  public ParentalPower fatherPower { get; set; }
  public ParentalPower motherPower { get; set; }
  public string playerName { get; set; }
  public double money { get; set; }
  public int baseStamina { get; set; }
  public int stamina { get; set; }
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
