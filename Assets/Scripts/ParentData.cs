using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Delete after being used by the character creation
public class ParentData : MonoBehaviour {
    public static ParentData parentData;
    public string[] fatherFirstNames { get; set; }
    public string[] fatherLastNames { get; set; }
    public string[] motherFirstNames { get; set; }
    public string[] strengthNicknames { get; set; }
    public string[] agilityNicknames { get; set; }
    public string[] willNicknames { get; set; }
    public string[] fortitudeNicknames { get; set; }

    void Awake () {
      parentData = this;
	}
}