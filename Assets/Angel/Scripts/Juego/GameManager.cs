using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum Actividad {estudiar, socializar, dormir, relajarse, salir}
public enum Tiempo {ma�ana, tarde, noche}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject player;
    
    public GameObject cajaTexto;
    public GameObject cajaEstudio;
    public GameObject cajaSocializar;
    public GameObject cajaDormir;
    public GameObject cajaRelajo;
    public GameObject cajaSalir;
    public GameObject si_no;
    public TextMesh tryM;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    public void PreguntarSi(string text, Actividad actividad) 
    {
        cajaTexto.SetActive(true);
        cajaTexto.GetComponentInChildren<TextMeshProUGUI>().text = text;
        player.GetComponent<PlayerMov>().Parar();
        player.GetComponent<PlayerMov>().enabled = false;

        switch (actividad)
        {
            case Actividad.estudiar:
                //cajaEstudio.SetActive(true);
                si_no = cajaEstudio;
                break;
            case Actividad.socializar:
                //cajaSocializar.SetActive(true);
                si_no = cajaSocializar;
                break;
            case Actividad.dormir:
                //cajaDormir.SetActive(true);
                si_no = cajaDormir;
                break;
            case Actividad.relajarse:
                //cajaRelajo.SetActive(true);
                si_no = cajaRelajo;
                break;
            case Actividad.salir:
                //cajaSalir.SetActive(true);
                si_no = cajaSalir;
                break;
            
        }
        
        si_no.SetActive(true);
    }
    

    public void reanudarMovimiento()
    {
        cajaTexto.SetActive(false);
        si_no.SetActive(false);
        
        player.GetComponent<PlayerMov>().enabled = true;
    }
    #region ESTUDIAR
    public void EmperzarEstudio() 
    {
        Debug.Log("Comenzar a estudiar");
        //prepar el minijuego
        Invoke("prenderUIEstudio", 1.35f);
        player.GetComponent<PlayerStats>().animator.SetBool("Estudiando", true);
        cajaTexto.SetActive(false);
    }
    public void TerminarEstudio() 
    {
        
        GameObject ui = GameObject.FindGameObjectWithTag("Ritmo");
        ui.GetComponent<Prender>().ApagarUI();
        player.GetComponent<PlayerStats>().animator.SetBool("Estudiando", false);
        Invoke("reanudarMovimiento", 1);

        
    }
    private void prenderUIEstudio() 
    {
        GameObject ui = GameObject.FindGameObjectWithTag("Ritmo");
        ui.GetComponent<Prender>().ActivarUI();
    } 
    #endregion

    #region SOCIALIZAR
    public void EmpezrSocializar() 
    {
        Debug.Log("Comenzo a socializar");
    }

    public void TerminarSocializar() 
    {
        Debug.Log("Comenzo a socializar");
    }

    #endregion

    #region Relajarse
    public void EmpezarRelajarse() 
    {
        Debug.Log("Comenzo a relajarse");
    }
    public void TerminarRelajarse() 
    {
        Debug.Log("termino de relajarse");
    }

    #endregion

    #region DORMIR
    public void EmpezarDormir() 
    {
        Debug.Log("Comenzo a dormir");
    }
    public void TerminarDormir() 
    {
        Debug.Log("termino de dormir");
    }

    #endregion

    #region TOMAR_ESTADISTICAS
    public int SacarEstres() 
    {
        int estres = player.GetComponent<PlayerStats>().valorEstres();
        return estres;
    }
    public int sacarSociabilidad() 
    {
        int sociabilidad = player.GetComponent<PlayerStats>().valorScoiabilidad();
        return sociabilidad;
    }

    public int sacarCansancio() 
    {
        int cansancio = player.GetComponent<PlayerStats>().valorCansancio();
        return cansancio;
    }
    public int sacarConocimiento() 
    {
        int conocimiento = player.GetComponent<PlayerStats>().valorConocimiento();
        return conocimiento;
    }
    #endregion

    
    public void EmpezarActividad(Actividad quehacer)
    {
        switch (quehacer)
        {
            case Actividad.estudiar:
                EmperzarEstudio();
                break;
            case Actividad.socializar:
                EmpezrSocializar();
                break;
            case Actividad.dormir:
                EmpezarDormir();
                break;
            case Actividad.relajarse:
                EmpezarRelajarse();
                break;
        }
    }
    
    public void TerminarActividad(Actividad quehacer)
    {
        switch (quehacer)
        {
            case Actividad.estudiar:
                TerminarEstudio();
                break;
            case Actividad.socializar:
                TerminarSocializar();
                break;
            case Actividad.dormir:
                TerminarDormir();
                break;
            case Actividad.relajarse:
                TerminarRelajarse();
                break;

        }
    }
    
}

