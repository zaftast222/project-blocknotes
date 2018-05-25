using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : BaseManager<StateManager>
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        
    }
}