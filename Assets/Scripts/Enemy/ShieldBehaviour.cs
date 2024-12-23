using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBehaviour : MonoBehaviour
{
    private GameController skripta;

    public AudioSource firstHitSFX;

    public int enemyLives = 2;

    public SpriteRenderer shieldKnight;
    public Sprite newSprite;

    void Start()
    {
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
            // Destroy the projectile game object
            Destroy(collision.gameObject);

            enemyLives -= 1;
            
            if(enemyLives == 0)
            {
                // Destroy the alien game object after the sound of death has played
                Destroy(gameObject);
                skripta.EnemyDestroyed();
            }
            else
            {
                // Play sound when hit
                firstHitSFX.Play();
                // Change sprite image
                shieldKnight.sprite = newSprite;
            }
           
        }
        // If they come to the castle, you loose
        else if (collision.tag == "End")
        {
            skripta.GameOver();
        }
    }
}
