using UnityEngine;
using System;

public abstract class Singleton<Type>  : MonoBehaviour where Type : MonoBehaviour
{
    private static Type _instance;

    private bool _persistent = true;

  
    public static Type Instance
    {
        get
        {
                if (_instance != null)    return _instance;
                var instances = FindObjectsOfType<Type>();
                string systemName = typeof(Type).ToString();
                var count = instances.Length;
                if (count > 0)
                {
                    if (count == 1)
                        return _instance = instances[0];

                    Debug.LogWarning("There should never be more than one {nameof(Singleton)} of type {typeof(T)} in the scene, but {count} were found. The first instance found will be used, and all others will be destroyed.");
                    
                    for (var i = 1; i < instances.Length; i++)
                            Destroy(instances[i]);

                    return _instance = instances[0];
                }
         

                return _instance = new GameObject(systemName).AddComponent<Type>();
        }
    }

    private void Awake()
    {
        if (_persistent) DontDestroyOnLoad(gameObject);
    }
}

