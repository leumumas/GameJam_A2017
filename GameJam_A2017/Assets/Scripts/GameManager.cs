using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public int victoryCondition = 10;
	private static GameManager hanzo = null;
	public PlayerController1 player1;
	private Map worldMap;
	//public PlayerController2 player2;

	void Awake() {
		hanzo = this;
	}

	// Use this for initialization
	void Start () {
		worldMap = Map.Instance;
		Map m = worldMap;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static GameManager Instance
	{
		get
		{
			return hanzo;
		}

	}
}
