using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour
{
    [SerializeField] KeyCode tecla;
    [SerializeField] int id;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    public int SacarId() 
    {
        audioManager.PlaySFX(audioManager.minijuego);
        return id; 
    }
    public KeyCode SacarTecla() 
    {
        return tecla;
    }
}
