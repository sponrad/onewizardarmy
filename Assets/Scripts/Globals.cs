using UnityEngine;

public class Globals : MonoBehaviour 
{
	public static Globals GM;
	public static bool sound = true;
	public static int gold = 0;
	public static string levelScores;

	public static string towersInPlay = "arrow1, arrow1, arrow1, arrow1, arrow1";
	public static string towersOwned = "arrow1, arrow1, arrow1, arrow1, arrow1";

	void Awake()
	{
		if(GM != null)
			GameObject.Destroy(GM);
		else
			GM = this;
		DontDestroyOnLoad(this);

	}
}