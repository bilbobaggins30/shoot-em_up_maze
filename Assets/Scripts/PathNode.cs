
using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class PathNode
{
	//If True then there exists a wall
	public bool Up = true, Left=true, Down = true, Right = true;
	public int TextVal = 4;
	
	public PathNode(int NodeType)
	{
		switch(NodeType)
		{
			case 33:
			{
				this.Left = false;
				TextVal = 33;
				break;
			}
			case 34:
			{
				this.Down = false;
				TextVal = 34;
				break;
			}
			case 31:
			{
				this.Right = false;
				TextVal = 31;
				break;
			}
			case 32:
			{
				this.Up = false;
				TextVal = 32;
				break;
			}
			case 22:
			{
				this.Up = false;
				this.Down = false;
				TextVal = 22;				
				break;
			}
			case 21:
			{
				this.Left = false;
				this.Right = false;
				TextVal = 21;
				break;
			}
			case 13:
			{
				this.Up = false;
				this.Down = false;
				this.Left = false;
				TextVal = 13;
				break;
			}
			case 14:
			{
				this.Left = false;
				this.Down = false;
				this.Right = false;
				TextVal = 14;
				break;
			}
			case 11:
			{
				this.Up = false;
				this.Down = false;
				this.Right = false;
				TextVal = 11;
				break;
			}
			case 12:
			{
				this.Up = false;
				this.Left = false;
				this.Right = false;
				TextVal = 12;
				break;
			}
			case 5:
			{
				this.Up = false;
				this.Down = false;
				this.Right = false;
				this.Left = false;
				TextVal = 5;
				break;
			}
			case 534:
			{
				this.Left = false;
				this.Down = false;
				TextVal = 534;
				break;
			}
			case 514:
			{
				this.Down = false;
				this.Right = false;
				TextVal = 514;
				break;
			}
			case 512:
			{
				this.Up = false;
				this.Right = false;
				TextVal = 512;
				break;
			}
			case 523:
			{
				this.Up = false;
				this.Left = false;
				TextVal = 523;
				break;
			}
			case 4:
			{
				break;
			}
		}
	}

	public int PathType()
	{
		
		TextVal = CalcPathType(AssignWalls(this.Right,this.Up,this.Left,this.Down));
		return TextVal;
	}

	public int CalcPathType(int Walls)
	{
		switch(Walls)
		{
			case 1111:
			{
				return 4;
			}
			case 1110:
			{
				return 34;
			}
			case 1100:
			{
				return 534;
			}
			case 1000:
			{
				return 13;
			}
			case 0000:
			{
				return 5;
			}
			case 1101:
			{
				return 33;
			}
			case 1001:
			{
				return 523;
			}
			case 1011:
			{
				return 32;
			}
			case 0011:
			{
				return 512;
			}
			case 0111:
			{
				return 31;
			}
			case 0101:
			{
				return 21;
			}
			case 1010:
			{
				return 22;
			}
			case 0110:
			{
				return 514;
			}
			case 0010:
			{
				return 11;
			}
			case 0100:
			{
				return 14;
			}
			case 0001:
			{
				return 12;
			}
			default:
			{
				throw new System.InvalidOperationException("Invalid Wall Setup");
			}
		}
	}

	public int AssignWalls(bool Right, bool Up, bool Left, bool Down)
	{
		int Walls;
		if(Right == true)
		{
			Walls = 1;
		}
		else
		{
			Walls = 0;
		}
		Walls *= 10;
		if(Up == true)
		{
			Walls += 1;
		}
		Walls *= 10;
		if(Left == true)
		{
			Walls += 1;
		}
		Walls *= 10;
		if(Down == true)
		{
			Walls +=1;
		}
		return Walls;
	}

};