using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TemperatureScript 
{
    [SerializeField] private Text temperatureText = null;
    [SerializeField] private Image currentTemperatureBar = null;
    [SerializeField] private Sprite[] temperatureLevels = null;

    private float currentTemperature = 35f;       
    private bool isGameOver;                

    public void ResetTemperature()
    {
        currentTemperature = 35f;
        temperatureText.text = currentTemperature.ToString();
        SetTemperatureUI();
        isGameOver = false;
    }

    public void IncreaseTemperature(float amount)
    {
        currentTemperature += amount;
        temperatureText.text = currentTemperature.ToString();
        SetTemperatureUI();

        if(currentTemperature >= 60f && !isGameOver)
        {
            OnGameOver();
        }
    }

    public void DecreaseTemperature(float amount)
    {
        currentTemperature -= amount;
        temperatureText.text = currentTemperature.ToString();
        SetTemperatureUI();
    }

    private void SetTemperatureUI()
    {
        int index = (int)currentTemperature % 35;
        index /= 5;
        if(currentTemperature < 35f)
        {
            index = 0;
        }
        currentTemperatureBar.sprite = temperatureLevels[index];
    }


    public bool GetGameOver() { return isGameOver; }

    private void OnGameOver()
    {
        isGameOver = true;

    }

    
}
