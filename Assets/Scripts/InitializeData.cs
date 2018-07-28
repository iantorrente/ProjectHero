using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitializeData : MonoBehaviour {

	// Use this for initialization
	void Awake () {
    ChildPower playerPower = PlayerData.playerData.playerPower;
    ParentalPower fatherPower = PlayerData.playerData.fatherPower;
    ParentalPower motherPower = PlayerData.playerData.motherPower;
		GameObject.Find("Player Data Text").GetComponent<Text>().text = (
      playerPower.PowerName + "\nSTATS:"
      + "\nStrength: " + playerPower.Strength
      + "\nAgility: " + playerPower.Agility
      + "\nWill: " + playerPower.Will
      + "\nFortitude: " + playerPower.Fortitude
    );
    Debug.Log(fatherPower.PowerName + "\nSTATS:"
      + "\nStrength: " + fatherPower.Strength
      + "\nAgility: " + fatherPower.Agility
      + "\nWill: " + fatherPower.Will
      + "\nFortitude: " + fatherPower.Fortitude);
    Debug.Log(motherPower.PowerName + "\nSTATS:"
    + "\nStrength: " + motherPower.Strength
    + "\nAgility: " + motherPower.Agility
    + "\nWill: " + motherPower.Will
    + "\nFortitude: " + motherPower.Fortitude);
  }
}
