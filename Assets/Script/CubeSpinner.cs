using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CubeSpinner : MonoBehaviour
{
    [SerializeField]private float spinSpeed = 30f; 

    void Update()
    {
       
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
}
