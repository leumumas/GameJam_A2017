using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

	private static Map hanzo = null;
	private List<House> houses = new List<House>();
	int numberHouse;
	int numHouse = 0;

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
		houses.Add (h);
		numHouse++;
		if (numHouse >= numberHouse) {
			Debug.Log ("GG tous les maisons sont là");
		}
	}
}
