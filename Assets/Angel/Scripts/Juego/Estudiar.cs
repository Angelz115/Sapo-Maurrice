using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estudiar : MonoBehaviour
{
    [SerializeField] string texto;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //GameManager.Instance.EmperzarEstudio();
            GameManager.Instance.PreguntarSi(texto);
        }
    }
    
}
