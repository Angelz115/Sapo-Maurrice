using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject Opciones;
    public GameObject UI;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }
    #region MENU
    public void ActivarOppciones() 
    {
        audioManager.PlaySFX(audioManager.opcionSi);
        Opciones.SetActive(true);
        UI.SetActive(false);
    }
    public void ApagarOpciones() 
    {
        audioManager.PlaySFX(audioManager.opcionSi);
        Opciones.SetActive(false);
        UI.SetActive(true);
    }
    #endregion
    #region RESPUESTA
    public void No() 
    {
        audioManager.PlaySFX(audioManager.opcionNo);
        GameManager.Instance.reanudarMovimiento();
    }
    public void SiEstudio() 
    {
        audioManager.PlaySFX(audioManager.opcionSi);
        GameManager.Instance.EmperzarEstudio();
    }
    public void SiSocializar() 
    {
        audioManager.PlaySFX(audioManager.opcionSi);
        GameManager.Instance.EmpezrSocializar();
    }
    public void AParque() 
    {
        audioManager.PlaySFX(audioManager.opcionSi);
        GameManager.Instance.moverAParque();
    }
    public void SiDormir() 
    {
        audioManager.PlaySFX(audioManager.opcionSi);
        GameManager.Instance.EmpezarDormir();
    }
    public void SiRelajarse() 
    {
        audioManager.PlaySFX(audioManager.recueracion);
        GameManager.Instance.EmpezarRelajarse();
    }
    public void SiSalir() 
    {
        audioManager.PlaySFX(audioManager.opcionSi);
    }
    
    #endregion
}
