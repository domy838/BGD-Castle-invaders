using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float destroyDelay = 5f;
    private float direction;

    // Start is called before the first frame update
    void Start()
    {
		// Another form of the Destroy function, which allows us to destroy an object
		// after a delay in seconds. We set the delay with a variable "destroyAfter"
        Destroy(gameObject, destroyDelay);
        // Did we or the enemy shoot?
        if(transform.position.y > -4)
        {
            // If enemy shoots, the arrow goes in opposite direction and rotated
            direction = -1f;
            Vector3 toRotate = new Vector3(0, 0, 180);
            transform.Rotate(toRotate);
            gameObject.tag = "EnemyArrow";
        }
        else
        {
            // If we shoot, the arrow goes in the intendet directionS
            direction = 1f;
            gameObject.tag = "Laser";
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the game object along the Y-axis (X is 0f), and we make the Y value into 
        // a variable so we can change the direction (up or down) and make the script reusable
        // in different situations. (can do the same for X and then it'll move in any direction you want)
        Vector3 translationVector = new Vector3(0f, direction) * moveSpeed * Time.deltaTime;
        transform.Translate(translationVector);
    }
}
