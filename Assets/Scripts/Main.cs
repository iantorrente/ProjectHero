using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {
  public static bool canSave = false;
  public static ChildPower childPower;
  public static ParentalPower fatherPower;
  public static ParentalPower motherPower;

	//This is getting cluttered. Might want to start migrating stuff to other methods or classes
	public void ButtonClick () {
    //Figures out which button was clicked
		string pressedButton = EventSystem.current.currentSelectedGameObject.name;

    if (pressedButton == "Exit") {
      SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

		string[] parentalPowerArray = generateParentalPowers();
		//Need to see if there's a way to get a truly random bunch of numbers
		int i = Random.Range(0, parentalPowerArray.Length);
    int j = Random.Range(0, FatherData.fatherData.fatherFirstNames.Length);
    int k = Random.Range(0, FatherData.fatherData.fatherLastNames.Length);
    string fatherName = FatherData.fatherData.fatherFirstNames[j] + " " + FatherData.fatherData.fatherLastNames[k];
		string parentalPower = parentalPowerArray[i];
    
		if (pressedButton == "FatherButton") {
			fatherPower = new ParentalPower(parentalPower);
			GameObject.Find("Father").GetComponent<Text>().text = (
			fatherPower.PowerName + "\n" + fatherName + "\nSTATS:\n" 
			+ "Strength: " + fatherPower.Strength
			+ "\nAgility: " + fatherPower.Agility
			+ "\nWill: " + fatherPower.Will
			+ "\nFortitude: " + fatherPower.Fortitude
			+ "\nPopularity: " + fatherPower.Popularity);
		} else if (pressedButton == "MotherButton") {
			motherPower = new ParentalPower(parentalPower);
			GameObject.Find("Mother").GetComponent<Text>().text = (
			motherPower.PowerName + "\nSTATS:\n" 
			+ "Strength: " + motherPower.Strength
			+ "\nAgility: " + motherPower.Agility
			+ "\nWill: " + motherPower.Will
			+ "\nFortitude: " + motherPower.Fortitude
			+ "\nPopularity: " + motherPower.Popularity);
		}

    if (fatherPower != null && motherPower != null) {
		  SetChildPower(fatherPower ,motherPower);
    }
	}

	public void SetChildPower (ParentalPower fPower, ParentalPower mPower) {
    childPower = new ChildPower(fPower, mPower);
    GameObject.Find("Child Power Description").GetComponent<Text>().text = childPower.Description;
    GameObject.Find("Child Power Name").GetComponent<Text>().text = childPower.PowerName;
		GameObject.Find("Child").GetComponent<Text>().text = (
    "Strength: " + childPower.Strength
    + "\nAgility: " + childPower.Agility
    + "\nWill: " + childPower.Will
    + "\nFortitude: " + childPower.Fortitude);
    canSave = true;
	}

  //Probably don't even need a separate method for this
	string[] generateParentalPowers () {
		string[] parentalPowers = new string[] {
			"SUPER STRENGTH",
			"TELEKINESIS",
			"PYROMANCY",
			"SHAPESHIFT"
		};

		return parentalPowers;
	}
}
