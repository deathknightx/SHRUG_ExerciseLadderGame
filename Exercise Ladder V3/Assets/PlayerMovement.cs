using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float xMin = -208f;
	public float xMax = 640f;

	public Vector2 startPos;
	public Vector2 newPos;

	private int desiredFloor;

	public float[] floors = {280f, 170f, 60f, -60f, -170f, -290f};

	public float speed ;

	private float startTime;
	private float journeyLength;

	bool isMoving = false;

	public float[] yPosArray = {280f, 170f, 60f, -60f, -170f, -290f};
	public float[] xPosArray = {-540f, 0, 540f};

	// Use this for initialization
	void Start () 
	{
		generateNextPosition ();
	}

	// Update is called once per frame
	void Update () 
	{
		onReaching ();

		// call when the bar is aligned correctly
		if (Input.GetButton("Fire1"))
		{
			StartWalking ();
		}

		if (isMoving) 
		{
			float disCovered = (Time.time - startTime) * speed;
			float fracJourney = disCovered / journeyLength;

			Vector3 tmp = Vector2.Lerp (startPos, newPos, fracJourney);

			transform.position = tmp;
		}
	}

	bool StartWalking()
	{
		if (isMoving) return false;

		isMoving= true;
		startTime = Time.time;
		return true;
	}

	void generateNextPosition()
	{
		int currentFloor = desiredFloor;
		desiredFloor = floors.Length/floors.Length * yPosArray.Length;

		int barStart = Random.Range (0, currentFloor);
		int barEnd = Random.Range (barStart, 5);

		/*if (currentFloor != desiredFloor)
		{
			for (int i = 5; i - 1 < floors.Length; i--)
			{
				
			}
		}*/

		// Set character positions
		startPos = transform.position;
		newPos = new Vector2(xPosArray[Random.Range(0, xPosArray.Length)], yPosArray[Random.Range(0, yPosArray.Length)]);
		journeyLength = Vector2.Distance (startPos, newPos);

		print (newPos);

	}

	void onReaching()
	{
		if (newPos == new Vector2(transform.position.x, transform.position.y))
		{
			isMoving = false;

			generateNextPosition ();
		}


	}


}
