using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public int victoryCondition = 10;
	public int numStartHouse = 10;
	private static GameManager hanzo = null;
	public PlayerController1 player1;
	private Map worldMap;
	public PlayerController2 player2;
	public int p1, p2;
	public Sprite sP1, sP2;
	bool fini = false;

	void Awake() {
		DontDestroyOnLoad (gameObject);
		hanzo = this;
	}

	// Use this for initialization
	void Start () {
		worldMap = Map.Instance;
		if (CharacterSelect.Instance == null)
			victoryCondition = 1;
		else
			victoryCondition = CharacterSelect.Instance.GetDifficulty() * 1;
		Debug.Log ("victoryCondition:" + victoryCondition);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectsWithTag ("House").Length <= 0 && !fini) {
			fini = true;
			endGame (3);
		}
	}

	public static GameManager Instance
	{
		get
		{
			return hanzo;
		}

	}

	public void But() {
		Debug.Log ("Allo");
	}

    public void Flosh()
    {
        player1.TypeChange(0);
    }

    public void ShadowKitty()
    {
        player1.TypeChange(1);
    }

    public void Mentalist()
    {
        player1.TypeChange(2);
    }

	public void endGame(int result) {
		/*player1.canWalk = false;
		player2.canWalk = false;*/
		p1 = player1.points;
		sP1 = player1.gameObject.GetComponent<SpriteRenderer> ().sprite;
		p2 = player2.points;
		sP2 = player2.gameObject.GetComponent<SpriteRenderer> ().sprite;
		SceneManager.LoadScene ("Jean-Philippe");
		/*switch (result) {
		case 0: //victoire p1
			Debug.Log("Bravo P1 !!!");
			break;
		case 1: //victoire p2
			Debug.Log("Bravo P2 !!!");
			break;
		case 2: //plus de maison
			break;
		}*/
	}
}
