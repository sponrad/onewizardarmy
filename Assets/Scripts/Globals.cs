using UnityEngine;

public class Globals : MonoBehaviour 
{
	public static Globals GM;
	public static bool sound = true;
	public static int gold = 0;
	public static string levelScores;

	public static string[] towersInPlay = new string[] {"arrow01", "arrow01", "arrow01", "arrow01", "arrow01"};
	public static string[] towersOwned = new string[] {"arrow01", "arrow01", "arrow01", "arrow01", "arrow01"};

	void Awake()
	{
		if(GM != null)
			GameObject.Destroy(GM);
		else
			GM = this;
		DontDestroyOnLoad(this);

	}
}