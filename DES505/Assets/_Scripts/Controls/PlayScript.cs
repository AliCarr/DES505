using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayScript : MonoBehaviour
{ 
    void Awake()
    {
        bool initTheGame = GameManager.Instance.isInit;
    }

}
