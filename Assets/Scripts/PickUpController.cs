using UnityEngine;
using System.Collections;

public class PickUpController : MonoBehaviour {
	
	//life duration of poop object
	public float poopLife = 10f; 
	//looking distance
    public float lookAtDistance = 15.0f;
    //attacking stance
	public float attackRange = 10.0f;
    //speed of shot
	public float shootSpeed = 5.0f;
    //damping
	public float damping = 6.0f;
	//delay betwen shots
	public float shootDelay = 1f;
	//attack flag
    private bool isItAttacking = false;
	//distance to target object
	private float distance;
	//target object
    private GameObject target;
	//time of last shot fired
	private float savedTime;
	
	// Use this for initialization
	void Start () {
		//defined player object as target object
		target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		//calculate distance to target object
		distance = Vector3.Distance(target.transform.position, transform.position);
 
		//if outside of looking range
		if (distance > lookAtDistance)
	    {
			//change object to green color
	    	renderer.material.color = Color.green; 
	    }
		
		//if withing looking range
	    if( distance < lookAtDistance)
	    {
			//update attack flag
		    isItAttacking = false;
			//change object to yellow color
		    renderer.material.color = Color.yellow;
		    //face target object
			lookAt ();
	    }   
	    
		//if within attacking range
		if (distance < attackRange)
	    {
			//attack target object
	    	attack ();
	    }
	    
		//if object is attacking
		if (isItAttacking)
	    {
			//if delay time has passed since last shot
			if (savedTime + shootDelay < Time.time){
				
				//save shot time
				savedTime = Time.time;
				//change object to red
		    	renderer.material.color = Color.red;
				//GameObject bullet = Instantiate(bulletPrefab,transform.Find("TSP").transform.position , transform.rotation);
	    
				// Variables declared inside functions don't need to be declared new or public, as their scope is completely within the function.
			
				//create instance of projectile shot object
	    		GameObject shot = Instantiate(Resources.Load("Shot"), transform.position + new Vector3(0,1,0), transform.rotation) as GameObject;
	
	    	 	// To set the position of the sphere to the same of the gameobject that this script resides on
			
				//newPoop.transform.localScale += new Vector3(0.01f,0.01f,0.01f);
			
	   	  		// Now I assume this is a projectile, so you will want to add a script to control what each projectile will do, lets say it's a class named "ProjectileUpdater.cs"
	
	    	 	//newSphere.AddComponent(typeof(ProjectileUpdater));
	
	    	 	// We should also face the projectile in the right direction, so set it's rotation to the same as the firing object
				
	    	 	//newPoop.transform.rotation = transform.rotation;
				
				//clone = Instantiate(projectile, transform.position, transform.rotation);
 
			    // Give the cloned object an initial velocity along the current
			    // object's Z axis
			   // newPoop.transform.position += ( direction * Time.deltaTime * shootSpeed);
							
				
				//newPoop.velocity = transform.TransformDirection( direction * shootSpeed);
				
				//destroy object after some time
				Destroy (shot, poopLife);
			}
		}
	}
 
	//function to make object rotate to face target object when in range
	void lookAt ()
	{
		//calculate required rotation matrix
		Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position);
		//update object rotation matrix
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
	}
	
	//function to attack target object when in range 	
	void attack ()
	{
		//update attack flag
	    isItAttacking = true;
		//change object color to red
	    renderer.material.color = Color.red;
	 
	    //transform.Translate(Vector3.forward * moveSpeed *Time.deltaTime);
		
	}
}
