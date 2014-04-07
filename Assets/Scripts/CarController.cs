using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//start car with black color
		renderer.material.color = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//on collision event 
	void OnCollisionEnter(Collision other){
		//on collision with poop
		if 	(other.gameObject.tag == "Poop"){
			//change car to white color
			renderer.material.color = Color.white;
			//change tage of game object
			gameObject.tag =  "Ground";
		}
	}
}
