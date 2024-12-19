using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{   
    public float destroyDelay = 2f;
    public int timesCollided = 0;
    private GameController skripta;
    public AudioSource explosionSFX;

    // Start is called before the first frame update
    void Start()
    {   
        explosionSFX.Play();
        skripta = GameObject.Find("GameController").GetComponent<GameController>();
        Destroy(gameObject, destroyDelay);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check the other colliding object's tag to know if it's the eplayer
        if (collision.tag == "Player" && timesCollided == 0)
        {   
            // If it is, player looses a life
            skripta.LooseLife();
            timesCollided += 1;
        }
    }
}
