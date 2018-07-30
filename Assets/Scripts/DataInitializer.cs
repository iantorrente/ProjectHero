using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class DataInitializer : MonoBehaviour {
  public static string fatherNamePath = "C:\\Development\\Mobile\\Project Hero\\Assets\\Scripts\\Data\\Parent\\FatherNames.json";
  public static string motherNamePath = "C:\\Development\\Mobile\\Project Hero\\Assets\\Scripts\\Data\\Parent\\MotherNames.json";
  public static string nicknameNamePath = "C:\\Development\\Mobile\\Project Hero\\Assets\\Scripts\\Data\\Parent\\Nicknames.json";

  public class FatherName {
    public string[] firstNames;
    public string[] lastNames;
  }

  public class MotherName {
    public string[] firstNames;
  }

  public struct Nicknames {
    public string name;
    public string[] nicknames;
  }

  public class ParentNickname {
    public Nicknames[] nicknames;
  }
  
  //Deserializes the JSON file in the path 'fatherNamePath'. Can be used to deserialize all data, not just the father one
  public static void deserializeJson () { //Possibly find a way to make it generic so you can use it to deserialize any JSON
  FatherName fNameCollection;
  MotherName mNameCollection;
  ParentNickname nNameCollection;
  string fJsonString;
  string mJsonString;
  string nJsonString;
    using (StreamReader stream = new StreamReader(fatherNamePath)) {
      fJsonString = stream.ReadToEnd();
      fNameCollection = JsonUtility.FromJson<FatherName>(fJsonString);
    }
    using (StreamReader stream = new StreamReader(motherNamePath)) {
      mJsonString = stream.ReadToEnd();
      mNameCollection = JsonUtility.FromJson<MotherName>(mJsonString);
    }
    using (StreamReader stream = new StreamReader(nicknameNamePath)) {
      nJsonString = stream.ReadToEnd();
      Debug.Log(nJsonString);
      nNameCollection = JsonConvert.DeserializeObject<ParentNickname>(nJsonString); //Use this from now on
    }
    //Put them into persistent data
    ParentData.parentData.fatherFirstNames = fNameCollection.firstNames;
    ParentData.parentData.fatherLastNames = fNameCollection.lastNames;
    ParentData.parentData.motherFirstNames = mNameCollection.firstNames;

    Debug.Log(nNameCollection.nicknames[0].nicknames[0]);
  }

  //When the script is loaded this is run
  private void Awake () {
    deserializeJson();
  }
}