using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureScript : MonoBehaviour
{
    public float startingTemperature = 35f; // The temperature that is when the game begins
    public Text temperatureText;            // The text indicating the temperature
    public Image currentTemperatureBar;           // The image component of the temperature bar
    public Sprite[] temperatureLevels;
    public PlayScript playScript;

    private float currentTemperature;       // How much temperature is currently there
    private bool isGameOver;                // Is the game over or not

    // Start is called before the first frame update
    void Start()
    {
        // When the game starts, reset the Starting temperature & whether the Game is over or not
        currentTemperature = startingTemperature;
        temperatureText.text = currentTemperature.ToString();
        isGameOver = false;

        // Update the Temperature UI in starting
        SetTemperatureUI();
    }

    public void IncreaseTemperature(float amount)
    {
        // Increase the current temperature by the amount
        currentTemperature += amount;

        // Update the Text
        temperatureText.text = currentTemperature.ToString();

        // Change the UI elements appropriately
        SetTemperatureUI();

        // if current temperature is at or above 60 and if it has not been registered, call OnGameOver
        if(currentTemperature >= 60f && !isGameOver)
        {
            OnGameOver();
        }
    }

    public void DecreaseTemperature(float amount)
    {
        // Reduce the current temperature by the amount
        currentTemperature -= amount;

        // Update the Text
        temperatureText.text = currentTemperature.ToString();

        // Change the UI elements appropriately
        SetTemperatureUI();
    }

    private void SetTemperatureUI()
    {
        // Set the Image fill appropriately
        int index = (int)currentTemperature % 35;
        index /= 5;
        if(currentTemperature < 35f)
        {
            index = 0;
        }
        currentTemperatureBar.sprite = temperatureLevels[index];
    }

    private void OnGameOver()
    {
        // Set the flag so that this function is only called once.
        isGameOver = true;
        playScript.Pause();
        playScript.pauseMenu.transform.GetChild(0).gameObject.SetActive(false);
    }

    
}
