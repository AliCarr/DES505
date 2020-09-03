using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureScript : MonoBehaviour
{
    //[SerializeField] private float startingTemperature = 35f;
    [SerializeField] private Text temperatureText = null;
    [SerializeField] private Image currentTemperatureBar = null;
    [SerializeField] private Sprite[] temperatureLevels = null;

    private float currentTemperature = 35f;       
    private bool isGameOver;                

    // Start is called before the first frame update

    //currentTemperature = startingTemperature;
    //temperatureText.text = currentTemperature.ToString();
    //isGameOver = false;

    //SetTemperatureUI();

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

    private void OnGameOver()
    {
        isGameOver = true;
        UIManager.Instance.Pause();
        //playScript.Pause();
        //playScript.pauseMenu.transform.GetChild(0).gameObject.SetActive(false);
    }

    
}
