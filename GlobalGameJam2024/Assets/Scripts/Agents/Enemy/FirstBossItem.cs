using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FirstBossItem : MonoBehaviour
{
    public float radius = 2f;    // Raio do círculo
    public float rotationSpeed = 50f;  // Velocidade de rotação
    public float movementDuration = 5f;  // Duração do movimento em segundos
    public float pauseDuration = 2f;   // Duração da pausa em segundos
    private float angle; // Ângulo inicial

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
            // Calcular a diferença nos eixos X e Y entre este objeto e o objeto alvo
            float deltaX = bossObject.position.x - transform.position.x;
            float deltaY = bossObject.position.y - transform.position.y;

            // Calcular o ângulo em radianos usando a função Atan2
            float targetAngle = Mathf.Atan2(deltaY, deltaX);

            // Converter o ângulo para graus
            angle = targetAngle * Mathf.Rad2Deg;
        }
        else
        {
            Debug.LogError("Objeto alvo não atribuído!");
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
                // Iniciar a pausa após o período de movimento
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
                // Retornar ao movimento após o período de pausa
                timer = 0f;
                isMoving = true;
                CalculateAngle(); // Recalcular o ângulo ao retomar o movimento
            }
        }
    }

    void Movement()
    {
        if (bossObject != null)
        {
            // Atualizar o ângulo com base no tempo e na velocidade de rotação
            angle += rotationSpeed * Time.deltaTime;

            // Calcular as coordenadas circulares em relação ao objeto alvo
            float x = bossObject.position.x + Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
            float y = bossObject.position.y + Mathf.Sin(Mathf.Deg2Rad * angle) * radius;

            // Atualizar a posição do objeto
            transform.position = new Vector3(x, y, 0f);
        }
        else
        {
            Debug.LogError("Objeto alvo não atribuído!");
        }
    }

    void HandlePause()
    {
        currentPauseTime += Time.deltaTime;

        if (currentPauseTime >= pauseDuration)
        {
            // Reiniciar o movimento circular após a pausa
            currentPauseTime = 0f;
            isPaused = false;
        }
    }
}
