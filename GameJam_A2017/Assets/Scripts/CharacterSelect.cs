using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour {

    private int player1, player2;
    private GameObject _buttons1, _buttons2, _continue, _p1, _p2;

	// Use this for initialization
	void Start () {
        _buttons1 = GameObject.Find("Buttons1");
        _buttons2 = GameObject.Find("Buttons2");
        _continue = GameObject.Find("Continue");
        _p1 = GameObject.Find("P1");
        _p2 = GameObject.Find("P2");

        _buttons1.SetActive(true);
        _buttons2.SetActive(false);
        _continue.SetActive(false);
        _p1.SetActive(true);
        _p2.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Flosh()
    {
        _buttons1.SetActive(false);
        _buttons2.SetActive(true);
        _continue.SetActive(false);
        _p1.SetActive(false);
        _p2.SetActive(true);

        player1 = 0;
    }

    public void Mentalist()
    {
        _buttons1.SetActive(false);
        _buttons2.SetActive(true);
        _continue.SetActive(false);
        _p1.SetActive(false);
        _p2.SetActive(true);

        player1 = 2;
    }

    public void ShadowKitty()
    {
        _buttons1.SetActive(false);
        _buttons2.SetActive(true);
        _continue.SetActive(false);
        _p1.SetActive(false);
        _p2.SetActive(true);

        player1 = 1;
    }

    public void Flosh1()
    {
        _buttons1.SetActive(false);
        _buttons2.SetActive(false);
        _continue.SetActive(true);
        _p1.SetActive(false);
        _p2.SetActive(false);

        player2 = 0;
    }

    public void Mentalist1()
    {
        _buttons1.SetActive(false);
        _buttons2.SetActive(false);
        _continue.SetActive(true);
        _p1.SetActive(false);
        _p2.SetActive(false);

        player2 = 2;
    }

    public void ShadowKitty1()
    {
        _buttons1.SetActive(false);
        _buttons2.SetActive(false);
        _continue.SetActive(true);
        _p1.SetActive(false);
        _p2.SetActive(false);

        player2 = 1;
    }
}
