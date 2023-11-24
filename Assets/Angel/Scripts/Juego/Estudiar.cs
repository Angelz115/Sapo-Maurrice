using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estudiar : MonoBehaviour
{
    [SerializeField] string texto;
    [SerializeField] Actividad actividad;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.GetComponent<PlayerInput>().LLamarAccion(texto, actividad);
        
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.gameObject.GetComponent<PlayerInput>().salio();


    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //GameManager.Instance.EmperzarEstudio();
            //GameManager.Instance.PreguntarSi(texto);
            
        }
    }
    */

}
