//Code pour un Count Down
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text timerText;
    public float timeRemaining = 30;
    //Random random = 0;//
    AudioSource Bruh;
    //private AudioSource playAudio;//

    // Use this for initialization
    void Start()
    {
        //Random(timeRemaining);//
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime; //countdown
        timerText.text = timeRemaining.ToString("f2"); //"f2", pour les décimals
        print(timeRemaining);

        if (timeRemaining <= 0) //Détruire le "gameObjet" attaché si le compteur arrive à 0:00
        {
            //playAudio = Bruh;//
            Destroy(gameObject);
        }
    }


}