using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private GameController skripta;

    void Start()
    {
        // Need to know which script to use
        skripta = GameObject.Find("GameController").GetComponent<GameController>();
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
}
