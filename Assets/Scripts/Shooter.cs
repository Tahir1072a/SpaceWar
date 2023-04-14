using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectTilePrefab;
    [SerializeField] float projectTileSpeed = 10f;
    [SerializeField] float projectTileLifeTime = 5f;
    [SerializeField] float firingRate = 0.2f;
    [Header("AI Sets")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minFiringRate = 0f;

    [HideInInspector] public bool isFiring;

    Vector2 shootDirection = Vector2.up;

    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;
    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    private void Start()
    {
        if (useAI)
        {
            isFiring = true;
            shootDirection = Vector2.down;
        }
    }
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    private IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectTilePrefab, transform.position, Quaternion.identity);

            Rigidbody2D r2D = instance.GetComponent<Rigidbody2D>();
            if (r2D != null)
            {
                r2D.velocity = shootDirection * projectTileSpeed;
            }
            audioPlayer.PlayShootingSound();
            Destroy(instance, 5f);
            yield return new WaitForSeconds(GetRandomSpawnTime());
        }
    }
    private float GetRandomSpawnTime()
    {
        float spawnTime = UnityEngine.Random.Range(firingRate - firingRateVariance, firingRate + firingRateVariance);

        return Mathf.Clamp(spawnTime, minFiringRate, float.MaxValue);
    }
}
