using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {

	int Type = 1;
	public int posClient;
	bool disponible = true;
	public GameObject prefabCustomer;
	GameObject customer, vilain, nVilain;
	int points;
    int vilainSpawn;


	// Use this for initialization
	void Start () {
		Map.Instance.addHouses (this);
		typeDefine (Type);
	}
	
	// Update is called once per frame
	void Update () {
       
        
    }

	public void typeDefine (int t) {
		Object [] obSr = Resources.LoadAll("Land_SpriteSheet 1");
		Sprite sr = null;
		switch (t) {
		case 0: 
			sr = (Sprite)obSr [5];
			points = 1;
				break;
		case 1: 
			sr = (Sprite)obSr[6];
			points = 2;
				break;
		case 2: 
			sr = (Sprite)obSr[7];
			points = 4;
				break;
		case 3: 
			sr = (Sprite)obSr[8];
			points = 6;
				break;
		}	
		gameObject.GetComponent<SpriteRenderer> ().sprite = sr;
	}

	public void clientComing () {
		disponible = false;
		gameObject.GetComponent<SpriteRenderer> ().color = Color.blue;
		Vector3 posFinal = new Vector3();
		switch (posClient) {
		case 0: 
			posFinal = new Vector3(0f,1.1f,0f);
			break;
		case 1: 
			posFinal = new Vector3(1.1f,0f,0f);
			break;
		case 2: 
			posFinal = new Vector3(0f,-1.1f,0f);
			break;
		case 3: 
			posFinal = new Vector3(-1.1f,0f,0f);
			break;
		}
		customer = Instantiate (prefabCustomer, (gameObject.transform.localPosition + posFinal), Quaternion.identity);
		customer.transform.parent = gameObject.transform;
		Timer time = gameObject.GetComponent<Timer> ();
		time.Switch ();
	}

	public void end(bool timeOut) {
		if (timeOut) {
            vilainSpawn = Random.Range(0, 101);
            if (vilainSpawn > 75)
            {
                nVilain = Vilain.Instantiate(vilain, customer.transform);
                for (int i = 0; i < 30; i++)
                {
                    System.Threading.Thread.Sleep(500);
                    OnCollisionEnter2D(nVilain.GetComponent<Collision2D>());
                }
                Destroy(nVilain);
                Destroy(gameObject);
            }
            else
            { Destroy(gameObject); }
			Map.Instance.chooseHouse ();
		}
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject player;
        if (other.gameObject.name == "Player1" || other.gameObject.name == "Player2")
        {
            player = other.gameObject;

            if (player.name == "Player1")
            {
                player.GetComponent<PlayerController1>().enabled = false;
            }

            if (player.name == "Player2")
            {
                player.GetComponent<PlayerController2>().enabled = false;

            }

            //Combat

            if (player.name == "Player1")
            {
                player.GetComponent<PlayerController1>().enabled = true;
            }

            if (player.name == "Player2")
            {
                player.GetComponent<PlayerController2>().enabled = true;

            }
        }
    }


}
