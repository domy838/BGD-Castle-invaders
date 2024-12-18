using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowmanBehaviour : MonoBehaviour
{
    private GameController skripta;
    public AudioClip destructionSFX;
    public AudioSource shootingSFX;

    public float minTime;
    public float maxTime;
    public float nextFire;

    public GameObject arrow;

    void Start()
    {
        // Need to know which script to use
        skripta = GameObject.Find("GameController").GetComponent<GameController>();
        nextFire = Time.time + Random.Range(0, 5);
    }

    // Unity calls this function if the Collider on the game object has "Is Trigger" checked.
	// Then it doesn't physically react to hits but still detects them
    private void OnTriggerEnter2D(Collider2D collision)
    {
		// Check the other colliding object's tag to know if it's
		// indeed a player projectile
        if (collision.tag == "Laser")
        {
            // Destroy the alien game object
            Destroy(gameObject);
			
            // Destroy the projectile game object
            Destroy(collision.gameObject);
			
			// Play an audio clip in the scene and not attached to the alien
			// so the sound keeps playing even after it's destroyed
            AudioSource.PlayClipAtPoint(destructionSFX, transform.position);
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

    void FixedUpdate()
    {
        if(Time.time >= nextFire)
        {   
            Instantiate(arrow, transform.position, Quaternion.identity);
            shootingSFX.Play();
            nextFire = nextFire + Random.Range(minTime, maxTime);
        }
        
    }
}
