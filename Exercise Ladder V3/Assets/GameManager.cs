using UnityEngine;
using System.Collections;
using SWS;

public class GameManager : MonoBehaviour {

	public PathManager theWP;

	public Vector3[] waypoints = new Vector3[]{};

	// Use this for initialization
	void Start () 
	{
		theWP = FindObjectOfType<PathManager> ();
		theWP.waypoints [1].localPosition.Set (50.0f, 50.0f, -3f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		foreach(Transform w in theWP.waypoints)
		{
			//print (w.localPosition);
		}

	}
}
