using UnityEngine;
using System.Collections;


	public class waypointmovement : MonoBehaviour {

		public Transform[] Waypoints;
		public float m_speed = 1.0f;
		public GameObject player1;
		private int i = 0;

		private bool moving = false;

		public void Start() {
			transform.position = Waypoints[0].position;    
		}

		public void Update() {
			if (!moving && i < Waypoints.Length - 1 && Input.GetKeyDown(KeyCode.A)) {
				i++;
				moving = true;
				iTween.MoveTo(player1,iTween.Hash("position",Waypoints[i],"speed",m_speed,"easetype","linear", "oncompletetarget",gameObject, "oncomplete", "Done"));    
			}

		}

		public void Done() {
			moving = false;
		}
	}