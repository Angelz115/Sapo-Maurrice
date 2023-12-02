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

    public int objetivoN;
    [SerializeField] bool puedoPresionar;
    [SerializeField] KeyCode estaTecla;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager.PlaySFX(audioManager.minijuego);
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().color = nuevoColor;
        Vector2 direccion = new Vector2(objectivo.position.x- transform.position.x, objectivo.position.y - transform.position.y);
        rb.AddForce(direccion.normalized * fuerza);
    }
    private void Update()
    {
        if (puedoPresionar)
        {
            if (Input.GetKeyDown(estaTecla))
            {
                Debug.Log("Wena");
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tap"))
        {
            int id = collision.GetComponent<Tap>().SacarId();
            if (id == objetivoN)
            {
                estaTecla = collision.GetComponent<Tap>().SacarTecla();
                puedoPresionar = true;
            }
        }
        if (collision.CompareTag("Pop"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Tap"))
        {
            if (puedoPresionar)
            {
                puedoPresionar = false;
            }
        }
    }
}
