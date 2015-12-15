using UnityEngine;
using System.Collections;

public class KeyboardControls : MonoBehaviour {

	Mover moveScript;

	void Start()
	{
		moveScript = gameObject.GetComponent<Mover>();
	}
	void Update () {
		if(Input.GetKeyDown(KeyCode.D)) {
			moveScript.MoveDirection(1);
		}
		else if(Input.GetKeyDown(KeyCode.W)) {
			moveScript.MoveDirection(2);
		}
		else if(Input.GetKeyDown(KeyCode.A)) {
			moveScript.MoveDirection(3);
		}
		else if(Input.GetKeyDown(KeyCode.S)) {
			moveScript.MoveDirection(4);
		}
		else if(Input.GetKeyDown(KeyCode.Q)) {
			moveScript.RotateCamera(1);
		}
		else if(Input.GetKeyDown(KeyCode.E)) {
			moveScript.RotateCamera(0);
		}
	}
}
