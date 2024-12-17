using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float minPosX;
    public float maxPosX;

    public float moveDistance = 1f;
    public float moveForward = -1f;

    bool isMovingRight = true;


    public float timeStep = 1f;
    public float countdown;
	
	// I added a switch to try both methods
	public bool isUsingCountdown = true;

    // Use this for initialization
    void Start()
    {
		if (isUsingCountdown)
		{
			countdown = timeStep;
		}
		else
		{	
			// Invoke repeating will be called once after timeStep (2nd parameter) amount,
			// and then repeatedly every timeStep (3rd parameter) amount
			//InvokeRepeating("Move", timeStep, timeStep);
			InvokeRepeating("Move", timeStep, timeStep);
		}
    }

    // Update is called once per frame
    void Update()
    {
		if (isUsingCountdown)
		{
			countdown -= Time.deltaTime;

			if (countdown <= 0)
			{
				Move();
				countdown = timeStep;
			}
		}
    }

    void Move()
    {
        if (isMovingRight)
        {
            // Moving right
            Vector3 currentPos = transform.position;
            Vector3 newPos = currentPos + new Vector3(moveDistance, 0f);
            

            // If aliens group would reache the right-most edge, flip their direction and only move forward
            if (newPos.x >= maxPosX)
            {
                isMovingRight = false;
                MoveStepForward();
            }
            // Else move to the right
            else
            {
                transform.position = newPos;
            }
            
        }
        else
        {
            // Moving left
            Vector3 currentPos = transform.position;
            Vector3 newPos = currentPos - new Vector3(moveDistance, 0f);
            

            // If aliens group would reach the left-most edge, flip their direction and only move forward
            if (newPos.x <= minPosX)
            {
                isMovingRight = true;
                MoveStepForward();
            }
            // Else move to the left
            else
            {
                transform.position = newPos;
            }
        }
    }

    void MoveStepForward()
    {
        Vector3 currentY = transform.position;
        Vector3 newY = currentY + new Vector3(0f, moveForward);
        transform.position = newY;
    }
}