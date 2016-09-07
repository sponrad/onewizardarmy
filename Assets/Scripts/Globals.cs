using UnityEngine;
using System.Collections.Generic;	

public class Globals : MonoBehaviour 
{
	public static Globals GM;
	public static bool sound = true;
	public static int gold = 50;
	public static string levelScores;

	public static List<string> towersInPlay = new List<string> {"empty", "empty", "arrow01", "empty", "empty"};
	//TODO: figure out if i need the owned list
	public static List<string> towersOwned = new List<string> {"arrow01", "arrow01", "arrow01", "arrow01", "arrow01", "fire01", "lightning01"}; 
	public static List<string> towerInventory = new List<string> {"lightning01", "fire01", "arrow01"};

	public static string equippedConsumable = "WizardCandy";
	//public static string[] ownedConsumables = new string[] {"WizardCandy","WizardCandy","WizardCandy","WizardCandy"};
	public static List<string> ownedConsumables = new List<string> {"WizardCandy","WizardCandy","WizardCandy","WizardCandy"};

	public enum towerGambleTypes {fire1, fire2, fire3, fire4, fire5, fire6, cooldown, powerup, misfire};

	public static void getInventory(){
		Debug.Log("called from globals!");
	}

	// *************   GRID LOCATIONS FOR ENEMIES
	public static float gridStartX = -2.44f;
	public static float gridStartY = 6.09f;  //is this the grid or the spawn spot...
	public static float gridXSpacing = 1.22f;
	public static float gridYSpacing = 1.04f;
	public static float gridSpawnY = Globals.gridStartY + Globals.gridYSpacing;


	// *************   TOWER LOCATIONS IN LEVEL
	public static float towerLeftXPos = -2.44f;
	public static float towerRightXpos = 2.44f;
	public static float towerLeftMidXPos = -1.22f;
	public static float towerRightMidXPos = 1.22f;
	public static float towerCenterXPos = 0f;
	public static float towerBotRowYPos = -2.55f;
	public static float towerMidRowYPos = -2.1f;
	public static float towerTopRowYPos = -2.0f;

	public static float [][] towerPositions = new float [][]{
		new float[] {towerLeftXPos, towerBotRowYPos},
		new float[] {towerLeftMidXPos, towerMidRowYPos},
		new float[] {towerCenterXPos, towerTopRowYPos},
		new float[] {towerRightMidXPos, towerMidRowYPos},
		new float[] {towerRightXpos, towerBotRowYPos}
	};


	// *************   POWER UP POSITIONS
	public static float [] equippedConsumablePosition = new float[] {-1.3f, -3.5f};


	void Awake()
	{
		if(GM != null)
			GameObject.Destroy(GM);
		else
			GM = this;
		DontDestroyOnLoad(this);

	}
}