using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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

  public static void saveCharacter () {
    Debug.Log("Saving Player Data");
    BinaryFormatter binaryFormatter = new BinaryFormatter();
    FileStream saveFile;
    if (File.Exists(Application.persistentDataPath + "/playerSave.dat")) {
      saveFile = File.Open(Application.persistentDataPath + "/playerSave.dat", FileMode.Open);
    } else {
      saveFile = File.Create(Application.persistentDataPath + "/playerSave.dat");
    }
    SavePlayerData saveData = new SavePlayerData();
    saveData.globalData = GlobalData.globalData;
    //saveData.playerData = PlayerData.playerData;

    binaryFormatter.Serialize(saveFile, saveData);
    saveFile.Close();
  }

  public static void loadCharacter () {
    
  }
}

[System.Serializable]
class SavePlayerData {
  public GlobalData globalData { get; set; }
  public PlayerData playerData { get; set; }
}
