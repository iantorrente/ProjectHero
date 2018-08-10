using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePlayerHandler : MonoBehaviour {
  public void buttonClick () {
    if (!Main.canSave) {
      Debug.Log("Must choose father and mother powers first");
    } else {
      DataSetter.setGlobalData();
      DataSetter.setPlayerData();
      SceneManager.LoadScene("The City", LoadSceneMode.Single);
    }
  }
}
