using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------------ Audio Source ------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("------------ Audio Clip ------------")]
    public AudioClip background;
    public AudioClip minijuego;
    public AudioClip recueracion;
    public AudioClip opcionSi;
    public AudioClip opcionNo;
    public AudioClip soundEffects;
    public AudioClip gameOver;
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
