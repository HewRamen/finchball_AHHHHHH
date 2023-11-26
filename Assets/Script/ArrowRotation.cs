using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public float swingDuration = 2f;
    private bool isSwinging = false;
    private float swingTimer = 0f;

    private void Update()
    {
        if (isSwinging)
        {
            swingTimer += Time.deltaTime;
            float t = Mathf.PingPong(swingTimer / swingDuration, 1f);
            float angle = Mathf.Lerp(-85f, 85f, t);

            Quaternion newRotation = Quaternion.Euler(Vector3.up * angle);
            transform.rotation = newRotation;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                isSwinging = false;
            }
        }
    }

    public void StartSwing()
    {
        isSwinging = true;
        transform.position = FindObjectOfType<DiscMovement>().ArrowSpawnPoint.position;
        gameObject.SetActive(true);
    }

    public void StopSwing()
    {
        isSwinging = false;
    }
}
