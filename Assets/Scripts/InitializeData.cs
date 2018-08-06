using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitializeData : MonoBehaviour {
  //Gets initialized every time player goes into The City scene. Might want to change it
  private void Initialize () {
    ChildPower playerPower = PlayerData.playerData.playerPower;
    //Only display the attributes rounded up
    //TODO: CONTEXTUAL PLURAL FOR TIME (year(s), month(s), day(s))
		GameObject.Find("Player Data Text").GetComponent<Text>().text = (
      playerPower.powerName + "\nSTATS:"
      + "\nStrength: " + (int)playerPower.Strength
      + "\nAgility: " + (int)playerPower.Agility
      + "\nWill: " + (int)playerPower.Will
      + "\nFortitude: " + (int)playerPower.Fortitude
      + "\nTime: " + PlayerData.playerData.years + " years, " + PlayerData.playerData.months + " months, " + PlayerData.playerData.days + " days"
    );
    GameObject.Find("Time").GetComponent<Text>().text = (PlayerData.playerData.dayCycle).ToUpper();
  }

	// Use this for initialization
	void Awake () {
    Initialize();
  }
}
