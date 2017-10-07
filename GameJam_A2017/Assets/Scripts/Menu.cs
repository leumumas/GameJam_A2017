using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    private GameObject _main, _options, _characSelect;

	// Use this for initialization
	private void Start () {
        _main = GameObject.Find("Main");
        _options = GameObject.Find("Options");
        _characSelect = GameObject.Find("Character");

        _main.SetActive(true);
        _options.SetActive(false);
        _characSelect.SetActive(false);
	}

    public void Back()
    {
        _main.SetActive(true);
        _options.SetActive(false);
        _characSelect.SetActive(false);
    }

   public void Play()
    {
        _main.SetActive(false);
        _options.SetActive(false);
        _characSelect.SetActive(true);
    }

    public void Options()
    {
        _main.SetActive(false);
        _options.SetActive(true);
        _characSelect.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
