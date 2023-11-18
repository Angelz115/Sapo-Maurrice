using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStats : MonoBehaviour
{
    [SerializeField] int estres;
    [SerializeField] int sociabilidad;
    [SerializeField] int cansancio;
    [SerializeField] int conocimiento;
    public Animator animator;

    
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameManager.Instance.TerminarEstudio();
        }

    }
    public int valorEstres() 
    {
        return estres;
    }
    public int valorScoiabilidad() 
    {
        return sociabilidad;
    }
    public int valorCansancio() 
    {
        return cansancio;
    }
    public int valorConocimiento() 
    {
        return conocimiento;
    }
    
}
