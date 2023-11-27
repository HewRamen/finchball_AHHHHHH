using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscMovement : MonoBehaviour
{


    public float movementSpeed = 5f;
    public float movementRange = 2f;
    public ArrowRotation arrowRotation;
    public PowerBar powerBar;
    public Transform ArrowSpawnPoint;
    

    private float initialX;
    public bool isMoving = true;
    private bool spaceBarPressed = false;
    private bool arrowConfirmed = false;
    private bool powerConfirmed = false;
    private bool canControl = true;

    private void Start()
    {
        initialX = transform.position.x;
        powerBar.DeactivatePowerGauge();
    }

    private void Update()
    {
        Debug.Log("isMoving: " + isMoving);
        Debug.Log("arrowConfirmed: " + arrowConfirmed);
        Debug.Log("powerConfirmed: " + powerConfirmed);

        if (isMoving && canControl)
        {
            HandleMovementInput();
        }
        else
        {
            Debug.Log("Handling Launch Input");
            HandleLaunchInput();
        }
    }

    private void HandleMovementInput()
    {
        if (!arrowConfirmed)
        {
            Debug.Log("Handling Movement Input");
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector3 newPosition = transform.position + Vector3.right * horizontalInput * movementSpeed * Time.deltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, initialX - movementRange, initialX + movementRange);
            transform.position = newPosition;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                spaceBarPressed = true;
            }

            if (spaceBarPressed && Input.GetKeyUp(KeyCode.Space))
            {
                arrowRotation.StartSwing();
                spaceBarPressed = false;
                arrowConfirmed = true;
            }
        }
        else if (arrowConfirmed && !powerConfirmed && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Switching to launch mode");
            powerBar.ActivatePowerGauge();
            powerBar.StartChargingPower();
            powerConfirmed = true;
            canControl = false; 
        }
    }

    private void HandleLaunchInput()
    {
        Debug.Log("Handling Launch Input");

        if (powerConfirmed && Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Power Confirmed. Launching the disc!");
            arrowRotation.StopSwing();
            float power = powerBar.StopChargingPower();
            Debug.Log("Power confirmed: " + power);
            Launch(power);
            isMoving = false;

        }
    }


    public void ResetDisc()
    {
        arrowConfirmed = false;
        powerConfirmed = false;
        canControl = true;
        isMoving = true;
    }


    private void Launch(float power)
    {
        Debug.Log("Launching the disc with power: " + power);

        Vector3 launchDirection = arrowRotation.transform.forward;
        Debug.Log("Launch Direction: " + launchDirection);

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(launchDirection * power, ForceMode.Impulse);

        arrowRotation.gameObject.SetActive(false);
        isMoving = true;
        arrowConfirmed = false;
        powerConfirmed = false;
        powerBar.DeactivatePowerGauge();
    }
}