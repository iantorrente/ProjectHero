using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData : MonoBehaviour {
  public static PlayerData playerData { get; set; }
  public ChildPower playerPower { get; set; }
  public ParentalPower fatherPower { get; set; }
  public ParentalPower motherPower { get; set; }
  public string playerName { get; set; }
  public string popularityTitle { get; set; }
  public string healthiness { get; set; }
  public decimal money { get; set; }
  public decimal popularityExperience { get; set; }
  public decimal flatModifier { get; set; }
  public decimal renownModifier { get; set; }
  public decimal strengthModifier { get; set; }
  public decimal agilityModifier { get; set; }
  public decimal willModifier { get; set; }
  public decimal fortitudeModifier { get; set; }
  public int fans { get; set; }
  public int healthinessIndex { get; set; }
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
