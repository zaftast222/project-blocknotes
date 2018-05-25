using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eStateType
{
    Unknown = 0,
    AppStart = 10,
    AssetLoad = 20,
    Entrance = 30,
    Lobby = 40,
    Room = 50,
    Game_1 = 100,
    Game_2 = 101,
    //....etc
}

public class BaseState
{
    public eStateType StateType
    {
        get
        {
            return m_Type;
        }
    }

    protected eStateType m_Type = eStateType.Unknown;
}