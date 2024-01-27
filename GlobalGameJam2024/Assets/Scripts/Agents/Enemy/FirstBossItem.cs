using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FirstBossItem : MonoBehaviour
{
    public float radius = 2f;    // Raio do c�rculo
    public float rotationSpeed = 50f;  // Velocidade de rota��o
    public float movementDuration = 5f;  // Dura��o do movimento em segundos
    public float pauseDuration = 2f;   // Dura��o da pausa em segundos
    private float angle; // �ngulo inicial

    private bool isMoving = true;
    private float timer = 0f;
    private bool isPaused = false;
    private float currentPauseTime = 0f;

    public Transform bossObject;

    void Start()
    {
        CalculateAngle();
    }

    void CalculateAngle()
    {
        if (bossObject != null)
        {
            // Calcular a diferen�a nos eixos X e Y entre este objeto e o objeto alvo
            float deltaX = bossObject.position.x - transform.position.x;
            float deltaY = bossObject.position.y - transform.position.y;

            // Calcular o �ngulo em radianos usando a fun��o Atan2
            float targetAngle = Mathf.Atan2(deltaY, deltaX);

            // Converter o �ngulo para graus
            angle = targetAngle * Mathf.Rad2Deg;
        }
        else
        {
            Debug.LogError("Objeto alvo n�o atribu�do!");
        }
    }

    private void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        if (isMoving)
        {
            Movement();
            timer += Time.deltaTime;

            if (timer >= movementDuration)
            {
                // Iniciar a pausa ap�s o per�odo de movimento
                timer = 0f;
                isMoving = false;
            }
        }
        else
        {
            HandlePause();
            timer += Time.deltaTime;

            if (timer >= pauseDuration)
            {
                // Retornar ao movimento ap�s o per�odo de pausa
                timer = 0f;
                isMoving = true;
                CalculateAngle(); // Recalcular o �ngulo ao retomar o movimento
            }
        }
    }

    void Movement()
    {
        if (bossObject != null)
        {
            // Atualizar o �ngulo com base no tempo e na velocidade de rota��o
            angle += rotationSpeed * Time.deltaTime;

            // Calcular as coordenadas circulares em rela��o ao objeto alvo
            float x = bossObject.position.x + Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
            float y = bossObject.position.y + Mathf.Sin(Mathf.Deg2Rad * angle) * radius;

            // Atualizar a posi��o do objeto
            transform.position = new Vector3(x, y, 0f);
        }
        else
        {
            Debug.LogError("Objeto alvo n�o atribu�do!");
        }
    }

    void HandlePause()
    {
        currentPauseTime += Time.deltaTime;

        if (currentPauseTime >= pauseDuration)
        {
            // Reiniciar o movimento circular ap�s a pausa
            currentPauseTime = 0f;
            isPaused = false;
        }
    }
}
