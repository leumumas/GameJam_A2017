using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    private GameObject _main, _options, _characSelect, _chars;

	// Use this for initialization
	private void Start () {
        _main = GameObject.Find("Main");
        _options = GameObject.Find("Options");
        _characSelect = GameObject.Find("Character");
        _chars = GameObject.Find("Chars");

        _main.SetActive(true);
        _options.SetActive(false);
        _characSelect.SetActive(false);
        _chars.SetActive(false);
	}

    public void Back()
    {
        _main.SetActive(true);
        _options.SetActive(false);
        _characSelect.SetActive(false);
        _chars.SetActive(false);
    }

   public void Play()
    {
        _main.SetActive(false);
        _options.SetActive(false);
        _characSelect.SetActive(true);
        _chars.SetActive(true);
    }

    public void Options()
    {
        _main.SetActive(false);
        _options.SetActive(true);
        _characSelect.SetActive(false);
        _chars.SetActive(false);
    }

    public int Easy()
    {
        return 0;
    }

    public int Medium()
    {
        return 1;
    }

    public int Hard()
    {
        return 2;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
