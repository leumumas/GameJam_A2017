using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimationFin : MonoBehaviour {

    public GameObject soldOut;
    public GameObject spriteGagnant;

    public Button btnRestart;

    public Text textHaut;
    public Text textBas;
    public Text scoreText;

    public float reduceSpeed;
    public float typeSpeed;

    public bool isTyping;
    public bool cancelTyping;

    public int scoreP1;
    public int scoreP2;

	void Awake () {
		scoreP1 = GameManager.Instance.p1;
		scoreP2 = GameManager.Instance.p2;
	}

    // Use this for initialization
    IEnumerator Start () {
        textHaut.text = "";
		textBas.text = "";

        btnRestart.enabled = false;    

        SpriteRenderer tmp = soldOut.GetComponent<SpriteRenderer>();
        tmp.color = new Color(1,1,1,1);


        yield return StartCoroutine(reduireTaille(1));

        string monText = "Et le gagnant est...";
        yield return StartCoroutine(TextScroll(monText));

        //Insérer le joueur et son avatar

        yield return new WaitForSeconds(2f);

        int result = 4;

        if (scoreP1 > scoreP2)
            result = 0;
        if (scoreP1 < scoreP2)
            result = 1;
        if (scoreP1 == scoreP2)
            result = 2;

        switch (result) {
            case 0:
                textBas.text = "Joueur 1!!!!";
				spriteGagnant.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.sP1;
                scoreText.text = "Score final: " + scoreP1;
                break;
            case 1:
                textBas.text = "Joueur 2!!!!";
				spriteGagnant.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.sP2;
                scoreText.text = "Score final: " + scoreP2;
                break;
            case 2:
                textBas.text = "Match Nul";

                scoreText.text = "Score final: " + scoreP1;
                break;
        }

        yield return new WaitForSeconds(2f);

        btnRestart.enabled = true;
        btnRestart.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        btnRestart.GetComponentInChildren<Text>().color = new Color(0, 0, 0, 1);
        
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator reduireTaille(float time)
    {
        Vector3 originalScale = soldOut.transform.localScale;
        Vector3 destinationScale = new Vector3(2, 2, 2);

        float currentTime = 0.0f;

        do
        {
            soldOut.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
    }


    private IEnumerator TextScroll(string lineOfText)
    {
        int letter = 0;
        textHaut.text = "";
        isTyping = true;
        cancelTyping = false;

        while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
        {
            textHaut.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);
        }

        textHaut.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    public void TaskOnClick()
    {
        
        Destroy(CharacterSelect.Instance.gameObject);
        Destroy(GameManager.Instance.gameObject);

        SceneManager.LoadScene("Patrick");
    }
}
