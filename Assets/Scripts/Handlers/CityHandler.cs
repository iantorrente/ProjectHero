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
    } else if (pressedButton == "Back Button") {
      SceneManager.LoadScene("The City", LoadSceneMode.Single);
    }
  }
}