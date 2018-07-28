using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Initializer for the ParentalPower class that'll be used to initialize present and future powers of parents
public class ParentalPower {
	public string PowerName { get; set; } 
	public int Strength { get; set; } //0 - 100
	public int Agility { get; set; } //0 - 100
	public int Will { get; set; }  //0 - 100
	public int Fortitude { get; set; } //0 - 100
	public int Popularity { get; set; } //0 - 100
	public ParentalPower (string powerName) {
    //These will be archetypes. The flavor text that shows will have different types of powers based on these archetypes
        if (powerName == "SUPER STRENGTH") {
            PowerName = powerName;
            Strength = Random.Range(80, 100);
            Agility = Random.Range(30, 50);
            Will = Random.Range(50, 65);
            Fortitude = Random.Range(55, 75);
            Popularity = Random.Range(50, 85);
        } else if (powerName == "TELEKINESIS") {
            PowerName = powerName;
            Strength = Random.Range(30, 40);
            Agility = Random.Range(40, 50);
            Will = Random.Range(85, 100);
            Fortitude = Random.Range(65, 90);
            Popularity = Random.Range(75, 90);
        } else if (powerName == "PYROMANCY") {
            PowerName = powerName;
            Strength = Random.Range(25, 50);
            Agility = Random.Range(54, 60);
            Will = Random.Range(25, 65);
            Fortitude = Random.Range(55, 75);
            Popularity = Random.Range(25, 85);
        } else if (powerName == "SHAPESHIFT") {
            PowerName = powerName;
            Strength = Random.Range(75, 90);
            Agility = Random.Range(65, 90);
            Will = Random.Range(15, 45);
            Fortitude = Random.Range(30, 80);
            Popularity = Random.Range(10, 45);
        }
	}
}
