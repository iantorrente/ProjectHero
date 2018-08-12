using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Initializer for the ChildPower class that'll be used to initialize present and future powers of children
public class ChildPower {
	//Need power name, mother power, father power, point values for str, agility, will, and fortitude, need base power popularity value, etc.
	public string powerName { get; set; } 
	public string description { get; set; }
	public double strength { get; set; } //0 - 100
	public double agility { get; set; } //0 - 100
	public double will { get; set; }  //0 - 100
	public double fortitude { get; set; } //0 - 100
	public double popularity { get; set; } //0 - 100

	public ChildPower (ParentalPower fPower, ParentalPower mPower) {
    double[] childAttributes = getGenerationalAttributes(fPower, mPower);
    string fPowerName = fPower.PowerName;
    string mPowerName = mPower.PowerName;
    strength = childAttributes[0];
    agility = childAttributes[1];
    will = childAttributes[2];
    fortitude = childAttributes[3];
    //We're gonna get into a lot of stuff here alright?
    //TODO: SEPARATE OUT INTO ITS OWN JSON FILE
    if (fPowerName == "SUPER STRENGTH" && mPowerName == "SUPER STRENGTH") {
      powerName = "DEVESTATING MIGHT";
      description = "Your muscles crackle with power. Even at such a young age your muscles bulge, barely able to contain the raw might stored within them. You've had very little run-ins with villains up to this point, and those you've faced buckled under your sheer power. Your enemies know best not to cross you.";
      strength = this.strength * 1.4f;
    }
    if ((fPowerName == "SUPER STRENGTH" && mPowerName == "TELEKINESIS") || (fPowerName == "TELEKINESIS" && mPowerName == "SUPER STRENGTH")) {
      powerName = "CONQUER";
      //Could find the strongest between Will and Strength and apply it to both
      description = "You are a sound mind in a sound body, perfectly balanced in every way. You not only destroy all opposition with sheer power, but also with patience and cunning. You have the ability to make your presence either fearfully intimidating or wonderfully charming, winning over anyone with sheer presence alone.";
    }
    if ((fPowerName == "SUPER STRENGTH" && mPowerName == "PYROMANCY") || (fPowerName == "PYROMANCY" && mPowerName == "SUPER STRENGTH")) {
      powerName = "EXPLOSION";
      description = "If it wasn't enough that your fists could decimate boulders, they also combust on impact. The sheer strength of your attacks coupled with the explosions that come right after have left very few standing in your way, even at such a young age.";
    }
    if ((fPowerName == "SUPER STRENGTH" && mPowerName == "SHAPESHIFT") || (fPowerName == "SHAPESHIFT" && mPowerName == "SUPER STRENGTH")) {
      powerName = "RAVAGE FORM";
      fortitude = this.fortitude * 1.2f;
      description = "Your muscles bulge and tear, your bones protrude and harden. At will you are able to become a being of pure power: a carnal thing with a hunger for decimation. You have a form that you only refer to as 'Ravager'. Others know it as 'Monster'. Whatever title you wear one thing is certain: the world has not seen destruction as grand as you've made.";
    }
    if ((fPowerName == "TELEKINESIS" && mPowerName == "TELEKINESIS")) {
      powerName = "PSION";
      will = this.will * 1.4f;
      description = "Your parents were strong psychics in their own right, but you are even more than they could ever achieve. At a young age you could bend cars like hair in your fingers, growing up you could cause the clouds to stir on a whim. Your eyes see both the present and the future, a skill that neither of your parents possessed. You are an immensely powerful Psion. The world will bend at your feet whether they wish to or not.";
    }
    if ((fPowerName == "TELEKINESIS" && mPowerName == "PYROMANCY") || (fPowerName =="PYROMANCY" && mPowerName == "TELEKINESIS")) {
      powerName = "FIRE CALLER";
      description = "The flames have always heard your whispers. They mold and take shape in your fingertips, like sentient beings of their own. In the beginning you could only make small wisps dance around in your hands. Now you can sculpt fire into bodies. You can form flames into grand monstrosities. They listen to your word, revel in it, bask in it. You are what gave birth to them. You are their god.";
    }
    if ((fPowerName == "TELEKINESIS" && mPowerName == "SHAPESHIFT") || fPowerName == "SHAPESHIFT" && mPowerName == "TELEKINESIS") {
      powerName = "MIND CONTROL";
      description = "First it's a whisper. Your target looks around, trying to understand the sounds in their head. Then it's a suggestion. Walk here, stand there, hand me that apple. At first it's an urge, but then it's a command. As your powers grow you can compel more and more to action. For now two or three, but in the future who can tell? Who's to say there will even be a limit?";
    }
    if (fPowerName == "PYROMANCY" && mPowerName == "PYROMANCY") {
      powerName = "FIRESTORM";
      description = "You are the sun, powerful and awesome. You are the light, radient and beautiful. You are the firestorm, consuming everything as you wish. The world burns with your steps. The flames will purify all. There can be nothing left in the wake of your fire.";
      fortitude = this.fortitude * 1.4f;
    }
    if ((fPowerName == "PYROMANCY" && mPowerName == "SHAPESHIFT") || fPowerName == "SHAPESHIFT" && mPowerName == "PYROMANCY") {
      powerName = "FLAME ASPECT";
      description = "Your body is engulfed in flames as you see fit.";
    }
    if (fPowerName == "SHAPESHIFT" && mPowerName == "SHAPESHIFT") {
      powerName = "A THOUSAND FACES";
      description = "Your mastery over forms allows you to become anything you've ever dreamed of. It only takes one look for you to imitate someone completely.";
      agility = this.agility * 1.4f;
    }
	}

  double[] getGenerationalAttributes (ParentalPower father, ParentalPower mother) {
    double cStrength = (((father.strength + mother.strength) /2) * 0.25f);
    double cAgility = (((father.agility + mother.agility) /2) * 0.25f);
    double cWill = (((father.will + mother.will) /2) * 0.25f);
    double cFortitude = (((father.fortitude + mother.fortitude) /2) * 0.25f);

    double[] attributesArray = new double[] {
      cStrength, cAgility, cWill, cFortitude
    };

    return attributesArray;
  }
}
