using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavePlayerHandler : MonoBehaviour {
  public void ButtonClick () {
    PlayerData.playerData.playerPower = Main.childPower;
    PlayerData.playerData.fatherPower = Main.fatherPower;
    PlayerData.playerData.motherPower = Main.motherPower;
    if (!Main.canSave) {
      Debug.Log("Must choose father and mother powers first");
    } else {
      SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
  }
}
