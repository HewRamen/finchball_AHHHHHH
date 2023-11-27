using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCubeMovement : MonoBehaviour
{
    [SerializeField]private float moveSpeed = 5f;
    [SerializeField]private float leftRange = -5f;
    [SerializeField]private float rightRange = 5f; 

    void Update()
    {
       
        MoveCube();
    }

    void MoveCube()
    {
        
        float horizontalMovement = Mathf.Sin(Time.time) * moveSpeed;

      
        float newXPosition = Mathf.Clamp(transform.position.x + horizontalMovement * Time.deltaTime, leftRange, rightRange);

        
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
    }
}

