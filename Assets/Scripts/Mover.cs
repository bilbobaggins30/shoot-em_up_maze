using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	enum Directions {Right = 1, Forward, Left, Back}

	public GameObject Cam = null;
	public float MoveDistance = 5;
	public int CurrentDirection = 1;
	public int x,z;

	public void Awake()
	{
		x = (int)((this.transform.position.x-2.5)/5);
		z = (int)((this.transform.position.x-2.5)/5);
	}

	public void MoveDirection(int Direction)
	{
		if(Cam == null)
		{
			switch(Direction)
			{
				case 1: //Right
				{
					this.transform.position = this.transform.position + MoveDistance*Vector3.right;
					break;
				}
				case 2: //Forward
				{
					
					this.transform.position = this.transform.position + MoveDistance*Vector3.forward;
					break;
				}
				case 3: //Left
				{
					this.transform.position = this.transform.position + MoveDistance*Vector3.left;
					break;
				}
				case 4: //Back
				{
					this.transform.position = this.transform.position + MoveDistance*Vector3.back;
					break;
				}
				default:
				{
					throw new System.InvalidOperationException("Improper direction imputted - Mover.cs");
				}
			}
		}
		else
		{
			int Choice = CurrentDirection*10 + Direction;
			//First Digit - Player Direction && Second Digit - Button Pressed
			switch(Choice)
			{
				case 11: 
				{
					if(MasterController.MainControl.LevelPath[z,x].Down == true)
					{
						z--;
						this.transform.position = this.transform.position + MoveDistance*Vector3.back;
					}
					break;
				}
				case 12: 
				{
					if(MasterController.MainControl.LevelPath[z,x].Right == true)
					{
						x++;
						this.transform.position = this.transform.position + MoveDistance*Vector3.right;
					}
					break;
				}
				case 13:
				{
					if(MasterController.MainControl.LevelPath[z,x].Up == true)
					{
						z++;
						this.transform.position = this.transform.position + MoveDistance*Vector3.forward;
					}
					break;
				}
				case 14: 
				{
					if(MasterController.MainControl.LevelPath[z,x].Left == true)
					{
						x--;
						this.transform.position = this.transform.position + MoveDistance*Vector3.left;
					}
					break;
				}
				case 21: 
				{
					if(MasterController.MainControl.LevelPath[z,x].Right == true)
					{
						x++;
						this.transform.position = this.transform.position + MoveDistance*Vector3.right;
					}
					break;
				}
				case 22: 
				{
					if(MasterController.MainControl.LevelPath[z,x].Up == true)
					{
						z++;
						this.transform.position = this.transform.position + MoveDistance*Vector3.forward;
					}
					break;
				}
				case 23: 
				{
					if(MasterController.MainControl.LevelPath[z,x].Left == true)
					{
						x--;
						this.transform.position = this.transform.position + MoveDistance*Vector3.left;
					}
					break;
				}
				case 24: 
				{
					if(MasterController.MainControl.LevelPath[z,x].Down == true)
					{
						z--;
						this.transform.position = this.transform.position + MoveDistance*Vector3.back;
					}
					break;
				}
				case 31: 
				{
					if(MasterController.MainControl.LevelPath[z,x].Up == true)
					{
						z++;
						this.transform.position = this.transform.position + MoveDistance*Vector3.forward;
					}
					break;
				}
				case 32: 
				{
					if(MasterController.MainControl.LevelPath[z,x].Left == true)
					{
						x--;
						this.transform.position = this.transform.position + MoveDistance*Vector3.left;
					}
					break;
				}
				case 33: 
				{
					if(MasterController.MainControl.LevelPath[z,x].Down == true)
					{
						z--;
						this.transform.position = this.transform.position + MoveDistance*Vector3.back;
					}
					break;
				}
				case 34: 
				{
					if(MasterController.MainControl.LevelPath[z,x].Right == true)
					{
						x++;
						this.transform.position = this.transform.position + MoveDistance*Vector3.right;
					}
					break;
				}
				case 41: 
				{
					if(MasterController.MainControl.LevelPath[z,x].Left == true)
					{
						x--;
						this.transform.position = this.transform.position + MoveDistance*Vector3.left;
					}
					break;
				}
				case 42: 
				{
					if(MasterController.MainControl.LevelPath[z,x].Down == true)
					{
						z--;
						this.transform.position = this.transform.position + MoveDistance*Vector3.back;
					}
					break;
				}
				case 43: 
				{
					if(MasterController.MainControl.LevelPath[z,x].Right == true)
					{
						x++;
						this.transform.position = this.transform.position + MoveDistance*Vector3.right;
					}
					break;
				}
				case 44: 
				{
					if(MasterController.MainControl.LevelPath[z,x].Up == true)
					{
						z++;
						this.transform.position = this.transform.position + MoveDistance*Vector3.forward;
					}
					break;
				}
				default:
				{
					throw new System.InvalidOperationException("Improper direction imputted - Mover.cs");
				}
			}
		}
	}

	public void RotateCamera(int Direction)
	{	
		if(Cam != null)
		{
			switch(Direction)
			{
				case 0: //Right
				{
					Cam.transform.Rotate(0f,90f, 0f);
					CurrentDirection--;
					if(CurrentDirection < 1) {
						CurrentDirection = 4;
					}
					break;
				}
				case 1: //Forward
				{
					
					Cam.transform.Rotate(0f,-90f, 0f);
					CurrentDirection++;
					if(CurrentDirection > 4) {
						CurrentDirection = 1;
					}
					break;
				}
			}
		}
	}


}
