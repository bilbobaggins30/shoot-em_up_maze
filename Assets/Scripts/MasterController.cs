using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using UnityEngine.UI;

/*
	public static class StoreConstants {
	public static int numOfAnimals = 2;
	public static int numOfWeapons = 2;
	public static int numOfJetpacks = 1;
	public static int numOfSkins = 1;
}
*/

public class MasterController: MonoBehaviour {

	public static MasterController MainControl;
	//public SpawnLevel LevelSpawner;
	public PathNode[,] LevelPath;
	FileStream SaveFile;

	/*
	int animal;
	int weapon;
	int jetpack;
	int skin;
	bool[] animalOwned = new bool[StoreConstants.numOfAnimals];
	bool[] weaponOwned = new bool[StoreConstants.numOfWeapons];
	bool[] jetpackOwned = new bool[StoreConstants.numOfJetpacks];
	bool[] skinOwned = new bool[StoreConstants.numOfSkins]; 
	int money;
	int score = 0;
	int health;
	UpdateMoneyText moneyText;
	UpdateScoreText scoreText;
	LifeDisplay LifeBar;
	*/

	void Start(){
		//health = 10;
	}
	// Use this for initialization
	void Awake () {
		if (MainControl == null) {
			Application.targetFrameRate = 30;
			DontDestroyOnLoad (this);
			MainControl = this;
			if(!System.IO.File.Exists(Application.persistentDataPath + "/Save.dat"))
			{
				BinaryFormatter bf = new BinaryFormatter();
				//SaveFile = File.Open(Application.persistentDataPath + "/Save.dat", FileMode.Create);
				/*
				animalOwned[0] = true;
				weaponOwned[0] = true;
				jetpackOwned[0] = true;
				skinOwned[0] = true;
				*/
				/*
				PlayerData data = new PlayerData (0,0,0,0,animalOwned,weaponOwned,jetpackOwned, skinOwned, 0);
				bf.Serialize (SaveFile, data);
				SaveFile.Close ();
				animal = 0;
				weapon = 0;
				jetpack = 0;
				skin = 0;
				money = 0;
				*/
			}
			else
			{
				/*
				BinaryFormatter bf = new BinaryFormatter();
				SaveFile = File.Open(Application.persistentDataPath + "/Save.dat", FileMode.Open);
				PlayerData data = (PlayerData)bf.Deserialize(SaveFile);
				SaveFile.Close();
				animal = data.animal;
				weapon = data.weapon;
				jetpack = data.jetpack;
				skin = data.skin;
				animalOwned = (bool[])data.animalOwned.Clone();
				weaponOwned = (bool[])data.weaponOwned.Clone();
				jetpackOwned = (bool[])data.jetpackOwned.Clone();
				skinOwned = (bool[])data.skinOwned.Clone();
				money = data.money;
				*/
			}
			Application.LoadLevel(0);

		} else if (MainControl != this) {
			Destroy(gameObject);
		}
	}

	public void NextLevel()
	{
		Application.LoadLevel(0);
	}

	public void OnLevelWasLoaded()
	{
		if (MainControl == this) {
			int[] nodesToContainThings = new int[1800];
			Maze.checkCorrectness(MenuItems.ImportMap(MenuItems.CreateMaze(30)),30, nodesToContainThings);
			GameObject Finish = Instantiate(Resources.Load("Collectibles/Finish", typeof(GameObject))) as GameObject;
			Finish.transform.position = new Vector3((float)(nodesToContainThings[0]*5+2.5), 0.5f, (float)(nodesToContainThings[1]*5+2.5));
			/*FileStream LoadFile;
			BinaryFormatter bf = new BinaryFormatter();
			string temppath = Application.loadedLevelName;
			string path = "Assets/GameObjectPrefabs/Resources/Levels/"+ temppath + ".dat";
			LoadFile = File.Open(path, FileMode.Open);
			LevelData data = (LevelData)bf.Deserialize(LoadFile);
			LevelPath = data.mapLayout;
			LoadFile.Close ();*/
			/*
			if(Application.loadedLevel > 1)
			{
				GameObject Animal = new GameObject();
				GameObject Weapon;
				GameObject Jetpack;
				LevelSpawner.LevelSpawn(Application.loadedLevel);
				switch (animal) {
				case 0:
				{
					setHealth (0);
					setScore (0);
					Animal = (GameObject)Instantiate(Resources.Load("Animal1"));
					break;
				}
				case 1:
				{
					setHealth (2);
					setScore (0);
					Animal = (GameObject)Instantiate(Resources.Load("Animal2"));
					break;
				}
				}
				switch (weapon) {
				case 0:
				{
					setHealth (0);
					setScore (0);

					Weapon = (GameObject)Instantiate(Resources.Load("Weapon1"));
					Weapon.transform.SetParent(Animal.transform);
					break;
				}
				case 1:
				{

					Weapon = (GameObject)Instantiate(Resources.Load("Weapon2"));
					Weapon.transform.SetParent(Animal.transform);
					break;
				}
				}
				switch (jetpack) {
				case 0:
				{
					Jetpack = (GameObject)Instantiate(Resources.Load("Jetpack1"));
					Jetpack.transform.SetParent(Animal.transform);
					break;
				}
				case 1:
				{
					break;
				}
				}
				Animal.transform.localScale = Vector3.one * 0.005f;
				Animal.GetComponent<PlayerMovement>().joystick = FindObjectOfType<CNAbstractController>();
			}

			if (GameObject.FindGameObjectWithTag ("Score") != null) {
				scoreText = GameObject.FindGameObjectWithTag ("Score").GetComponent<UpdateScoreText> ();
			} else {
				scoreText = null;
			}
			if (GameObject.FindGameObjectWithTag ("Money") != null) {
				moneyText = GameObject.FindGameObjectWithTag ("Money").GetComponent<UpdateMoneyText> ();
			} else {
				moneyText = null;
			}
			if (GameObject.FindGameObjectWithTag("LifeBar") != null)
			{
				LifeBar = GameObject.FindGameObjectWithTag("LifeBar").GetComponent<LifeDisplay>();
			}
			else
			{
				LifeBar = null;
			}
			UIUpdate ();
			*/
		}
	}

	/*
	public int getMoney()
	{
		return money;
	}

	public int getAnimal()
	{
		return animal;
	}

	public int getWeapon()
	{
		return weapon;
	}
	public int getJetpack()
	{
		return jetpack;
	}

	public int getScore()
	{
		return score;
	}

	public void setMoney(int a)
	{
		money = a;
	}
	
	public void setAnimal(int a)
	{
		animal = a;
	}

	public void setWeapon(int a)
	{
		weapon = a;
	}

	public void setJetpack(int a)
	{
		jetpack = a;
	}

	public void addMoney(int a)
	{
		money += a;
	}

	public void subMoney(int a)
	{
		money -= a;
	}

	public void setScore(int a)
	{
		score = a;
	}

	public void addScore(int a)
	{
		score += a;
	}

	public void UIUpdate()
	{
		if (scoreText != null) {
			scoreText.updateScore();
		}
		if (moneyText != null) {
			moneyText.updateMoney();
		}
	}

	public bool checkHealth()
	{
		if (health == 0) {
			return false;
		} else {
			return true;
		}
	}

	public void updateLifeBar()
	{
		if (LifeBar != null) {
			LifeBar.SetHearts(health);
		}
	}

	public void setHealth(int a)
	{
		health = a;
	}

	public void addHealth(int a)
	{
		health += a;
	}

	public void subHealth(int a)
	{
		health -= a;
	}

	public int getHealth()
	{
		return health;
	}
	*/


	public void Save()
	{

		/*
		BinaryFormatter bf = new BinaryFormatter();
		SaveFile = File.Open(Application.persistentDataPath + "/Save.dat", FileMode.Create);
		PlayerData data = new PlayerData (animal, weapon, jetpack, skin, animalOwned, weaponOwned, jetpackOwned, skinOwned, money);
		bf.Serialize (SaveFile, data);
		SaveFile.Close ();
		*/
	}

	public void LoadLevel(int a)
	{
		//score = 0; Only Applicable in Endless Mode
		Save ();
		//LevelSpawner.EndGame ();
		Application.LoadLevel (a);
	}
}

[Serializable]
class PlayerData
{
	/*
	public int animal;
	public int weapon;
	public int jetpack;
	public int skin;
	public bool[] animalOwned = new bool[StoreConstants.numOfAnimals];
	public bool[] weaponOwned = new bool[StoreConstants.numOfWeapons];
	public bool[] jetpackOwned = new bool[StoreConstants.numOfJetpacks];
	public bool[] skinOwned = new bool[StoreConstants.numOfSkins];
	public int money;
	*/
	

	/*int animalData, int weaponData, int jetpackData, int skinData, bool[] animalOwnedData, bool[] weaponOwnedData, bool[] jetpackOwnedData, bool[] skinOwnedData, int moneyData*/	
	public PlayerData()
	{
		/*
		animal = animalData;
		weapon = weaponData;
		jetpack = jetpackData;
		skin = skinData;
		animalOwned = (bool[])animalOwnedData.Clone ();
		weaponOwned = (bool[])weaponOwnedData.Clone ();
		jetpackOwned = (bool[])jetpackOwnedData.Clone ();
		skinOwned = (bool[])jetpackOwnedData.Clone ();
		money = moneyData;
		*/
	}
}
