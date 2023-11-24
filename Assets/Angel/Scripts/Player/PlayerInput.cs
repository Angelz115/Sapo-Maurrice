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
