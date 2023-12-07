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
    [SerializeField] GameObject player;
    [SerializeField] PlayerStats stats;
    [Space]

    [Header("Manejo Orario")]
    [SerializeField] Horario horarioActual;
    public int dias { get; private set; }
    [SerializeField] int horarioInt;
    [SerializeField] GameObject mensaje;
    [Space]

    [Header("Cajas de texto")]
    public GameObject cajaTexto;
    public GameObject cajaEstudio;
    public GameObject cajaSocializar;
    public GameObject cajaDormir;
    public GameObject cajaRelajo;
    public GameObject cajaSalir;
    public GameObject si_no;
    public TextMesh advertencia;
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
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("DiasPref", 0);
        PlayerPrefs.SetInt("HorarioIntPref", 0);
        stats.resetPrefs();
    }

    public Horario sacarHorario() 
    {
        return horarioActual;
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
        Debug.Log("socializando");

    }
    public void moverAParque() 
    {
        SceneManager.LoadScene(3);
        PlayerPrefs.SetInt("SocializandoPref", 1);
    }
    public void TerminarSocializar() 
    {
        Debug.Log("termino de socializar");
        PlayerPrefs.SetInt("SocializandoPref",0);
        TerminarActividad();
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

    public void quedateEnCasa() 
    {
        cajaTexto.GetComponentInChildren<TextMeshProUGUI>().text = "quedate en la casa";
        Invoke("apagarCaja", 4);
        Invoke("reanudarMovimiento", 1);
        si_no.SetActive(false);  
    }
    private void apagarCaja()
    {
        cajaTexto.SetActive(false);
    }
    public void TerminarActividad()
    {
        Invoke("reanudarMovimiento", 1);
        pasarTiempo();
    }
    public void pasarTiempo() 
    {
        mensaje.SetActive(false);
        switch (horarioActual)
        {
            case Horario.mañana:
                horarioActual = Horario.dia;
                horarioInt = 1;
                break;
            case Horario.dia:
                horarioActual = Horario.tarde;
                horarioInt = 2;
                break;
            case Horario.tarde:
                horarioActual = Horario.noche;
                horarioInt = 3;
                break;
            case Horario.noche:
                horarioActual = Horario.mañana;
                horarioInt = 0;
                cambioDia();
                diaFinal();
                break;

        }
        void cambioDia() 
        {
            dias++;
            player.GetComponent<PlayerStats>().subirEstres(1);
            Fade.GetComponent<Animator>().SetTrigger("Start");
            Fade.GetComponent<Animator>().SetTrigger("End");
            mensaje.SetActive(true);
               
        }
        void diaFinal() 
        {
            if (dias != 2)  //pa que sea el viernes tiene que ser 4
                return;
            Debug.Log("dia de la prueba");
            
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
                horarioActual = Horario.mañana;
                break;
        }
    }
    
    public void setPrefs()
    {
        PlayerPrefs.SetInt("DiasPref", dias);
        PlayerPrefs.SetInt("HorarioIntPref", horarioInt);
        stats.setStatsPrefs();

    }
    public void playerStat1()
    {
        stats.setearStats();
    }
    
    #endregion

    public void setVars(GameObject CT, GameObject CE, GameObject CS, GameObject SD, GameObject CD,  GameObject CR, GameObject Fa,GameObject Me) 
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
        mensaje = Me;
        dias = PlayerPrefs.GetInt("DiasPref");
        horarioInt = PlayerPrefs.GetInt("HorarioIntPref");

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
                horarioActual = Horario.mañana;
                break;
        }
    }

    
}

