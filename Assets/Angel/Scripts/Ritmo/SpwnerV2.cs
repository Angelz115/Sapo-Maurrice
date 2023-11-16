using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpwnerV2 : MonoBehaviour
{
    [Header("Variables por a asignar")]

    [SerializeField] GameObject objeto;

    [SerializeField] List<Transform> posicionCreacion = new List<Transform>();
    [SerializeField] List<Transform> objetivos = new List<Transform>();
    [SerializeField] List<Color> colorObjetivo = new List<Color>();

    public float test, test2;

    [Space]

    [Header("Variables internas")]

    [SerializeField] int estres;
    [SerializeField] int cantidad;
    [SerializeField] int recorridoLista;

    [SerializeField] float temporizador;
    [SerializeField] float entreTiempo;
    [SerializeField] float fuerza;

    [SerializeField] List<int> Origen = new List<int>();
    [SerializeField] List<int> Objetivo = new List<int>();


    private void Start()
    {
        Asignar();
    }
    private void Update()
    {
        if (recorridoLista >= cantidad)
        {
            return;
        }
        temporizador += Time.deltaTime;
        if (temporizador >= entreTiempo)
        {
            Crear();
        }
    }
    private void Asignar() 
    {
        estres = GameManager.Instance.SacarEstres();

        if (estres == 0)
        {
            cantidad = 60;
            entreTiempo = test2;
        }
        else
        {
            cantidad = estres * 2 + 60;
            entreTiempo = test / estres;
        }

        for (int i = 0; i < cantidad; i++)
        {
            Origen.Add(random());
            Objetivo.Add(random());
        }

        int random() 
        { 
            int ret = Random.Range(0, 4);
            return ret;
        }
    }
    private void Crear() 
    {
        GameObject Obj = Instantiate(objeto,posicionCreacion[Origen[recorridoLista]]);
        Obj.GetComponent<Pop>().nuevoColor = colorObjetivo[Objetivo[recorridoLista]];
        Obj.GetComponent<Pop>().objectivo = objetivos[Objetivo[recorridoLista]];
        Obj.GetComponent<Pop>().fuerza = fuerza;
        
        temporizador = 0;
        recorridoLista++;
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
