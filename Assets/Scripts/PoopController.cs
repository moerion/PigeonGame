using UnityEngine;
using System.Collections;

public class PoopController : MonoBehaviour {
	
	
	//on collision event
	void OnTriggerEnter(Collider other){
		//if colliding with a pickup object
		if (other.gameObject.tag == "PickUp"){
			//deactivate pickup object
			other.gameObject.SetActive(false);
			//destroy self object
			Destroy(gameObject);
		}
	}
	//on collision event
	void OnCollisionEnter(Collision other){
		//if colliding with ground or car object
		if ((other.gameObject.tag == "Ground") | (other.gameObject.tag == "Car")){
			//destroy self object
			Destroy(gameObject);
		}
	}
}
