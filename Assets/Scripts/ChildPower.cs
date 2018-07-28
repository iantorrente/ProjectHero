using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Initializer for the ChildPower class that'll be used to initialize present and future powers of children
public class ChildPower {
	//Need power name, mother power, father power, point values for str, agility, will, and fortitude, need base power popularity value, etc.
	public string PowerName { get; set; } 
  public string Description { get; set; }
	public int Strength { get; set; } //0 - 100
	public int Agility { get; set; } //0 - 100
	public int Will { get; set; }  //0 - 100
	public int Fortitude { get; set; } //0 - 100
	public int Popularity { get; set; } //0 - 100
	public ChildPower (ParentalPower fPower, ParentalPower mPower) {
    int[] childAttributes = getGenerationalAttributes(fPower, mPower);
    string fPowerName = fPower.PowerName;
    string mPowerName = mPower.PowerName;
    Strength = childAttributes[0];
    Agility = childAttributes[1];
    Will = childAttributes[2];
    Fortitude = childAttributes[3];
    //We're gonna get into a lot of stuff here alright?
    if (fPowerName == "SUPER STRENGTH" && mPowerName == "SUPER STRENGTH") {
      PowerName = "DEVESTATING MIGHT";
      Description = "Your muscles crackle with power. Even at such a young age your muscles bulge, barely able to contain the raw might stored within them. You've had very little run-ins with villains up to this point, and those you've faced buckled under your sheer power. Your enemies know best not to cross you.";
      Strength = (int)(this.Strength * 1.4f);
    }
    if ((fPowerName == "SUPER STRENGTH" && mPowerName == "TELEKINESIS") || (fPowerName == "TELEKINESIS" && mPowerName == "SUPER STRENGTH")) {
      PowerName = "CONQUER";
      //Could find the strongest between Will and Strength and apply it to both
      Description = "You are a sound mind in a sound body, perfectly balanced in every way. You not only destroy all opposition with sheer power, but also with patience and cunning. You have the ability to make your presence either fearfully intimidating or wonderfully charming, winning over anyone with sheer presence alone.";
    }
    if ((fPowerName == "SUPER STRENGTH" && mPowerName == "PYROMANCY") || (fPowerName == "PYROMANCY" && mPowerName == "SUPER STRENGTH")) {
      PowerName = "EXPLOSION";
      Description = "If it wasn't enough that your fists could decimate boulders, they also combust on impact. The sheer strength of your attacks coupled with the explosions that come right after have left very few standing in your way, even at such a young age.";
    }
    if ((fPowerName == "SUPER STRENGTH" && mPowerName == "SHAPESHIFT") || (fPowerName == "SHAPESHIFT" && mPowerName == "SUPER STRENGTH")) {
      PowerName = "RAVAGE FORM";
      Fortitude = (int)(this.Fortitude * 1.2f);
      Description = "Your muscles bulge and tear, your bones protrude and harden. At will you are able to become a being of pure power: a carnal thing with a hunger for decimation. You have a form that you only refer to as 'Ravager'. Others know it as 'Monster'. Whatever title you wear one thing is certain: the world has not seen destruction as grand as you've made.";
    }
    if ((fPowerName == "TELEKINESIS" && mPowerName == "TELEKINESIS")) {
      PowerName = "PSION";
      Will = (int)(this.Will * 1.4f);
      Description = "Your parents were strong psychics in their own right, but you are even more than they could ever achieve. At a young age you could bend cars like hair in your fingers, growing up you could cause the clouds to stir on a whim. Your eyes see both the present and the future, a skill that neither of your parents possessed. You are an immensely powerful Psion. The world will bend at your feet whether they wish to or not.";
    }
    if ((fPowerName == "TELEKINESIS" && mPowerName == "PYROMANCY") || (fPowerName =="PYROMANCY" && mPowerName == "TELEKINESIS")) {
      PowerName = "FIRE CALLER";
      Description = "The flames have always heard your whispers. They mold and take shape in your fingertips, like sentient beings of their own. In the beginning you could only make small wisps dance around in your hands. Now you can sculpt fire into bodies. You can form flames into grand monstrosities. They listen to your word, revel in it, bask in it. You are what gave birth to them. You are their god.";
    }
    if ((fPowerName == "TELEKINESIS" && mPowerName == "SHAPESHIFT") || fPowerName == "SHAPESHIFT" && mPowerName == "TELEKINESIS") {
      PowerName = "MIND CONTROL";
      Description = "First it's a whisper. Your target looks around, trying to understand the sounds in their head. Then it's a suggestion. Walk here, stand there, hand me that apple. At first it's an urge, but then it's a command. As your powers grow you can compel more and more to action. For now two or three, but in the future who can tell? Who's to say there will even be a limit?";
    }
    if (fPowerName == "PYROMANCY" && mPowerName == "PYROMANCY") {
      PowerName = "FIRESTORM";
      Description = "You are the sun, powerful and awesome. You are the light, radient and beautiful. You are the firestorm, consuming everything as you wish. The world burns with your steps. The flames will purify all. There can be nothing left in the wake of your fire.";
      Fortitude = (int)(this.Fortitude * 1.4f);
    }
    if ((fPowerName == "PYROMANCY" && mPowerName == "SHAPESHIFT") || fPowerName == "SHAPESHIFT" && mPowerName == "PYROMANCY") {
      PowerName = "FLAME ASPECT";
      Description = "Your body is engulfed in flames as you see fit.";
    }
    if (fPowerName == "SHAPESHIFT" && mPowerName == "SHAPESHIFT") {
      PowerName = "A THOUSAND FACES";
      Description = "Your mastery over forms allows you to become anything you've ever dreamed of. It only takes one look for you to imitate someone completely.";
      Agility = (int)(this.Agility * 1.4f);
    }
	}

  int[] getGenerationalAttributes (ParentalPower father, ParentalPower mother) {
    int cStrength = Mathf.RoundToInt((((father.Strength + mother.Strength) /2) * 0.25f));
    int cAgility = Mathf.RoundToInt((((father.Agility + mother.Agility) /2) * 0.25f));
    int cWill = Mathf.RoundToInt((((father.Will + mother.Will) /2) * 0.25f));
    int cFortitude = Mathf.RoundToInt((((father.Fortitude + mother.Fortitude) /2) * 0.25f));

    int[] attributesArray = new int[] {
      cStrength, cAgility, cWill, cFortitude
    };

    return attributesArray;
  }

	//Need to create methods that take parents' attributes (strength, agility, etc.) and create the child's attribute based on them

	/*Could create a table of set data for child powers and which parental powers make it. Attributes have their ranges and are used
	by this constructor to generate the final child power
	*/
}
