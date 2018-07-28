﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {
  public ChildPower playerPower;
  public ParentalPower fatherPower;
  public ParentalPower motherPower;
  public string playerName;
  public static PlayerData playerData;
	// Use this for initialization
	void Awake () {
		if (playerData == null) {
      DontDestroyOnLoad(gameObject);
      playerData = this;
    } else if (playerData != this) {
      Destroy(gameObject);
    }
	}
}
