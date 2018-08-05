using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitializeData : MonoBehaviour {
  //Gets initialized every time player goes into The City scene. Might want to change it
  private void Initialize () {
    ChildPower playerPower = PlayerData.playerData.playerPower;
    //Only display the attributes rounded up
		GameObject.Find("Player Data Text").GetComponent<Text>().text = (
      playerPower.powerName + "\nSTATS:"
      + "\nStrength: " + (int)playerPower.Strength
      + "\nAgility: " + (int)playerPower.Agility
      + "\nWill: " + (int)playerPower.Will
      + "\nFortitude: " + (int)playerPower.Fortitude
      + "\nDays: " + PlayerData.playerData.days
    );
    GameObject.Find("Time").GetComponent<Text>().text = (PlayerData.playerData.dayCycle).ToUpper();
  }

	// Use this for initialization
	void Awake () {
    Initialize();
  }
}
