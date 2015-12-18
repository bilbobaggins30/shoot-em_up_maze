using UnityEngine;
using System.Collections;

public class InteractableObject : MonoBehaviour {

	public string Action = "";

	void OnTriggerEnter(Collider colObject)
	{
		if(colObject.gameObject.tag == "Player")
		{
			switch(Action)
			{
				case "NextLevel":
				MasterController.MainControl.NextLevel();
				break;
			}
		}
	}
}
