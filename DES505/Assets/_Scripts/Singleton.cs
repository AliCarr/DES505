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

            string systemName = typeof(Type).ToString();
            var instances = FindObjectsOfType<Type>();
            int count = instances.Length;
            GameObject selectedInstance;

            if (count > 0)
            {
                if (count == 1)
                {
                    selectedInstance = instances[0].gameObject;
                }

                Debug.LogWarning("There should never be more than one {nameof(Singleton)} of type {typeof(T)} in the scene, but {count} were found. The first instance found will be used, and all others will be destroyed.");
                    
                for (var i = 1; i < instances.Length; i++)
                        Destroy(instances[i]);

                selectedInstance = instances[0].gameObject;
            }
            else
                try // instantiate from prefab
                {
                    selectedInstance = (GameObject)
                        Instantiate(Resources.Load(systemName, typeof(GameObject)));
                }
                catch (Exception e) // send error and create blank new
                {
                    Debug.LogError("could not instantiate prefab[ "
                        + systemName + " ]" + e.Message + "\n" + e.StackTrace);

                    selectedInstance = new GameObject(systemName);
                    selectedInstance.AddComponent<Type>();
                }


            return _instance = selectedInstance.GetComponent<Type>();
        }
    }

    private void Awake()
    {
        if (_persistent) DontDestroyOnLoad(gameObject);
    }
}

