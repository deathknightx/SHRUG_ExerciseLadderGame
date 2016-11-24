using UnityEngine;
using System.Collections;

public class PixelPerfectCamera : MonoBehaviour {

	public static float pixelstoUnits = 1f;
	public static float scale = 1f;

	public Vector2 nativeResolution = new Vector2 (240, 160);

	void Awake () {

		var camera = GetComponent<Camera> ();

		if (camera.orthographic) {

			scale = Screen.height / nativeResolution.y;
			pixelstoUnits *= scale;
			camera.orthographicSize = (Screen.height / 2.0f) / pixelstoUnits;
		}
	
	}

}
