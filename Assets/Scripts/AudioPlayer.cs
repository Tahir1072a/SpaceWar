using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f,1f)] float shootingVolume;
    [Header("Explosion")]
    [SerializeField] AudioClip hitClip;
    [SerializeField] [Range(0f,1f)] float hitVolume;

    Vector3 mainCameraPos;

    static AudioPlayer instance;

    private void Awake()
    {
        ManageSingelton();
    }

    private void ManageSingelton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        mainCameraPos = Camera.main.transform.position;
    }
    public void PlayHitSound()
    {
        PlaySound(hitClip, hitVolume);
    }
    public void PlayShootingSound()
    {
        PlaySound(shootingClip, shootingVolume);
    }
    private void PlaySound(AudioClip clip,float volume)
    {
        Vector3 cameraPos = Camera.main.transform.position;

        if(clip != null)
        {
            AudioSource.PlayClipAtPoint(clip,cameraPos,volume);
        }
    }
}
