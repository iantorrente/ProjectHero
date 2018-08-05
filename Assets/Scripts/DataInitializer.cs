using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class DataInitializer : MonoBehaviour {
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
  TextAsset fNameFile = Resources.Load<TextAsset>("FatherNames"); //With Resources.Load<>() you don't need the filepath, just what the file is called
  TextAsset mNameFile = Resources.Load<TextAsset>("MotherNames");
  TextAsset nNameFile = Resources.Load<TextAsset>("Nicknames");
  string fJsonString = fNameFile.ToString();
  string mJsonString = mNameFile.ToString();
  string nJsonString = nNameFile.ToString();
  FatherName fNameCollection = JsonConvert.DeserializeObject<FatherName>(fJsonString);
  MotherName mNameCollection = JsonConvert.DeserializeObject<MotherName>(mJsonString);
  ParentNickname nNameCollection = JsonConvert.DeserializeObject<ParentNickname>(nJsonString);
    // using (StreamReader stream = new StreamReader(motherNamePath)) {
    //   mJsonString = stream.ReadToEnd();
    //   mNameCollection = JsonUtility.FromJson<MotherName>(mJsonString);
    // }
    // using (StreamReader stream = new StreamReader(nicknameNamePath)) {
    //   nJsonString = stream.ReadToEnd();
    //   Debug.Log(nJsonString);
    //   nNameCollection = JsonConvert.DeserializeObject<ParentNickname>(nJsonString); //Use this from now on
    // }
    //Put them into persistent data
    ParentData.parentData.fatherFirstNames = fNameCollection.firstNames;
    ParentData.parentData.fatherLastNames = fNameCollection.lastNames;
    ParentData.parentData.motherFirstNames = mNameCollection.firstNames;
    ParentData.parentData.strengthNicknames = nNameCollection.nicknames[0].nicknames;
    ParentData.parentData.agilityNicknames = nNameCollection.nicknames[1].nicknames;
    ParentData.parentData.willNicknames = nNameCollection.nicknames[2].nicknames;
    ParentData.parentData.fortitudeNicknames = nNameCollection.nicknames[3].nicknames;
  }

  //When the script is loaded this is run
  private void Awake () {
    deserializeJson();
  }
}