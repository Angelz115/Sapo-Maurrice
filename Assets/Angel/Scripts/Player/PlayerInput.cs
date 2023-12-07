using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] bool puedePresionar;
    [SerializeField] GameObject pogger;
    [SerializeField] KeyCode accion;
    [SerializeField] string pregunta;
    [SerializeField] Actividad queHacer;

    public GameObject ui,textbox;
    public GameObject[] amigos;

    // Start is called before the first frame update
    void Start()
    {
        pogger.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (puedePresionar)
        {
            if (Input.GetKeyDown(accion))
            {
                GameManager.Instance.PreguntarSi(pregunta,queHacer);
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameManager.Instance.pasarTiempo();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            dejarConversa();
        }
        
    }
    public void conversar() 
    {
        ui.SetActive(true);
        textbox.SetActive(true);
        for (int i = 0; i < amigos.Length; i++)
        {
            amigos[i].SetActive(false);
        }
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<PlayerMov>().enabled = false;
    }
    private void dejarConversa() 
    {
        ui.SetActive(false);
        textbox.SetActive(false);
        for (int i = 0; i < amigos.Length; i++)
        {
            amigos[i].SetActive(true);
        }
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<PlayerMov>().enabled = true;
    }
    public void LLamarAccion(string texto, Actividad actividad) 
    {
        pogger.SetActive(true);
        puedePresionar = true;
        pregunta = texto;
        queHacer = actividad;
    }

    public void salio() 
    {
        pogger.SetActive(false);
        puedePresionar = false;
    }
}
