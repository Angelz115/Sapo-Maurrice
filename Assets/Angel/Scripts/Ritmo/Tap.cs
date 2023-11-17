using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour
{
    [SerializeField] KeyCode tecla;
    [SerializeField] int id;

    public int SacarId() 
    {
        return id; 
    }
    public KeyCode SacarTecla() 
    {
        return tecla;
    }
}
