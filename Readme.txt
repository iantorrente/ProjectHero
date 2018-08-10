//Readme for data flow/architecture || Project Hero v0.1.10
PERSISTENT DATA CLASSES:
1) PlayerData.cs (contains data related to the player)
2) GlobalData.cs (contains data related to the world)
3) ParentData.cs (will only be used in character creation in the future)

DATA GENERATOR CLASSES:
1) ChildPower.cs (generates child power based on passed in parent's powers. Data inside here is placeholder right now.)
2) ParentalPower.cs (generates parent powers based on passed in string from an array of powers)
3) DataInitializer.cs (generates father/mother names and nicknames from JSON. Will probably be generified so any path to a JSON file can be passed and it gets deserialized)

ACTION HANDLERS:
1) CityHandler.cs (handles all buttons)
2) MainMenuHandler.cs (handles main menu buttons and will handle loading/deleting save files in the future. Could probably just have this in CityHandler.cs as well)
3) SavePlayerHandler.cs (handles saving the player's character into persistent data in the character creation. Could rethink the way this is handled)

SYSTEMS CLASSES:
1) EnergyHandler.cs (handles stamina calculations)
2) SimulationHandler.cs (handles global simulations. Currently only simulates population growth and crimes)
3) TimeHandler.cs (handles the flow of time, between cycles of the day (morning, afternoon, evening, midnight), and days, months, and years
4) TrainingHandler.cs (handles increasing player's base stats when training. Currently only has static changes, will probably have variable increases depending on other factors in the future)
5) JobHandler.cs (handles job generation. Right now doesn't have anything)

UNCATEGORIZED:
1) Main.cs (handles actions for character creation. Will need to work on this heavily for the final build.)
2) DisplayData.cs (handles displaying of data depending on the scene and what data needs to be displayed)

//Method flow of buttons
