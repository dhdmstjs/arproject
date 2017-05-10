using UnityEngine;
using System.Collections;

public class LaserEyeDeath : MonoBehaviour {

	public int gunDamage = 1;											// Set the number of hitpoints that this gun will take away from shot objects with a health script
	public float weaponRange = 50f;										// Distance in Unity units over which the player can fire
	public Transform eyeEnd;	// Holds a reference to the gun end object, marking the muzzle location of the gun	
	private AudioSource gunAudio;	//laser sound									// Reference to the audio source which will play our shooting sound effect
	private LineRenderer laserLine;										// Reference to the LineRenderer component which will display our laserline

	void Start () 
	{
		// Get and store a reference to our LineRenderer component
		laserLine = GetComponent<LineRenderer>();

		// Get and store a reference to our AudioSource component
		gunAudio = GetComponent<AudioSource>();

	}


	void Update () 
	{
			// Turn on our line renderer
			laserLine.enabled = true;
			gunAudio.Play (); 

			// Create a vector at the center of our camera's viewport
			//change this to shoot out of guard //rayOrigina = guard 
			Vector3 rayOrigin = eyeEnd.position;

			// Declare a raycast hit to store information about what our raycast has hit
			RaycastHit hit;

			// Set the start position for our visual effect for our laser to the position of eyeEnd
			//laserLine.SetPosition(X, eyeEnd.position);
			laserLine.SetPosition (0, eyeEnd.position);

			// Check if our raycast has hit anything
			//tango.transform.forward?
			if (Physics.Raycast (rayOrigin, transform.forward, out hit, weaponRange)){
				// Set the end position for our laser line 
				laserLine.SetPosition (1, hit.point);
				
				fpsHealth health = hit.collider.GetComponent<fpsHealth>();
				if (health != null){
					health.Damage (gunDamage);
				}
			}
			else{
				// If we did not hit anything, set the end of the line to a position directly in front of the camera at the distance of weaponRange
				laserLine.SetPosition (1, rayOrigin + (transform.forward * weaponRange));
			}
	}
}

