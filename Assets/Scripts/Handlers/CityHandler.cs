using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CityHandler : MonoBehaviour {
  public void buttonClick () {
    string pressedButton = EventSystem.current.currentSelectedGameObject.name;
    handleSceneChange(pressedButton);
    handleActions(pressedButton);
  }

  private void handleSceneChange (string pressedButton) {
    if (pressedButton == "Agency") {
      SceneManager.LoadScene("Agency", LoadSceneMode.Single);
    } else if (pressedButton == "Gym") {
      SceneManager.LoadScene("Gym", LoadSceneMode.Single);
    } else if (pressedButton == "University") {
      SceneManager.LoadScene("University", LoadSceneMode.Single);
    } else if (pressedButton == "Arena") {
      SceneManager.LoadScene("Arena", LoadSceneMode.Single);
    } else if (pressedButton == "Home") {
      SceneManager.LoadScene("Home", LoadSceneMode.Single);
    } else if (pressedButton == "City Hall") {
      SceneManager.LoadScene("City Hall", LoadSceneMode.Single);
    } else if (pressedButton == "Library") {
      SceneManager.LoadScene("Library", LoadSceneMode.Single);
    } else if (pressedButton == "Back Button") {
      SceneManager.LoadScene("The City", LoadSceneMode.Single);
    } 
  }

  private void handleActions (string pressedButton) {
    //Home Actions
    if (pressedButton == "Nap") {
      TimeHandler.handleCycleChange("nap");
    } else if (pressedButton == "Sleep") {
      TimeHandler.handleDayChange();
    }

    //Gym Actions
    if (pressedButton == "Strength Training") {
      TrainingHandler.handleTraining("strength");
    } else if (pressedButton == "Agility Training") {
      TrainingHandler.handleTraining("agility");
    } else if (pressedButton == "Fortitude Training") {
      TrainingHandler.handleTraining("fortitude");
    }

    //University Actions
    if (pressedButton == "Will Training") {
      TrainingHandler.handleTraining("will");
    }

    //Agency Actions
    if (pressedButton == "Find Job") {
      Debug.Log("Sorry hero, there isn't anything yet.");
    }
  }
}