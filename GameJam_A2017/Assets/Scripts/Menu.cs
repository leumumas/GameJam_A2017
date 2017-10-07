using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    private GameObject _main, _options;

	// Use this for initialization
	private void Start () {
        _main = GameObject.Find("Main");
        _options = GameObject.Find("Options");

        _main.SetActive(true);
        _options.SetActive(false);
	}

    public void Back()
    {
        Debug.Log("vers menu");
        _main.SetActive(true);
        _options.SetActive(false);
    }

   public void Play()
    {

    }

    public void Options()
    {
        _main.SetActive(false);
        _options.SetActive(true);
        Debug.Log("vers options");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
