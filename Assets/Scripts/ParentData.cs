using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Delete after being used by the character creation
public class ParentData : MonoBehaviour {
    public string[] fatherFirstNames;
    public string[] fatherLastNames;
    public string[] motherFirstNames;
    public string[] strengthNicknames;
    public string[] agilityNicknames;
    public string[] willNicknames;
    public string[] fortitudeNicknames;
    public static ParentData parentData;

    void Awake () {
		if (parentData == null) {
      DontDestroyOnLoad(gameObject);
      parentData = this;
    } else if (parentData != this) {
      Destroy(gameObject);
    }
	}
}