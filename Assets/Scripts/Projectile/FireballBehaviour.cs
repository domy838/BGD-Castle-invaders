using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehaviour : MonoBehaviour
{
    public float moveSpeed = 3f;
    public AudioClip explosionSFX;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the game object along the Y-axis (X is 0f), and we make the Y value into 
        // a variable so we can change the direction (up or down) and make the script reusable
        // in different situations. (can do the same for X and then it'll move in any direction you want)
        Vector3 translationVector = new Vector3(0f, -1f) * moveSpeed * Time.deltaTime;
        transform.Translate(translationVector);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check the other colliding object's tag to know if it's the end
        if (collision.tag == "End")
        {
            print("I reached the end");
            // Make the explosion game object visible
            Instantiate(explosion, transform.position, Quaternion.identity);

            // Destroy the fireball game object
            Destroy(gameObject);
			
			// Play an audio clip in the scene and not attached to the fireball
			// so the sound keeps playing even after it's destroyed
            AudioSource.PlayClipAtPoint(explosionSFX, transform.position);
        }
    }
}
