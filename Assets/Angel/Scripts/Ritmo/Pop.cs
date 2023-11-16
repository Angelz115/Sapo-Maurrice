using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pop : MonoBehaviour
{
    public Color nuevoColor;
    public Transform objectivo;
    
    public Rigidbody2D rb;
    public float fuerza;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().color = nuevoColor;
        Destroy(gameObject, 4);
        
        Vector2 direccion = new Vector2(objectivo.position.x- transform.position.x, objectivo.position.y - transform.position.y);
        rb.AddForce(direccion * fuerza);
    }

    
}
