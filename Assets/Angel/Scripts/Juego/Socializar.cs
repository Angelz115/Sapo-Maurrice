using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socializar : MonoBehaviour
{
    public string texto;
    public TextAsset[] inkJSON;
    public TextAsset inkJSONDONE;
    public bool yaHablo;
    public int dia;
    private void Start()
    {
        dia = GameManager.Instance.dias;
        yaHablo = false;
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!yaHablo)
            {
                collision.GetComponent<PlayerInput>().LLamarAccion(texto, Actividad.socializar);
                GameManager.Instance.dialogos = inkJSON[dia];

            }
            else
            {

                collision.GetComponent<PlayerInput>().LLamarAccion(texto, Actividad.socializar);
                GameManager.Instance.dialogos = inkJSONDONE;
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.gameObject.GetComponent<PlayerInput>().salio();


    }
}
