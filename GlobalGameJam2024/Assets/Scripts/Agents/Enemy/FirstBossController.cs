using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBossController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float waitTime = 2f;  // Tempo de espera em segundos
    public Transform[] destinations;
    public GameObject projectilePrefab;  // Prefab do projetil
    public Transform firePoint1;  // Ponto de origem do projetil
    public Transform firePoint2;  // Ponto de origem do projetil
    public Transform firePoint3;  // Ponto de origem do projetil
    public Transform firePoint4;  // Ponto de origem do projetil
    public float projectileSpeed = 10f;  // Velocidade do projetil
    private int currentDestinationIndex = 0;
    private bool isWaiting = false;
    private float waitTimer = 0f;

    public Health health;

    [Header("Audio Sources")]
    public AudioSource SfxAudioSource;
    public AudioSource BgAudioSource;

    [Header("Feedbacks")]
    public AudioClip changeDirectonSfx;
    public AudioClip ShootSfx;
   

    [Header("Musics")]
    public AudioClip backgroundMusic;

    private void Start()
    {
        health = GetComponent<Health>();
    }


    void Update()
    {
        if (!isWaiting)
        {
            MoveTowardsDestination();
        }
        else
        {
            // Incrementa o temporizador de espera
            waitTimer += Time.deltaTime;

            // Verifica se o tempo de espera foi atingido
            if (waitTimer >= waitTime)
            {
                isWaiting = false;
                waitTimer = 0f;

                // Seleciona o pr�ximo destino na lista (ciclicamente) ap�s esperar
                currentDestinationIndex = (currentDestinationIndex + 1) % destinations.Length;

                // Atira um projetil ao retomar o movimento
                ShootProjectile(firePoint1);
                ShootProjectile(firePoint2);
                ShootProjectile(firePoint3);
                ShootProjectile(firePoint4);

            }
        }
    }

    void MoveTowardsDestination()
    {
        if (destinations.Length == 0)
        {
            Debug.LogError("N�o h� destinos definidos para o inimigo.");
            return;
        }

        // Obt�m a posi��o do destino atual
        Vector2 targetPosition = destinations[currentDestinationIndex].position;

        // Move o inimigo em dire��o ao destino
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Verifica se o inimigo chegou ao meio do caminho entre destinos
        float distanceToTarget = Vector2.Distance(transform.position, targetPosition);
        float stoppingDistance = 0.5f;  // Ajuste conforme necess�rio

        if (distanceToTarget < stoppingDistance)
        {
            // Inicia a contagem regressiva de espera
            isWaiting = true;

            // Reproduz o som de mudan�a de dire��o
            SfxAudioSource.clip = changeDirectonSfx;
            SfxAudioSource.Play();
        }
    }

    void ShootProjectile(Transform direction)
    {
        // Cria um projetil no ponto de origem
        GameObject projectile = Instantiate(projectilePrefab, direction.position, direction.rotation);
        SfxAudioSource.clip = ShootSfx;
        SfxAudioSource.Play();

        // Configura a velocidade do projetil
        ProjectileController projectileController = projectile.GetComponent<ProjectileController>();
        if (projectileController != null)
        {
            projectileController.SetSpeed(projectileSpeed);
        }
    }
}
