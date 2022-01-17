using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10;
    [SerializeField] float projectileLifeTime = 5;
    [SerializeField] float firingRate = 0.2f;
    [Header("AI")]
    [SerializeField] bool useAI = false;
    [SerializeField] float fireTimeVariant = 0f;
    [SerializeField] float minFireTime = 0.1f;

    [HideInInspector] public bool isFiring = false;
    Coroutine fireCoutine;
    Audio audioPlayer;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<Audio>();
    }

    void Start()
    {
        if(useAI)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && fireCoutine == null)
        {
            fireCoutine = StartCoroutine(FireContinously());
        } else if(!isFiring && fireCoutine != null)
        {
            StopCoroutine(fireCoutine);
            fireCoutine = null;
        }
    }

    IEnumerator FireContinously()
    {
        while(true)
        {
            GameObject instance = Instantiate(projectile, transform.position, Quaternion.identity);
            audioPlayer.PlayShootingClip();

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }

            Destroy(instance, projectileLifeTime);
            yield return new WaitForSeconds(GetRandomFiringSpeed());
        }
    }

    public float GetRandomFiringSpeed()
    {
        float spawnTime = Random.Range(firingRate - fireTimeVariant, firingRate + fireTimeVariant);
        return Mathf.Clamp(spawnTime, minFireTime, float.MaxValue);
    }
}
