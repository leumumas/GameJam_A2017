using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textBoxManagerAdpated : MonoBehaviour
{

    public GameObject textBox;

    public Text theText;

    public TextAsset textFile;
    public string[] textLines;

    public TextAsset[] textNPCFile;
    public string[] lignesNPCtmp = new string[6];
    public int[] valeurLignestmp = new int[6];

    public string[] ligneNPC = new string[3];
    public int[] valeurLigne = new int[3];
    public int[] categorie = new int[3];

    public int currentLine;
    public int endAtLine;

	public KeyCode fastButton;

    //public PlayerController player;

    public bool isActive;

    public bool stopPlayerMovement;

    private bool isTyping = false;
    private bool cancelTyping = false;

    public float typeSpeed;



    // Use this for initialization
    void Start()
    {
        //player = FindObjectOfType<PlayerController>();

        int i = 0;
        while(i < 6)
        {
            textFile = textNPCFile[i];
            textLines = textFile.text.Split('\n');


            int rand = Random.Range(0, textLines.Length - 1);
            string tmp = textLines[rand];
            lignesNPCtmp[i] = tmp.Substring(0, tmp.Length - 3);

            valeurLignestmp[i] = (int)char.GetNumericValue(tmp[(tmp.Length-2)]);
            if (valeurLignestmp[i] == 0)
                valeurLignestmp[i] = Random.Range(1, 3);

            i += 1;
        }

        int rand1 = 0, rand2 = 0, rand3 = 0;

        while (rand1 == rand2 || rand1 == rand3 || rand2 == rand3)
        {
            rand1 = Random.Range(0, 5);
            rand2 = Random.Range(0, 5);
            rand3 = Random.Range(0, 5);
        }

        valeurLigne[0] = valeurLignestmp[rand1]; ligneNPC[0] = lignesNPCtmp[rand1]; categorie[0] = rand1;
        valeurLigne[1] = valeurLignestmp[rand2]; ligneNPC[1] = lignesNPCtmp[rand2]; categorie[1] = rand2;
        valeurLigne[2] = valeurLignestmp[rand3]; ligneNPC[2] = lignesNPCtmp[rand3]; categorie[2] = rand3;

        if (endAtLine == 0)
            endAtLine = ligneNPC.Length - 1;

        /*if (isActive)
            EnableTextBox();
        else
            DisableTextBox();*/
    }

    // Update is called once per frame
    void Update()
    {

        if (!isActive)
        {
            return;
        }


		if (Input.GetKeyDown(fastButton))
        {
            if (!isTyping)
            {
                currentLine += 1;

                if (currentLine > endAtLine)
                {
                    DisableTextBox();
                }
                else
                {
                    StartCoroutine(TextScroll(ligneNPC[currentLine]));
                }

            }
            else if (isTyping && !cancelTyping)
            {
                cancelTyping = true;
            }
        }



    }

    private IEnumerator TextScroll(string lineOfText)
    {
        int letter = 0;
        //theText.text = "";
		theText = textBox.GetComponentInChildren<Text>();
		theText.text = "";
        isTyping = true;
        cancelTyping = false;

        while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
        {
            theText.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);
        }

        theText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }


    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;

        StartCoroutine(TextScroll(ligneNPC[currentLine]));

        //if (stopPlayerMovement)
        //Player.canMove = false;
    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;

        //if (!stopPlayerMovement)
        //Player.canMove = true;
    }

    public void ReloadScript(TextAsset theText)
    {
        if (theText != null)
        {
            textLines = new string[1];
            textLines = theText.text.Split('\n');
        }

    }
}
