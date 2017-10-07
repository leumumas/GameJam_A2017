using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    private GameObject _main, _options;

	// Use this for initialization
	void Start () {
        _main = GameObject.Find("Main");
        _options = GameObject.Find("Options");

        _main.SetActive(true);
        _options.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Back()
    {
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
        print("allo");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
