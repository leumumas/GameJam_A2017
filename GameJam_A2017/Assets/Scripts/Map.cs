using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

	private static Map hanzo = null;
	private List<House> onHouses = new List<House>();
	private List<House> offHouses = new List<House>();
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
		onHouses.Add (h);
		numHouse++;
		if (numHouse >= numberHouse) {
			Debug.Log ("GG tous les maisons sont là");
			for (int i = 0; i < numberHouse; i++) {
				onHouses[i].typeDefine(Random.Range(0,3));
			}
			for (int i = 0; i < GameManager.Instance.numStartHouse; i++) {
				chooseHouse ();
			}
		}
	}

	public void chooseHouse () {
		if (onHouses.Count > 0) {
			int hou = Random.Range (0, onHouses.Count - 1);
			onHouses [hou].clientComing ();
			offHouses.Add (onHouses [hou]);
			onHouses.RemoveAt (hou);
		} else {
			if (GameObject.FindGameObjectsWithTag("House").Length <= 1)
				GameManager.Instance.endGame (2);
		}
	}
}
