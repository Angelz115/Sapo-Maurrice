using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public enum Actividad {estudiar, socializar, dormir, relajarse, salir}
public enum Horario {mañana,dia, tarde, noche}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject player;
    [Space]

    [Header("Manejo Orario")]
    [SerializeField] Horario horarioActual;
    [SerializeField] int dias;
    [Space]

    [Header("Cajas de texto")]
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
        asignarHorario();
    }
    public void gameOver() 
    {
        Debug.Log("Perdiste");
    }
    public void perderDia() 
    {
        SceneManager.LoadScene(1);
        horarioActual = Horario.mañana;
        dias++;
    }
    public void PreguntarSi(string text, Actividad actividad) 
    {
        cajaTexto.SetActive(true);
        cajaTexto.GetComponentInChildren<TextMeshProUGUI>().text = text;
        player.GetComponent<PlayerMov>().Parar();
        player.GetComponent<PlayerMov>().enabled = false;
        player.GetComponent<PlayerInput>().enabled = false;

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
        player.GetComponent<PlayerInput>().enabled = true;
    }
    #region ESTUDIAR
    public void EmperzarEstudio() 
    {
        
        Invoke("prenderUIEstudio", 2);
        player.GetComponent<PlayerMov>().anim.SetBool("Estudiando", true);
        cajaTexto.SetActive(false);
        si_no.SetActive(false);
    }
    public void TerminarEstudio() 
    {
        
        GameObject ui = GameObject.FindGameObjectWithTag("Ritmo");
        ui.GetComponent<Prender>().ApagarUI();
        player.GetComponent<PlayerMov>().anim.SetBool("Estudiando", false);
        Invoke("reanudarMovimiento", 1);
        player.GetComponent<PlayerStats>().subirConocimiento(1);

        if (horarioActual == Horario.noche)
        {
            player.GetComponent<PlayerStats>().subirEstres(2);
            player.GetComponent<PlayerStats>().subirCansancio(2);
        }
        else
        {
            player.GetComponent<PlayerStats>().subirEstres(1);
            player.GetComponent<PlayerStats>().subirCansancio(1);
        }
        TerminarActividad();

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
        player.GetComponent<PlayerStats>().bajarCansancio(1);
        player.GetComponent<PlayerStats>().bajarEstres(1);
    }

    #endregion

    #region DORMIR
    public void EmpezarDormir() 
    {
        Debug.Log("Comenzo a dormir");
        player.GetComponent<PlayerStats>().bajarCansancio(2);

    }
    public void TerminarDormir() 
    {
        Debug.Log("termino de dormir");
        TerminarActividad();
        player.GetComponent<PlayerStats>().bajarCansancio(3);
        player.GetComponent<PlayerStats>().bajarEstres(2);
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

    private void asignarHorario() 
    {
        dias = PlayerPrefs.GetInt("DiasPrefs");
        int horarioActualI = PlayerPrefs.GetInt("HorarioPref");
        switch (horarioActualI)
        {
            case 3:
                horarioActual = Horario.noche;
                break;
            case 2:
                horarioActual = Horario.tarde;
                break;
            case 1:
                horarioActual = Horario.dia;
                break;
            case 0:
                horarioActual = Horario.mañana;
                break;
        }
    }
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
    
    public void TerminarActividad()
    {
        switch (horarioActual)
        {
            case Horario.mañana:
                horarioActual = Horario.dia;
                break;
            case Horario.dia:
                horarioActual = Horario.tarde;
                break;
            case Horario.tarde:
                horarioActual = Horario.noche;
                break;
            case Horario.noche:
                horarioActual = Horario.mañana;
                dias++;
                player.GetComponent<PlayerStats>().subirEstres(1);
                break;
            
        }
    }
    
}

