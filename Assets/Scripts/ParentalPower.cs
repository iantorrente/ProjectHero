using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Initializer for the ParentalPower class that'll be used to initialize present and future powers of parents
public class ParentalPower {
	public string PowerName { get; set; } 
	public int strength { get; set; } //0 - 100
	public int agility { get; set; } //0 - 100
	public int will { get; set; }  //0 - 100
	public int fortitude { get; set; } //0 - 100
	public int popularity { get; set; } //0 - 100
	public ParentalPower (string powerName) {
    //These will be archetypes. The flavor text that shows will have different types of powers based on these archetypes
        if (powerName == "SUPER STRENGTH") {
            PowerName = powerName;
            strength = Random.Range(80, 100);
            agility = Random.Range(30, 50);
            will = Random.Range(50, 65);
            fortitude = Random.Range(55, 75);
            popularity = Random.Range(50, 85);
        } else if (powerName == "TELEKINESIS") {
            PowerName = powerName;
            strength = Random.Range(30, 40);
            agility = Random.Range(40, 50);
            will = Random.Range(85, 100);
            fortitude = Random.Range(65, 90);
            popularity = Random.Range(75, 90);
        } else if (powerName == "PYROMANCY") {
            PowerName = powerName;
            strength = Random.Range(25, 50);
            agility = Random.Range(54, 60);
            will = Random.Range(25, 65);
            fortitude = Random.Range(55, 75);
            popularity = Random.Range(25, 85);
        } else if (powerName == "SHAPESHIFT") {
            PowerName = powerName;
            strength = Random.Range(75, 90);
            agility = Random.Range(65, 90);
            will = Random.Range(15, 45);
            fortitude = Random.Range(30, 80);
            popularity = Random.Range(10, 45);
        }
	}
}
