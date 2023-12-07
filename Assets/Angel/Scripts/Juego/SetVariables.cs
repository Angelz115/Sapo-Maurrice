using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVariables : MonoBehaviour
{
    public GameObject cajaTexto;
    public GameObject cajaEstudio;
    public GameObject cajaSocializar;
    public GameObject cajaDormir;
    public GameObject cajaRelajo;
    public GameObject cajaSalir;
    public GameObject Fade;
    public GameObject mensaje;
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.setVars(cajaTexto,cajaEstudio,cajaSocializar,cajaDormir,cajaRelajo,cajaSalir,Fade,mensaje);
        
    }

    
}
