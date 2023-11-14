using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prender : MonoBehaviour
{
    [SerializeField] GameObject UI;

    public void ActivarUI() 
    {
        UI.SetActive(true);
        
    }
    public void ApagarUI() 
    {
        UI.SetActive(false);
        
    }
}
