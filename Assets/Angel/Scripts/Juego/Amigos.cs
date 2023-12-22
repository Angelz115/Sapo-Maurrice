using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amigos : MonoBehaviour
{
    public GameObject amigos;
    public int id;
    public bool test;

    private void Start()
    {
        if (test)
        {
            amigos.SetActive(true);
            return;
        }
        if (PlayerPrefs.GetInt("SocializandoPref") == 1)
        {
            amigos.SetActive(true);
            PlayerPrefs.SetInt("SocializandoPref",0);
            return;

        }
        Horario horario1 = GameManager.Instance.horarioActual;
        if (id == 0)            //esta es si estan en la u
        {
            
            if (horario1 == Horario.dia)
            {
                amigos.SetActive(true);
            }
            else
            {
                amigos.SetActive(false);
            }
        }
        
        if (id == 1)
        {
            
            if ( horario1 == Horario.mañana)
            {
                amigos.SetActive(false);
                return;
            }
            int random = Random.Range(0,3);
            Debug.Log(random);
            if (random > 1)
            {
                amigos.SetActive(true);
            }
            else
            {
                amigos.SetActive(false);
            }
        }
        

    }
}
