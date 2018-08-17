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
    //Moving in between broad city locations. Will probably be split
    //into districts
    if (pressedButton == "City2") {
      SceneManager.LoadScene("The City 2", LoadSceneMode.Single);
    } else if (pressedButton == "City1") {
      SceneManager.LoadScene("The City", LoadSceneMode.Single);
    }

    //Movement between locations inside the city
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
    } else if (pressedButton == "Police Station") {
      SceneManager.LoadScene("Police Station", LoadSceneMode.Single);
    } else if (pressedButton == "Kofee Haus") {
      SceneManager.LoadScene("Kofee Haus", LoadSceneMode.Single);
    } else if (pressedButton == "Back Button") {
      SceneManager.LoadScene("The City", LoadSceneMode.Single);
    } else if (pressedButton == "Gym Back") {
      SceneManager.LoadScene("Gym", LoadSceneMode.Single);
    }

    //Movement inside of the Gym
    //Will be deprecated because Gym UI will be changed through
    //script and separate scenes won't be necessarry
    if (pressedButton == "Free Training") {
      SceneManager.LoadScene("Gym Free", LoadSceneMode.Single);
    } else if (pressedButton == "Cheap Training") {
      SceneManager.LoadScene("Gym Cheap", LoadSceneMode.Single);
    } else if (pressedButton == "Normal Training") {
      SceneManager.LoadScene("Gym Normal", LoadSceneMode.Single);
    } else if (pressedButton == "Expensive Training") {
      SceneManager.LoadScene("Gym Expensive", LoadSceneMode.Single);
    }
  }

  private void handleActions (string pressedButton) {
    //Home Actions
    if (pressedButton == "Nap") {
      TimeHandler.handleCycleChange("nap");
    } else if (pressedButton == "Sleep") {
      PopularityHandler.handlePopularity();
      TimeHandler.handleDayChange("sleep");
    } else if (pressedButton == "Calendar") {
      SceneManager.LoadScene("Calendar", LoadSceneMode.Single);
    }

    //Gym Actions
    //TODO: Split training into free, cheap, normal, and expensive
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
      JobHandler.generateAgencyJobs();
      //Debug.Log("Sorry hero, there isn't anything yet.");
    }

    //Moonlight Jobs Actions
    if (pressedButton == "KofeeHausWork") {
      JobHandler.handleMoonlight(pressedButton);
    } else if (pressedButton == "") {
      JobHandler.handleMoonlight(pressedButton);
      //strength job
    } else if (pressedButton == "") {
      JobHandler.handleMoonlight(pressedButton);
      //fortitude job
    } else if (pressedButton == "") {
      JobHandler.handleMoonlight(pressedButton);
      //will job
    }
  }
}