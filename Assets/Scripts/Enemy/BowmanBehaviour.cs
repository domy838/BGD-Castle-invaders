using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowmanBehaviour : MonoBehaviour
{
    private GameController skripta;
    public AudioSource shootingSFX;

    public float minTime;
    public float maxTime;
    public float nextFire;
    public float firstMinFire;
    public float firstMaxFire;

    public GameObject arrow;

    void Start()
    {
        // Need to know which script to use
        skripta = GameObject.Find("GameController").GetComponent<GameController>();
        nextFire = Time.time + Random.Range(firstMinFire, firstMaxFire);
    }

    // Unity calls this function if the Collider on the game object has "Is Trigger" checked.
	// Then it doesn't physically react to hits but still detects them
    private void OnTriggerEnter2D(Collider2D collision)
    {
		// Check the other colliding object's tag to know if it's
		// indeed a player projectile
        if (collision.tag == "Laser")
        {	
            // Destroy the alien game object after the sound of death has played
            Destroy(gameObject);

            // Destroy the projectile game object
            Destroy(collision.gameObject);
			
            // Call the function in GameController, that counts the number of enemies
            skripta.EnemyDestroyed();
        }
        // If they come to th ecastle, you loose
        else if (collision.tag == "End")
        {
            // Call function in GameController, that ends the game on a loss
            skripta.GameOver();
        }
    }

    void Update()
    {   
        // If its time for the next shot
        if(Time.time >= nextFire)
        {   
            // Shoot
            Instantiate(arrow, transform.position, Quaternion.identity);
            shootingSFX.Play();
            // New time for the next shot
            nextFire = nextFire + Random.Range(minTime, maxTime);
        }
        
    }
}
