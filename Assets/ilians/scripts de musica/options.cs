using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class options : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }
    public void PantallaCompleta(bool pantallaCompleta)
    {
        audioManager.PlaySFX(audioManager.opcionSi);
        Screen.fullScreen = pantallaCompleta;
    }
    public void CambiarVolumen(float volumen)
    {
        audioMixer.SetFloat("volumen", volumen);
    }
    public void CambiarVolumenSFX(float volumen)
    {
        audioMixer.SetFloat("SFX", volumen);
    }
}
