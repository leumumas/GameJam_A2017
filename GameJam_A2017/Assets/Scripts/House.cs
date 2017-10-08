using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {

	int Type = 1;
	public int posClient;
	public GameObject prefabCustomer;
    public GameObject vilain;
	GameObject customer, nVilain;
	public int points;
    int vilainSpawn;
	public Timer time;
	public GameObject sold;
	public Animator anim;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		Map.Instance.addHouses (this);
        print("add houses");
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
		Vector3 posFinal = new Vector3();
		switch (posClient) {
		case 0: 
			posFinal = new Vector3(0f,1f,0f);
			break;
		case 1: 
			posFinal = new Vector3(1f,0f,0f);
			break;
		case 2: 
			posFinal = new Vector3(0f,-1f,0f);
			break;
		case 3: 
			posFinal = new Vector3(-1f,0f,0f);
			break;
		}
		customer = Instantiate (prefabCustomer, (gameObject.transform.localPosition + posFinal), Quaternion.identity);
        print("customer instancier");
		customer.transform.SetParent(gameObject.transform);
		customer.GetComponent<Customers> ().curHouse = this;
        time = gameObject.GetComponent<Timer>();
		time.Switch();
	}

	public void lose () {
		gameObject.tag = "Destroy";
		Object[] obSr = Resources.LoadAll ("explosion");
		Sprite sr = (Sprite)obSr [7];
		gameObject.GetComponent<SpriteRenderer> ().sprite = sr;
		gameObject.GetComponent<Collider2D> ().enabled = false;
		Destroy (customer);
		if (nVilain != null)
			Destroy (nVilain);
		Map.Instance.chooseHouse ();
	}

	public void end(bool timeOut) {
		if (timeOut) {
			vilainSpawn = Random.Range (0, 100);
			if (vilainSpawn > 0) {
				nVilain = Vilain.Instantiate (vilain, customer.gameObject.transform.position, Quaternion.identity);
				nVilain.transform.SetParent (this.gameObject.transform);
				nVilain.GetComponent<Vilain> ().curHouse = this;
				Destroy (customer.gameObject);
				print ("Vilain spawned");
				/*for (int i = 0; i < 30; i++) {
					System.Threading.Thread.Sleep (500);
					OnCollisionEnter2D (nVilain.GetComponent<Collision2D> ());
				}
				Destroy (nVilain);*/
			} else {
				/*anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController> ("House");
			System.Threading.Thread.Sleep (1000);*/
				lose ();
			}
		} else {
			if (nVilain != null)
				Destroy (nVilain);
			Destroy (customer);
			sold.SetActive (true);
			Map.Instance.onHouses.Remove (this);
			Map.Instance.chooseHouse ();
			gameObject.tag = "Sold";
		}
	}

    /*private void OnCollisionEnter2D(Collision2D other)
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

            Shifumi();

            if (player.name == "Player1")
            {
                player.GetComponent<PlayerController1>().enabled = true;
            }

            if (player.name == "Player2")
            {
                player.GetComponent<PlayerController2>().enabled = true;

            }
        }
    }*/
}
