using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public int victoryCondition = 10;
	public int numStartHouse = 6;
	private static GameManager hanzo = null;
	public PlayerController1 player1;
	private Map worldMap;
	public PlayerController2 player2;
    private int difficulty;

	void Awake() {
		hanzo = this;
	}

	// Use this for initialization
	void Start () {
		worldMap = Map.Instance;
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

    public void SetDifficulty(int value)
    {
        
        switch (value)
        {
            case 0:
                difficulty = 6;
                break;
            case 1:
                difficulty = 7;
                break;
            case 2:
                difficulty = 8;
                break;
            default:
                break;
        }
    }
}
