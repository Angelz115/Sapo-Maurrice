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
    #region RESPUESTA
    public void No() 
    {
        GameManager.Instance.reanudarMovimiento();
    }
    public void SiEstudio() 
    {
        GameManager.Instance.EmperzarEstudio();
    }
    public void SiSocializar() 
    {
        GameManager.Instance.EmpezrSocializar();
    }
    public void SiDormir() 
    {
        GameManager.Instance.EmpezarDormir();
    }
    public void SiRelajarse() 
    {
        GameManager.Instance.EmpezarRelajarse();
    }
    public void SiSalir() 
    { 
        
    }
    #endregion
}
