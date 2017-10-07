﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour {

	public TextAsset theText;

	public int startLine;
	public int endLine;

	public textBoxManager theTextBox;

	public bool requireButtonPress;
	private bool waitForPress;

	public bool destoryWhenActivated;

	// Use this for initialization
	void Start () {
		theTextBox = FindObjectOfType<textBoxManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*if (waitForPress && Input.GetKeyDown(KeyCode.J)) {
			theTextBox.ReloadScript (theText);
			theTextBox.currentLine = startLine;
			theTextBox.endAtLine = endLine;
			theTextBox.EnableTextBox ();

			if (destoryWhenActivated)
				Destroy (gameObject);
		}*/

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.name == "Player") {

			if (requireButtonPress) {
				waitForPress = true;
				return;
			}

			theTextBox.ReloadScript (theText);
			theTextBox.currentLine = startLine;
			theTextBox.endAtLine = endLine;
			theTextBox.EnableTextBox ();

			if (destoryWhenActivated) {
				Destroy (gameObject);
			}
		}

	}


	void OnTriggerExit2D(Collider2D other)
	{
		if(other.name == "Player"){
			waitForPress = false;
		}
	}
}
