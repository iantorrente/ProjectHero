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
  string fJsonString = Resources.Load<TextAsset>("FatherNames").ToString(); //With Resources.Load<>() you only need the filepath from within /Resources
  string mJsonString = Resources.Load<TextAsset>("MotherNames").ToString();
  string nJsonString = Resources.Load<TextAsset>("Nicknames").ToString();
  FatherName fNameCollection = JsonConvert.DeserializeObject<FatherName>(fJsonString);
  MotherName mNameCollection = JsonConvert.DeserializeObject<MotherName>(mJsonString);
  ParentNickname nNameCollection = JsonConvert.DeserializeObject<ParentNickname>(nJsonString);
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