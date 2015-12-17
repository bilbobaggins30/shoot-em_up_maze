using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

public class CreateMazeDialog : EditorWindow {
	string MazeSizeText = "5";
	
	// Add menu named "My Window" to the Window menu
	[MenuItem ("Tools/Create Map", false, 1)]
	static void Init () {
		// Get existing open window or if none, make a new one:
		EditorWindow Dialog = (CreateMazeDialog)ScriptableObject.CreateInstance(typeof(CreateMazeDialog));
		Dialog.position = new Rect(Screen.width/2,Screen.height/2, 250, 75);
		Dialog.ShowPopup();
	}
	
	void OnGUI () {
		int MazeSize;
		GUILayout.Label ("Create Maze", EditorStyles.boldLabel);
		MazeSizeText = EditorGUILayout.TextField ("Maze is Y x Y, Y = ", MazeSizeText);
		int.TryParse(MazeSizeText, out MazeSize);
		if(GUILayout.Button("Generate Maze"))
		{

			MenuItems.CreateMaze(MazeSize,true);
			this.Close();
		}
	}
}

public class MenuItems : MonoBehaviour
{
	[MenuItem("Tools/Import Map", false, 2)]
	public static PathNode[,] ImportMap(string lines = "empty")
	{
		string text;
		if(lines == "empty")
		{
			string path = EditorUtility.OpenFilePanel("Open Map File","","txt");
			text = File.ReadAllText(path);
		}
		else
		{
			text = lines;
		}
		string[] numbers = text.Split(',',' ','\n');
		List<int> maze = new List<int>();
		foreach(string number in numbers)
		{
			int temp;
			if(Int32.TryParse(number, out temp))
			{
				maze.Add(temp);
			}
		}
		PathNode[,] mapLayout = new PathNode[maze[0],maze[0]];
		int j = maze[0]-1, k = 0;
		for(int i = maze.Count -1; i > 0; i--)
		{
			if(j < 0)
			{
				j = maze[0]-1;
				k++;
			}
			RoomInsert(k,j,maze[i]);
			mapLayout[k,j--] = new PathNode(maze[i]);
		}
		if(lines == "empty")
		{
			SaveMapPath(mapLayout);
		}
		return mapLayout;
	}

	private static void RoomInsert(int y, int x, int RoomType)
	{
		int RoomInc = 5;
		GameObject Room;
		switch(RoomType)
		{
			case 11:
			{
				Room = Instantiate(Resources.Load("Rooms/1WayRoom1", typeof(GameObject))) as GameObject;
				break;
			}
			case 12:
			{
				Room = Instantiate(Resources.Load("Rooms/1WayRoom2", typeof(GameObject))) as GameObject;
				break;
			}
			case 13:
			{
				Room = Instantiate(Resources.Load("Rooms/1WayRoom3", typeof(GameObject))) as GameObject;
				break;
			}
			case 14:
			{
				Room = Instantiate(Resources.Load("Rooms/1WayRoom4", typeof(GameObject))) as GameObject;
				break;
			}
			case 21:
			{
				Room = Instantiate(Resources.Load("Rooms/2WayRoomV", typeof(GameObject))) as GameObject;
				break;
			}
			case 22:
			{
				Room = Instantiate(Resources.Load("Rooms/2WayRoomH", typeof(GameObject))) as GameObject;
				break;
			}
			case 31:
			{
				Room = Instantiate(Resources.Load("Rooms/3WayRoom1", typeof(GameObject))) as GameObject;
				break;
			}
			case 32:
			{
				Room = Instantiate(Resources.Load("Rooms/3WayRoom2", typeof(GameObject))) as GameObject;
				break;
			}
			case 33:
			{
				Room = Instantiate(Resources.Load("Rooms/3WayRoom3", typeof(GameObject))) as GameObject;
				break;
			}
			case 34:
			{
				Room = Instantiate(Resources.Load("Rooms/3WayRoom4", typeof(GameObject))) as GameObject;
				break;
			}
			case 4:
			{
				Room = Instantiate(Resources.Load("Rooms/OpenRoom", typeof(GameObject))) as GameObject;
				break;
			}
			case 512:
			{
				Room = Instantiate(Resources.Load("Rooms/Corner12", typeof(GameObject))) as GameObject;
				break;
			}
			case 523:
			{
				Room = Instantiate(Resources.Load("Rooms/Corner23", typeof(GameObject))) as GameObject;
				break;
			}
			case 534:
			{
				Room = Instantiate(Resources.Load("Rooms/Corner34", typeof(GameObject))) as GameObject;
				break;
			}
			case 514:
			{
				Room = Instantiate(Resources.Load("Rooms/Corner14", typeof(GameObject))) as GameObject;
				break;
			}
			case 5:
			{
				Room = Instantiate(Resources.Load("Rooms/Closed", typeof(GameObject))) as GameObject;
				break;
			}
			default:
			{
				throw new System.InvalidOperationException("Invalid Room Value in File");
			}
		}
		Room.transform.position = new Vector3(x*RoomInc, 0, y*RoomInc);
	}

	private static void SaveMapPath(PathNode[,] mapLayout)
	{
		FileStream SaveFile;
		BinaryFormatter bf = new BinaryFormatter();
		string temppath = EditorApplication.currentScene;
		string path = "Assets/GameObjectPrefabs/Resources/Levels/"+ temppath.Substring(14,temppath.IndexOf(".unity")-14) + ".dat";
		SaveFile = File.Open(path, FileMode.Create);
		LevelData data = new LevelData (mapLayout);
		bf.Serialize (SaveFile, data);
		//LevelData newdata = (LevelData)bf.Deserialize(SaveFile); //Deserialize file
		SaveFile.Close ();
	}

	public static string CreateMaze(int MazeSize, bool Save = false)
	{
		PathNode[,] MazeArray = new PathNode[MazeSize,MazeSize];
		MazeArray[0,0] = new PathNode(534);
		MazeArray[0,MazeSize-1] = new PathNode(514);
		MazeArray[MazeSize-1,0] = new PathNode(523);
		MazeArray[MazeSize-1,MazeSize-1] = new PathNode(512);
		for(int i = 1; i < MazeSize-1; i++)
		{
			MazeArray[0,i] = new PathNode(34);
			MazeArray[MazeSize-1,i] = new PathNode(32);
			MazeArray[i,0] = new PathNode(33);
			MazeArray[i,MazeSize-1] = new PathNode(31);
		}
		for(int i = 1; i < MazeSize-1; i++)
		{
			for (int j = 1; j < MazeSize-1; j++)
			{
				MazeArray[i,j] = new PathNode(4);
			}
		}
		MazeRunner(ref MazeArray, MazeSize);
		

		//Create Maze with remaining spaces	
		string[] lines = new string[MazeSize+1];
		lines[0] = Convert.ToString(MazeSize);
		int a = 1;
		for(int i = MazeSize-1; i >= 0; i--)
		{
			string temp = null;
			for(int j = 0; j < MazeSize; j++)
			{
				if(temp == null)
				{
					temp = Convert.ToString(MazeArray[i,j].TextVal);
				}
				else
				{
					temp += Convert.ToString(MazeArray[i,j].TextVal);
				}				
				if(j == MazeSize - 1)
				{
					lines[a++] = temp;
				}
				else
				{
					temp += ",";
				}
			}
		}
		if(Save)
		{
			String path = EditorUtility.SaveFilePanel("Save Maze","","","txt");
			File.WriteAllLines(path,lines);
		}
		return String.Join("\n",lines);
	}

	public static void MazeRunner(ref PathNode[,] Maze, int MazeSize)
	{
		int NUMBEROFWALLS = 5; //At least 3 or larger
		bool LastRow = false;
		System.Random lottery = new System.Random();
		for(int i = 0; i < MazeSize; i++)
		{
			if (i == MazeSize-1)
			{
				LastRow = true;
			}
			for (int j = 0; j < MazeSize; j++)
			{
				int choice;
				choice = lottery.Next(NUMBEROFWALLS);
				if(choice == 0)
				{
					//Right
					Maze[i,j].Right = false;
					if(j != MazeSize-1)
					{
						Maze[i,j+1].Left = false;
					}
				}
				else if(choice == 1 && !LastRow)
				{
					Maze[i,j].Right = false;
					if(j != MazeSize-1)
					{
						Maze[i,j+1].Left = false;
					}
					Maze[i,j].Up = false;
					if(!LastRow)
					{
						Maze[i+1,j].Down = false;
					}
				}
				else if(choice == 2 && !LastRow)
				{
					Maze[i,j].Up = false;
					if(!LastRow)
					{
						Maze[i+1,j].Down = false;
					}
				}
				Maze[i,j].PathType();
			}
		}
	}

}


[Serializable]
class LevelData
{
	public PathNode[,] mapLayout;
	
	public LevelData(PathNode[,] mapData)
	{
		mapLayout = (PathNode[,]) mapData.Clone();
	}
}
