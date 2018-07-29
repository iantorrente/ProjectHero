using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FatherData : MonoBehaviour {
    public string[] fatherFirstNames;
    public string[] fatherLastNames;
    public static FatherData fatherData;

    void Awake () {
		if (fatherData == null) {
      DontDestroyOnLoad(gameObject);
      fatherData = this;
    } else if (fatherData != this) {
      Destroy(gameObject);
    }
	}
}