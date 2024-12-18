using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Reference to the original prefab to instatiate
    public GameObject projectilePrefab;
    
	// Reference to the AudioSource component on the player
	public AudioSource sfxPlayer;

    private GameController skripta;

    // Start is called before the first frame update
    void Start()
    {
        skripta = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {   
        // If we pressed space and it's not game over yet
        if (Input.GetButtonDown("Jump") && !skripta.isGameOver)
        {
            Shoot();
        }
    }

    void Shoot()
    {	
		// We instantiate the prefab at the same position as the player,
        // since this script is on the player GameObject
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        sfxPlayer.Play();
    }
}
