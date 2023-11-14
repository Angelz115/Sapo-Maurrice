using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Actividad {estudiar, socializar, dormir, relajarse}
public enum Tiempo {mañana, tarde, noche}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject player;
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

    #region ESTUDIAR
    public void EmperzarEstudio() 
    {
        Debug.Log("Comenzar a estudiar");
        //prepar el minijuego
        Invoke("prenderUIEstudio", 1);
        player.GetComponent<PlayerStats>().animator.SetBool("Estudiando", true);
        player.GetComponent<PlayerMov>().Parar();
        player.GetComponent<PlayerMov>().enabled = false;

    }
    public void TerminarEstudio() 
    {
        
        GameObject ui = GameObject.FindGameObjectWithTag("Ritmo");
        ui.GetComponent<Prender>().ApagarUI();
        player.GetComponent<PlayerStats>().animator.SetBool("Estudiando", false);
        Invoke("reanudarMovimiento", 1);

        
    }

    private void reanudarMovimiento()
    {
        player.GetComponent<PlayerMov>().enabled = true;
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

    /*
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
    */
}

