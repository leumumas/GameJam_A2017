//Code pour un Count Down
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	private float maxTime;
	float time;
	public Slider timerHud;
	public Text temps;
	bool active;
    

    // Use this for initialization
    void Start()
    {
        //Random(timeRemaining);//
        time = Random.Range(30,60);
		maxTime = time;
		active = false;
		timerHud.gameObject.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
		if (active) {
			// return obj.().ToString();//
			time -= Time.deltaTime; //countdown
			temps.text = time.ToString ("f0"); //"f2", pour les décimals

			if (time <= 0) { //Détruire le "gameObjet" attaché si le compteur arrive à 0:00
				//playAudio = Bruh;//
				House isHouse = gameObject.GetComponent<House> ();
				timerHud.gameObject.SetActive (false);
				active = false;
				isHouse.end (true);
			}
			timerHud.value = time / maxTime;
		}
    }

	public void Switch () {
        print("time");
		if (active) {
			active = false;
			timerHud.gameObject.SetActive (false);
		} else {
			active = true;
			timerHud.gameObject.SetActive (true);
		}
	}
}