using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private GameController skripta;
    public AudioClip destructionSFX;

    void Start()
    {
        skripta = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Unity calls this function if the Collider on the game object has "Is Trigger" checked.
	// Then it doesn't physically react to hits but still detects them
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("I was triggered!");

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
            skripta.EnemyDestroyed();
        }
        // If they come to th ecastle, you loose
        else if (collision.tag == "End")
        {
            skripta.GameOver();
        }
    }
}
