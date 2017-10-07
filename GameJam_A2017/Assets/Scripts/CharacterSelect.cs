using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour {

    private int _player1, _player2; //0:Speedy 1:Shadowkitty 2:Mentalist
    private GameObject _buttons1, _buttons2, _continue, _p1, _p2, _chars;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start () {
        _buttons1 = GameObject.Find("Buttons1");
        _buttons2 = GameObject.Find("Buttons2");
        _continue = GameObject.Find("Continue");
        _p1 = GameObject.Find("P1");
        _p2 = GameObject.Find("P2");
        _chars = GameObject.Find("Chars");

        _buttons1.SetActive(true);
        _buttons2.SetActive(false);
        _continue.SetActive(false);
        _chars.SetActive(true);
        _p1.SetActive(true);
        _p2.SetActive(false);
	}

    public void Flosh()
    {
        _buttons1.SetActive(false);
        _buttons2.SetActive(true);
        _continue.SetActive(false);
        _chars.SetActive(true);
        _p1.SetActive(false);
        _p2.SetActive(true);

        _player1 = 0;
    }

    public void Mentalist()
    {
        _buttons1.SetActive(false);
        _buttons2.SetActive(true);
        _continue.SetActive(false);
        _chars.SetActive(true);
        _p1.SetActive(false);
        _p2.SetActive(true);

        _player1 = 2;
    }

    public void ShadowKitty()
    {
        _buttons1.SetActive(false);
        _buttons2.SetActive(true);
        _continue.SetActive(false);
        _chars.SetActive(true);
        _p1.SetActive(false);
        _p2.SetActive(true);

        _player1 = 1;
    }

    public void Flosh1()
    {
        _buttons1.SetActive(false);
        _buttons2.SetActive(false);
        _continue.SetActive(true);
        _chars.SetActive(true);
        _p1.SetActive(false);
        _p2.SetActive(false);

        _player2 = 0;
    }

    public void Mentalist1()
    {
        _buttons1.SetActive(false);
        _buttons2.SetActive(false);
        _continue.SetActive(true);
        _chars.SetActive(true);
        _p1.SetActive(false);
        _p2.SetActive(false);

        _player2 = 2;
    }

    public void ShadowKitty1()
    {
        _buttons1.SetActive(false);
        _buttons2.SetActive(false);
        _continue.SetActive(true);
        _chars.SetActive(true);
        _p1.SetActive(false);
        _p2.SetActive(false);

        _player2 = 1;
    }

    public void Play()
    {
        SceneManager.LoadScene("Samuel");
    }

    public int Player1()
    {
        return _player1;
    }

    public int Player2()
    {
        return _player2;
    }
}
