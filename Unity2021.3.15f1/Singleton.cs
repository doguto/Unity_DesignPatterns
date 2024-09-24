using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(T)) as T;
                if (_instance == null)
                {
                    SetupInstance();
                }
            }
            return _instance;
        }
    }
    public virtual void Awake()
    {
        RemoveDuplicates();
    }

    private static void SetupInstance()
    {
        _instance = FindObjectOfType(typeof(T)) as T;

        if (_instance)
        {
            Destroy(_instance);
        }
    }

    public void RemoveDuplicates()
    {
        _instance = FindObjectOfType(typeof(T)) as T;

        if (_instance && _instance != gameObject.GetComponent<T>())
        {
            Destroy(_instance);
        }

        DontDestroyOnLoad(gameObject);
    }
}
