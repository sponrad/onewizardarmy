﻿using UnityEngine;

public class Globals : MonoBehaviour 
{
	public static Globals GM;
	public static bool sound = true;
	public static int gold = 0;
	public static string levelScores;

	public static string[] towersInPlay = new string[] {"arrow01", "arrow01", "arrow01", "arrow01", "arrow01"};
	public static string[] towersOwned = new string[] {"arrow01", "arrow01", "arrow01", "arrow01", "arrow01"};


	// *************   GRID LOCATIONS FOR ENEMIES
	public static float gridStartX = -2.44f;
	public static float gridStartY = 6.09f;  //is this the grid or the spawn spot...
	public static float gridXSpacing = 1.22f;
	public static float gridYSpacing = 1.04f;
	public static float gridSpawnY = gridStartY + gridYSpacing;


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




	void Awake()
	{
		if(GM != null)
			GameObject.Destroy(GM);
		else
			GM = this;
		DontDestroyOnLoad(this);

	}
}