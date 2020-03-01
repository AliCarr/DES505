using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    //public Building tree;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToLevel()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
