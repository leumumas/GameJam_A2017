using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

	private static Map hanzo = null;
	private List<House> onHouses = new List<House>();
	private List<House> offHouses = new List<House>();
	int numberHouse;
	int numHouse = 0;
	private List<int> housesType = new List<int>();


	void Awake() {
		hanzo = this;
		numberHouse = GameObject.FindGameObjectsWithTag("House").Length;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static Map Instance
	{
		get
		{
			return hanzo;
		}

	}

	public void addHouses (House h) {
		onHouses.Add (h);
		numHouse++;
		if (numHouse >= numberHouse) {
			Debug.Log ("GG tous les maisons sont là");
			for (int i = 0; i < numberHouse; i++) {
				onHouses[i].typeDefine(Random.Range(0,3));
			}
		}
	}

	public void chooseHouse () {
		int hou = Random.Range (0, onHouses.Count);
		onHouses[hou].clientComing();
		onHouses.RemoveAt (hou);
	}
}
