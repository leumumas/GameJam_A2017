using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choix : MonoBehaviour {

	List <List <int>> valueChoice = new List<List <int>>();
	List <List <string>> textChoice = new List<List <string>>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void initChoices(string path) {
		List <int> curValueChoice = new List<int>();
		List <string> curTextChoice = new List<string>();
		string[] lines = System.IO.File.ReadAllLines (@path);
		for (int i = 0; i < lines.Length; i++) {
			curTextChoice.Add( lines [i].Substring (0, lines [i].Length - 2));
			char st =  (lines [i] [lines [i].Length - 1]);
			curValueChoice.Add ((int)char.GetNumericValue(lines[i][lines [i].Length - 1]));
		}
		valueChoice.Add (curValueChoice);
		textChoice.Add (curTextChoice);
	}
}
