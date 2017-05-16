using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class fpsHealth : MonoBehaviour {

	//The box's current health point total
	public int currentHealth = 3;

	public void Damage(int damageAmount)
	{
		//subtract damage amount when Damage function is called
		currentHealth -= damageAmount;

		//Check if health has fallen below zero
		if (currentHealth == 0) 
		{
			Debug.Log ("you died");
			//if health has fallen below zero, deactivate it 
			//gameObject.SetActive (false);
			//have a screen that says youre dead
			//ends game and restarts
			SceneManager.LoadScene ("deathScene");
		}
	}
}
