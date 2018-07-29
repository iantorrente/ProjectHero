using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class DataInitializer : MonoBehaviour {
  public static string fatherNamePath = "C:\\Development\\Mobile\\Project Hero\\Assets\\Scripts\\Data\\Father\\FatherNames.json";
  
  public class FatherName {
    public string[] FirstNames;
    public string[] LastNames;
  }
  
  //Deserializes the JSON file in the path 'fatherNamePath'. Can be used to deserialize all data, not just the father one
  public static void deserializeJson () {
  FatherName fNameCollection;
  string jsonString;
    using (StreamReader stream = new StreamReader(fatherNamePath)) {
      jsonString = stream.ReadToEnd();
      fNameCollection = JsonUtility.FromJson<FatherName>(jsonString);
    }
    //Put them into persistent data
    FatherData.fatherData.fatherFirstNames = fNameCollection.FirstNames;
    FatherData.fatherData.fatherLastNames = fNameCollection.LastNames;
  }

  //When the script is loaded this is run
  private void Awake () {
    deserializeJson();
  }
}