using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prender : MonoBehaviour
{
    [SerializeField] GameObject UI;
    [SerializeField] GameObject spawner;
    [SerializeField] List<Transform> posicionCreacion = new List<Transform>();
    [SerializeField] List<Transform> objetivos = new List<Transform>();

    public void ActivarUI() 
    {
        UI.SetActive(true);
        GameObject Spawner = Instantiate(spawner, transform.position,Quaternion.identity);
        Spawner.GetComponent<SpwnerV2>().setList(posicionCreacion, objetivos);
        
    }
    public void ApagarUI() 
    {
        UI.SetActive(false);
        
    }
}
