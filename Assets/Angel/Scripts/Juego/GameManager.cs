using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public enum Actividad {estudiar, socializar, dormir, relajarse, salir}
public enum Horario {ma�ana,dia, tarde, noche}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] GameObject player;
    [SerializeField] PlayerStats stats;
    [Space]

    [Header("Manejo Orario")]
    [SerializeField] Horario horarioActual;
    [SerializeField] int dias;
    [SerializeField] int horarioInt;
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
    [Space]

    [Header("Dormir")]
    [SerializeField] GameObject Fade;
    [SerializeField] float entretiempo;
    private void Awake()
    {
        
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
        horarioActual = Horario.ma�ana;
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
        SceneManager.LoadScene(3);
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
        //player.GetComponent<PlayerStats>().bajarEstres(1);
        Fade.GetComponent<Animator>().SetTrigger("Start");
        cajaTexto.SetActive(false);
        si_no.SetActive(false);
        Invoke("TerminarDormir", entretiempo);
        //Instantiate(reloj, transform.position, Quaternion.identity);
    }
    public void TerminarDormir() 
    {
        Fade.GetComponent<Animator>().SetTrigger("End");
        TerminarActividad();
    }

    #endregion

    #region TOMAR ESTADISTICAS
    public int SacarEstres() 
    {
        int estres = stats.valorEstres();
        return estres;
    }
    public int sacarSociabilidad() 
    {
        int sociabilidad = stats.valorScoiabilidad();
        return sociabilidad;
    }

    public int sacarCansancio() 
    {
        int cansancio = stats.valorCansancio();
        return cansancio;
    }
    public int sacarConocimiento() 
    {
        int conocimiento = stats.valorConocimiento();
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
    
    public void TerminarActividad()
    {
        Invoke("reanudarMovimiento", 1);
        switch (horarioActual)
        {
            case Horario.ma�ana:
                horarioActual = Horario.dia;
                horarioInt = 0;
                break;
            case Horario.dia:
                horarioActual = Horario.tarde;
                horarioInt = 1;
                break;
            case Horario.tarde:
                horarioActual = Horario.noche;
                horarioInt = 2;
                break;
            case Horario.noche:
                horarioActual = Horario.ma�ana;
                horarioInt = 3;
                dias++;
                player.GetComponent<PlayerStats>().subirEstres(1);
                break;
            
        }
    }
    #region PLAYER PREFS
    public void asignarHorario() 
    {
        dias = PlayerPrefs.GetInt("DiasPrefs");
        horarioInt = PlayerPrefs.GetInt("HorarioPref");
        switch (horarioInt)
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
                horarioActual = Horario.ma�ana;
                break;
        }
    }
    public void asignarPrefs() 
    {

        PlayerPrefs.SetInt("EstresPref",stats.valorEstres());
        PlayerPrefs.SetInt("SociabilidadPref", stats.valorScoiabilidad());
        PlayerPrefs.SetInt("CansancioPref", stats.valorCansancio());
        PlayerPrefs.SetInt("ConocimientoPref", stats.valorConocimiento());
        PlayerPrefs.SetInt("DiasPrefs",dias);
        PlayerPrefs.SetInt("HorarioPref",horarioInt);
        
    }
    #endregion

    public void setVars(GameObject CT, GameObject CE, GameObject CS, GameObject SD, GameObject CD,  GameObject CR, GameObject Fa) 
    {

        player = GameObject.FindWithTag("Player");
        stats = player.GetComponent<PlayerStats>();
        cajaTexto = CT;
        cajaEstudio = CE;
        cajaSocializar = CS;
        cajaDormir = CD;
        cajaRelajo = CR;
        cajaSalir = CR;
        Fade = Fa;
        

    }
}

