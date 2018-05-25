using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameObject : MonoBehaviour
{
    public GameObject GameObject { get { return m_GameObject; } }
    public Animator Animator { get { return m_Animator; } }
    public CharacterObject CharacterData {  get { return null; } }

    GameObject m_GameObject = null;
    Animator m_Animator = null;
    CharacterObject m_CharacterData = null;
}
