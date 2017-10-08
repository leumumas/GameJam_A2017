using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choix {

	List <List <int>> valueChoice = new List<List <int>>();
	List <List <string>> textChoice = new List<List <string>>();
	public List <string> choice = new List<string>();
	public List <bool> goodAnswer = new List<bool>();


	/*// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}*/

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

	public void setup(int cat, int val, int numChoix) {
		textChoice.Clear ();
		initChoices("assets/Dialogues/ChoixFamille.txt");
		initChoices("assets/Dialogues/ChoixPosition.txt");
		initChoices("assets/Dialogues/ChoixRichesse.txt");
		initChoices("assets/Dialogues/ChoixTerrain.txt");
		initChoices("assets/Dialogues/ChoixTypeRecherche.txt");
		initChoices("assets/Dialogues/ChoixVoisin.txt");
		if (choice.Count > 0) {
			choice.Clear ();
			goodAnswer.Clear ();
		}
		choice.Add (textChoice [cat] [val-1]);
		List <List <string>> textChoiceCopy = new List <List <string>>(textChoice);
		textChoiceCopy [cat].RemoveAt (val-1);
		goodAnswer.Add (true);
		for (int i = 1; i < numChoix; i++) {
			int categ = Random.Range (0, textChoiceCopy.Count);
			int value = Random.Range (0, textChoiceCopy [categ].Count);
			choice.Add (textChoiceCopy [categ][value]);
			textChoiceCopy [categ].RemoveAt (value);
			if (textChoiceCopy [categ].Count <= 0) {
				textChoiceCopy.RemoveAt (categ);
			}
			goodAnswer.Add (false);
		}
	}
}
