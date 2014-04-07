using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	//life duration of poop
	public float poopLife = 1f;
	//movement speed
	public float moveSpeed = 10f;
	//time delay between poop
	public float shootDelay = .5f;
	//time to wait when starting over
	public float waitTime = 5f;
	//max player x location
	public int xMax = 5;
	//max player z location
	public int zMax = 5;
	//number of shields
	public int shields = 0;
	//max number of shields
	public int shieldMax = 3;

	//private int pos;
	//time of most recent poop
	private float shootTime;
	//time of most recent damage
	private float hurtTime;
	
	// Update is called once per frame
	void FixedUpdate () {
		//healing process
		if (hurtTime + 1 < Time.time){
			//heal from red
			if (renderer.material.color == Color.red){
				//change color to yellow
				renderer.material.color = Color.yellow;
			//heal from yellow	
			} else{
				//change color to greeen
				renderer.material.color = Color.green;
			}
		}
		//on key press up arrow
		if(Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        //on key press down arrow
        if(Input.GetKey(KeyCode.DownArrow))
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
		//on key press left arrow
        if(Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
       	//on key press right arrow 
        if(Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
		//on key press S
		if(Input.GetKey(KeyCode.S)){
			if (shields < shieldMax)
				//increment shields
				shields = shields + 1;
		}
			
		Transform child = transform.GetChild(0);

		if (shields == 3){
			//change color to yellow
			child.gameObject.renderer.material.color = Color.green;
			//second damage count	
		} else if (shields == 2){
			//change color to red
			child.gameObject.renderer.material.color = Color.yellow;
			//third damage count	
		} else if (shields == 1){
			//change color to red
			child.gameObject.renderer.material.color = Color.red;
		}	else if (shields == 0){
			child.gameObject.renderer.material.color = Color.clear;		
		}

		//clamp player position between screen limits
		Vector3 pos = transform.position;
		pos.x = Mathf.Clamp(transform.position.x, -xMax, xMax);
		pos.z = Mathf.Clamp(transform.position.z, -zMax, zMax);
		transform.position = pos;
			
		if(Input.GetKey(KeyCode.Space))
		//if(Input.GetKey(KeyCode.Space))
		{
			//if delay time has passed since last shot
			if (shootTime + shootDelay < Time.time){
				//save time of shot
				shootTime = Time.time;
				// Variables declared inside functions don't need to be declared new or public, as their scope is completely within the function.
				
				//instantiate new poop object
	        	GameObject newPoop = Instantiate(Resources.Load("Poop")) as GameObject;
	
	        	 // To set the position of the sphere to the same of the gameobject that this script resides on
				
				//set location of poop object
	       	  	newPoop.transform.position = transform.position + new Vector3(0,-1,0);
				//set size scale of poop object
				newPoop.transform.localScale += new Vector3(0.2f,0.2f,0.2f);
				
	       	  	// Now I assume this is a projectile, so you will want to add a script to control what each projectile will do, lets say it's a class named "ProjectileUpdater.cs"
	
	        	 //newSphere.AddComponent(typeof(ProjectileUpdater));
		
	        	 // We should also face the projectile in the right direction, so set it's rotation to the same as the firing object
	
				//rotate poop object
	        	newPoop.transform.rotation = transform.rotation;
				//destroy poop object after certain time
				Destroy (newPoop, poopLife);
			}
	}
	
	
	/*
	void SetCountText(){
	
		
		
		countText.text = "Count: " + count.ToString();
		if (count >= 4){
				winText.text = "YOU WIN!";
		}
	
	}*/
	}
	
	//function to wait for two seconds
	IEnumerator MyMethod() {
	 Debug.Log("Before Waiting 2 seconds");
	 yield return new WaitForSeconds(waitTime);
	 Debug.Log("After Waiting 2 Seconds");
	}

	//on collision event
	void OnCollisionEnter(Collision other){
		//if no shields
		if (shields == 0){
			//if collision with regular shot
			if (other.gameObject.tag == "Shot"){
				//first damage count
				if (renderer.material.color == Color.green){
					//change color to yellow
					renderer.material.color = Color.yellow;
				//second damage count	
				} else if (renderer.material.color == Color.yellow){
					//change color to red
					renderer.material.color = Color.red;
				//third damage count	
				} else if (renderer.material.color == Color.red){
					//end of life, start over
					MyMethod();
					Application.LoadLevel(Application.loadedLevel);
				}
				//store time of collision
				hurtTime = Time.time;
			}
		//if shields
		} else {
			//decrement shield
			shields = shields - 1;
		}

	}
	
	
}