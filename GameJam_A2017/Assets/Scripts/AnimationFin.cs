using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationFin : MonoBehaviour {

    public GameObject soldOut;

    public Text textHaut;
    public Text textBas;
    public Text scoreText;

    public float reduceSpeed;
    public float typeSpeed;

    public bool isTyping;
    public bool cancelTyping;

	// Use this for initialization
	IEnumerator Start () {
        textHaut.text = "";
        textBas.text = "";    

        SpriteRenderer tmp = soldOut.GetComponent<SpriteRenderer>();
        tmp.color = new Color(1,1,1,1);


        yield return StartCoroutine(reduireTaille(1));

        string monText = "Et le gagnant est...";
        yield return StartCoroutine(TextScroll(monText));

        //Insérer le joueur et son avatar

        yield return new WaitForSeconds(2f);

        textBas.text = "Joueur 1!!!!";

        scoreText.text = "Score final: "/* + ScoreJoueur*/;
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
}
