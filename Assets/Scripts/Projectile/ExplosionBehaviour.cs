using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{   
    public float destroyDelay = 2f;
    public int timesCollided = 0;
    private GameController skripta;

    // Start is called before the first frame update
    void Start()
    {   
        skripta = GameObject.Find("GameController").GetComponent<GameController>();
        Destroy(gameObject, destroyDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check the other colliding object's tag to know if it's the end
        if (collision.tag == "Player" && timesCollided == 0)
        {
            skripta.LooseLife();
            timesCollided += 1;
        }
    }
}
