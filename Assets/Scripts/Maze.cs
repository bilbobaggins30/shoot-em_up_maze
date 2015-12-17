using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Maze {

	public static int checkCorrectness(PathNode[,] Maze, int size, int[] nodesToContainThings)
	{
		int NodeDistanceRequired = 6;
		Queue<int> nodesToCheck = new Queue<int>();
		int[,] lengthArray = new int[size,size];
		bool[,] checkedNodes = new bool[size,size];
		int z = 0;
		for(int y = 0; y < size; y++)
		{
			for(int x = 0; y < size; y++)
			{
				checkedNodes[y,x] = false;
				lengthArray[y,x] = 0;
			}
		}
		int longestPath = 0;
		nodesToCheck.Enqueue(0);
		nodesToCheck.Enqueue(0);
		while(!(nodesToCheck.Count==0))
		{
			int x = nodesToCheck.Dequeue();
			int y = nodesToCheck.Dequeue();
			checkedNodes[y,x] = true;
			if(Maze[y,x].Up)
			{
				lengthArray[y+1,x] = Mathf.Max(lengthArray[y,x]+1, lengthArray[y+1,x]);
				if(lengthArray[y+1,x] > NodeDistanceRequired)
				{
					if(!checkedNodes[y+1,x])
					{
						nodesToContainThings[z++] = x;
						nodesToContainThings[z++] = y+1;
					}
					if(lengthArray[y+1,x] > longestPath)
					{
						longestPath = lengthArray[y+1,x];
					}
				}
				if(!checkedNodes[y+1,x])
				{
					nodesToCheck.Enqueue(x);
					nodesToCheck.Enqueue(y+1);
					checkedNodes[y+1,x] = true;
				}
			}
			if(Maze[y,x].Right)
			{
				lengthArray[y,x+1] = Mathf.Max(lengthArray[y,x]+1, lengthArray[y,x+1]);
				if(lengthArray[y,x+1] > NodeDistanceRequired)
				{
					if(!checkedNodes[y,x+1])
					{
						nodesToContainThings[z++] = x+1;
						nodesToContainThings[z++] = y;
					}
					if(lengthArray[y,x+1] > longestPath)
					{
						longestPath = lengthArray[y,x+1];
					}
				}
				if(!checkedNodes[y,x+1])
				{
					nodesToCheck.Enqueue(x+1);
					nodesToCheck.Enqueue(y);
					checkedNodes[y,x+1] = true;
				}
			}
			if(Maze[y,x].Down)
			{
				lengthArray[y-1,x] = Mathf.Max(lengthArray[y,x]+1, lengthArray[y-1,x]);
				if(lengthArray[y-1,x] > NodeDistanceRequired)
				{
					if(!checkedNodes[y-1,x])
					{
						nodesToContainThings[z++] = x;
						nodesToContainThings[z++] = y-1;
					}
					if(lengthArray[y-1,x] > longestPath)
					{
						longestPath = lengthArray[y-1,x];
					}
				}
				if(!checkedNodes[y-1,x])
				{
					nodesToCheck.Enqueue(x);
					nodesToCheck.Enqueue(y-1);
					checkedNodes[y-1,x] = true;
				}
			}
			if(Maze[y,x].Left)
			{
				lengthArray[y,x-1] = Mathf.Max(lengthArray[y,x]+1, lengthArray[y,x-1]);
				if(lengthArray[y,x-1] > NodeDistanceRequired)
				{
					if(!checkedNodes[y,x-1])
					{
						nodesToContainThings[z++] = x-1;
						nodesToContainThings[z++] = y;
					}
					if(lengthArray[y,x-1] > longestPath)
					{
						longestPath = lengthArray[y,x-1];
					}
				}
				if(!checkedNodes[y,x-1])
				{
					nodesToCheck.Enqueue(x-1);
					nodesToCheck.Enqueue(y);
					checkedNodes[y,x-1] = true;
				}
			}
		}
		return longestPath;
	}


}
