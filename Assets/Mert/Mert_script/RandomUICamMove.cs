using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RandomUICamMove : MonoBehaviour
{
    public float speed = 5f;
    public float boundarySize = 10f;

    private Vector3 moveDirection;

    void Start()
    {
        // Set initial movement direction (you can customize this)
        moveDirection = GetRandomDirection().normalized;
    }

    void Update()
    {
        MoveCameraRandomly();
    }
    void MoveCameraRandomly()
    {
        Vector3 newPosition = transform.position + moveDirection * speed * Time.deltaTime;

        // Check if the new position is within the boundary
        if (IsWithinBoundary(newPosition))
        {
            // Move the camera to the new position
            transform.position = newPosition;
        }
        else
        {
            // Change direction randomly when hitting the boundary
            moveDirection = GetRandomDirection().normalized;
        }
    }
        Vector3 GetRandomDirection()
        {
            // Generate a random direction vector
            return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
        }

        bool IsWithinBoundary(Vector3 position)
        {
            // Check if the position is within the specified boundary
            return Mathf.Abs(position.x) <= boundarySize && Mathf.Abs(position.y) <= boundarySize;
        }
    
}
