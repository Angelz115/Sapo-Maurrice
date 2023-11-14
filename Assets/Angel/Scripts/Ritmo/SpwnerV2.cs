using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwnerV2 : MonoBehaviour
{
    [Header("Variables por a asignar")]

    [SerializeField] GameObject objeto;
    [SerializeField] List<Transform> posicionCreacion = new List<Transform>();
    [SerializeField] List<Transform> objetivos = new List<Transform>();
    [SerializeField] List<Color> colorObjetivo = new List<Color>();
    public float test;
    [Space]

    [Header("Variables internas")]
    [SerializeField] int estres;
    [SerializeField] int cantidad;
    [SerializeField] float temporizador;
    [SerializeField] float entreTiempo;



    private void Start()
    {
        Debug.Log("crear");
        Asignar();
    }

    public void Asignar() 
    {
        estres = GameManager.Instance.SacarEstres();
        entreTiempo = estres / test;
        if (estres == 0)
        {
            cantidad = 10;
        }
        else
        {
            cantidad = estres + 10;
        }

    }
}
/*
 * public void sacarStats() 
    {
        List<int> stats = new List<int>();
        stats[0] = estres;
        stats[1] = sociabilidad;
        stats[2] = cansancio;
        stats[3] = conocimiento;
    }
*/
