using UnityEngine;
using System.Collections;

public class GroundController : MonoBehaviour {
	
	//text box for car count
	public GUIText countText;
	//text box for win message
	public GUIText winText;
	
	//scroll speed variable
	public float scrollSpeed = 10f;
	
	void Start(){
		//initialize win text as blank
		winText.text = "";
	}
	
	
	void Update(){
		//initialize game object array
		GameObject[] gos;
		//fill array with all clean car objects
   		gos = GameObject.FindGameObjectsWithTag("Car");
		
		//number of car objects in scene
		int cars = GameObject.FindGameObjectsWithTag("Car").Length;
		//display number of clean cars
		countText.text = "Clean cars: " + gos.Length.ToString();
		
		//countText.text = Time.time.ToString();
		
		//if no more clean cars
		if (gos.Length == 0){
			//display win text
			winText.text = "YOU WIN!";
		}	
		
	}
	// Update is called once per frame
	void FixedUpdate () {
		//if scroll limit hasnt been reached
		if (transform.position.z > -90){
			//scroll ground
			transform.Translate(-Vector3.forward * scrollSpeed * Time.deltaTime);
		}
	}
}
