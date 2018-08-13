using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopularityHandler : MonoBehaviour {
  public static void handlePopularity () {
    int popularity = PlayerData.playerData.popularity;
    string[] popularityArray = new string[] {
      "Iconoclast", "Ruiner", "Public Enemy", "Outlaw", "Villain",
      "Criminal", "Thug", "Troublemaker", "Ignored",
      "Nameless", "Whispered", "Known", "Recognized", "Respected", 
      "Hero", "Adored", "Loved", "Idolized", "Savior"
    };
  }
}