using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour {
	
	//heading matrix
	private Vector3 heading;
	//direction matrix
	private Vector3 direction;
	//distance from target
	private float	distance;
	//target object
	private GameObject target;
	//speed of shot
	public float shootSpeed = 5.0f;
	
	// Use this for initialization
	void Start () {
		//define target object as player object
		target = GameObject.FindGameObjectWithTag("Player");
		//calculate distance from target object
		distance = Vector3.Distance(target.transform.position, transform.position);
		//calculate heading of shot
		heading = target.transform.position - transform.position;
		//calculate direction of shot
		direction = heading / distance;
		
	}
	
	// Update is called once per frame
	void Update () {
		//update position of shot object
		transform.position += ( direction * Time.deltaTime * shootSpeed);
	}
	//on event collision
	void OnCollisionEnter(Collision other){
		//destroy self object
		Destroy(gameObject);
	}
}
