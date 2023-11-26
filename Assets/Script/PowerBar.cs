using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    public float maxPower = 10f;
    public float powerIncreaseRate = 2f;

    public GameObject powerGauge; 
    public Image actualPowerImage; 

    private float currentPower = 0f;
    private bool isChargingPower = false;

    private void Update()
    {
        if (isChargingPower)
        {
            float powerInput = Mathf.PingPong(Time.time * powerIncreaseRate, 1f);
            currentPower = powerInput * maxPower;

            float fillAmount = currentPower / maxPower;
            actualPowerImage.fillAmount = fillAmount;
        }

        if (Input.GetKeyUp(KeyCode.Space) && isChargingPower)
        {
            isChargingPower = false;
        }
    }

    public float StopChargingPower()
    {
        isChargingPower = false;
        return currentPower;
    }

    public void StartChargingPower()
    {
        isChargingPower = true;
        currentPower = 0f;
    }

    public void ActivatePowerGauge()
    {
        
        powerGauge.SetActive(true);
    }

    public void DeactivatePowerGauge()
    {
        
        powerGauge.SetActive(false);
    }
}
