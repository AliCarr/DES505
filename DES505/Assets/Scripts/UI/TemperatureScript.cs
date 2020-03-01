using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureScript : MonoBehaviour
{
    public float startingTemperature = 35f; // The temperature that is when the game begins
    public Text temperatureText;            // The text indicating the temperature
    public Image temperatureFill;           // The image component of the temperature bar
    public Color MaxTemperatureColor = Color.red;       // The color the temperature bar will be when on maximum temperature.
    public Color MinTemperatureColor = Color.grey;         // The color the temperature bar will be when on minimum temperature.

    private float currentTemperature;       // How much temperature is currently
    private bool IsGameOver;                // Is the game over or not

    // Start is called before the first frame update
    void Start()
    {
        // When the game starts, reset the Starting temperature & whether the Game is over or not
        currentTemperature = startingTemperature;
        temperatureText.text = "" + currentTemperature;
        IsGameOver = false;

        // Update the Temperature UI in starting
        SetTemperatureUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseTemperature(float amount)
    {
        // Increase the current temperature by the amount
        currentTemperature += amount;

        // Update the Text
        temperatureText.text = "" + currentTemperature;

        // Change the UI elements appropriately
        SetTemperatureUI();

        // if current temperature is at or above 60 and if it has not been registered, call OnGameOver
        if(currentTemperature >= 60f && !IsGameOver)
        {
            OnGameOver();
        }
    }

    public void DecreaseTemperature(float amount)
    {
        // Reduce the current temperature by the amount
        currentTemperature -= amount;

        // Update the Text
        temperatureText.text = "" + currentTemperature;

        // Change the UI elements appropriately
        SetTemperatureUI();
    }

    private void SetTemperatureUI()
    {
        // Set the Image fill appropriately

        // Interpolate the color of the bar between the choosen colours based on the current percentage of the starting temperature.
        temperatureFill.color = Color.Lerp(MinTemperatureColor, MaxTemperatureColor, currentTemperature / startingTemperature);
    }

    private void OnGameOver()
    {
        // Set the flag so that this function is only called once.
        IsGameOver = true;
    }
}
