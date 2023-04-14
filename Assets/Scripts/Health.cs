using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int scoreValue = 50;
    [SerializeField] ParticleSystem hitEffects;
    [SerializeField] bool applyCameraShake;

    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;
    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            PlayHitSound();
            ShakeCamera();
            damageDealer.Hit();
        }
    }
    public int GetHealth()
    {
        return health;
    }
    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        if(!isPlayer)
        {
            IncreaseScore();
        }
        else
        {
            levelManager.LoadGameOverMenu();
        }
        Destroy(gameObject);
    }
    private void PlayHitEffect()
    {
        if(hitEffects != null)
        {
            ParticleSystem instance = Instantiate(hitEffects,transform.position,Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    private void ShakeCamera()
    {
        if (applyCameraShake && cameraShake != null)
        {
            cameraShake.Play();
        }
    }

    private void PlayHitSound()
    {
        if(audioPlayer != null)
        {
            audioPlayer.PlayHitSound();
        }
    }

    private void IncreaseScore()
    {
        scoreKeeper.ModifyScore(scoreValue);
    }
}
