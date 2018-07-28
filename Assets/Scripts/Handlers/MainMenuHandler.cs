using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour {
  public void ButtonClick () {
    string pressedButton = EventSystem.current.currentSelectedGameObject.name;

    if (pressedButton == "Start") {
      SceneManager.LoadScene("Character Creation", LoadSceneMode.Single);
    }
    if (pressedButton == "Load") {

    }
    if (pressedButton == "Exit") {
      Application.Quit();
    }
  }
}
