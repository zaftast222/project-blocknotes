using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager <T> : MonoBehaviour
{
    public static T Instance
    {
        get
        {
            return m_Instance;
        }
    }
    
    protected static T m_Instance;

    private void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = gameObject.GetComponent<T>();
            //DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
}