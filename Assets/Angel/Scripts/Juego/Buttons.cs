using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject Opciones;
    public GameObject UI;
    #region MENU
    public void ActivarOppciones() 
    {
        Opciones.SetActive(true);
        UI.SetActive(false);
    }
    public void ApagarOpciones() 
    {
        Opciones.SetActive(false);
        UI.SetActive(true);
    }
    #endregion

    
}
