using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Environment : MonoBehaviour {
	public float fullHealth;
	public float currentHealth;
	public bool damaged;
	public Slider healthSlider;                                 // Reference to the UI's health bar.

	// Use this for initialization
	void Start () {
		currentHealth = fullHealth;
		damaged = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void TakeDamage (float amount)
	{
		// Set the damaged flag so the screen will flash.
		damaged = true;

		// Reduce the current health by the damage amount.
		currentHealth -= amount;

		// Set the health bar's value to the current health.
		healthSlider.value = currentHealth;
		Debug.Log ("Taking damage");

		// If the player has lost all it's health and the death flag hasn't been set yet...
		if(currentHealth <= 0)
		{
			// ... it should die.
			//Death ();
		}
	}

	public void end(){
		Destroy (gameObject);
	}
}
