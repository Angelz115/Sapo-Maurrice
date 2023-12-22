using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private bool puedeSalir;
    public void aMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Pieza() 
    {
        SceneManager.LoadScene(1);
    }
    public void aPieza() 
    {
        
        salir();
        if (puedeSalir)
        {
            GameManager.Instance.pasarTiempo();
            manger();
            SceneManager.LoadScene(1);
        }
        else
        {
            GameManager.Instance.quedateEnCasa();
        }
    }

    public void aUniversidad()
    {
        if (GameManager.Instance.veACasa())
        {
            return;
        }
        salir();

        if (puedeSalir)
        {
            GameManager.Instance.pasarTiempo();
            manger();
            SceneManager.LoadScene(2);
        }
        else
        {
            GameManager.Instance.quedateEnCasa();
        }
    }
    public void aParque() 
    {
        if (GameManager.Instance.veACasa())
        {
            return;
        }
        salir();
        
        if (puedeSalir)
        {
            GameManager.Instance.pasarTiempo();
            manger();
            SceneManager.LoadScene(3);
        }
        else
        {
            GameManager.Instance.quedateEnCasa();
        }
    }
    private void salir() 
    {
        if (GameManager.Instance.sacarHorario() == Horario.noche)
        {
            puedeSalir = false;
            
        }
        else
        {
            puedeSalir = true;
        }
        
    }
    private bool noche() 
    {
        bool no = false;
        if (GameManager.Instance.sacarHorario() == Horario.noche)
        {
            GameManager.Instance.quedateEnCasa();
            no = true;
            return no;
        }
        ;
        return no;
    }
    private void manger() 
    {
        GameManager.Instance.setPrefs();
        
    }
}
