using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    public int typePlayer1, typePlayer2;
    CharacterSelect player1, player2;

	// Use this for initialization
	void Start () {
        typePlayer1 = player1.Player1();
        typePlayer2 = player2.Player2();
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameStart()
    {
        SceneManager.LoadScene("Samuel");
    }
}
