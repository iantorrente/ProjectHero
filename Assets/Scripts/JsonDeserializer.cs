using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

//Handles deserializing JSON files
public class JsonDeserializer : MonoBehaviour {
  private class ParentNames {
    public string[] fFirstNames {get; set; }
    public string[] mFirstNames {get; set; }
    public string[] lastNames {get; set; }
  }

  private struct Nicknames {
    public string name { get; set; }
    public string[] nicknames { get; set; }
  }

  private class ParentNickname {
    public Nicknames[] nicknames { get; set; }
  }
  
  //Deserializes the JSON file in the path 'fatherNamePath'. Can be used to deserialize all data, not just the father one
  //Possibly find a way to make it generic so you can use it to deserialize any JSON
  public static void deserializeJson () {
  //With Resources.Load<>() you only need the filepath from within /Resources
  string jobsJsonString = Resources.Load<TextAsset>("HeroJobs").ToString();
  string fJsonString = Resources.Load<TextAsset>("ParentNames").ToString(); 
  string nJsonString = Resources.Load<TextAsset>("Nicknames").ToString();
  HeroJobsCollection heroJobsCollection = JsonConvert.DeserializeObject<HeroJobsCollection>(jobsJsonString);
  ParentNames parentNames = JsonConvert.DeserializeObject<ParentNames>(fJsonString);
  ParentNickname nNameCollection = JsonConvert.DeserializeObject<ParentNickname>(nJsonString);
  
  //Put them into persistent data
  JobsData.jobsData.heroJobsCollection = heroJobsCollection;
  ParentData.parentData.fatherFirstNames = parentNames.fFirstNames;
  ParentData.parentData.fatherLastNames = parentNames.lastNames;
  ParentData.parentData.motherFirstNames = parentNames.mFirstNames;
  ParentData.parentData.strengthNicknames = nNameCollection.nicknames[0].nicknames;
  ParentData.parentData.agilityNicknames = nNameCollection.nicknames[1].nicknames;
  ParentData.parentData.willNicknames = nNameCollection.nicknames[2].nicknames;
  ParentData.parentData.fortitudeNicknames = nNameCollection.nicknames[3].nicknames;
  }

  //Create a method to generically deserialize any json file
  // private static void deserializer (string path, GenericClass Class) {
  //   string jsonString = Resources.Load<TextAsset>(path).ToString();
  //   Class jsonCollection = JsonConvert.DeserializeObject<Class>(jsonString);
  // }

  //When the script is loaded this is run
  private void Awake () {
    deserializeJson();
  }
}