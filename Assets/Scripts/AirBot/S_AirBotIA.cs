using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class S_AirBotIA : MonoBehaviour
{
    #region Variables

    [Header("Par�metros")]

    [Tooltip("Si el jugador se encuentro dentro de esta distancia, el bot perseguir�. Si es mayor, dejar� de perseguir")]
    public float maxDistanceToFollow;

    [Tooltip("Si el bot se acerca lo suficiente, �ste se alejar� para no pegarse al jugador")]
    public float distanceToAway;

    [Tooltip("La distancia a la que se encontrar� el bot del jugador")]
    public float additionalSpace;

    public float pursuitSpeed;

    [Tooltip("El suavizado en la desviaci�n del movimiento")]
    public float smoothness = 1f;

    [Header("Controladores del Offset")]
    public float xzMaxOffset; // Rango m�ximo de desviaci�n
    public float yMaxOffset; // Rango m�ximo de desviaci�n

    [Tooltip("Define cada cuanto se har� una nueva desviaci�n aleatoria")]
    public float rInterval = 1f; // Intervalo de actualizaci�n de la desviaci�n aleatoria

    [Tooltip("La distancia m�xima a la que puede estar el Bot del jugador, as� no se aleja demasiado")]
    public float maxDistanceToPlayer; // El bot no se puede alejar tanto del player

    [Tooltip("Velocidad con la que el bot se desv�a aleatoriamente")]
    public float deviationSpeed;


    private float rTimer; // Temporizador para controlar actaulizaci�n de la desviaci�n aleatoria
    private float initialYPos;
    private Vector3 randomOffset;
    private Vector3 currentVelocity;
    #endregion


    #region M�todos
    private void Start()
    {
        initialYPos = transform.position.y;
        randomOffset = GetRandomOffset();
        rTimer = rInterval;
    }

    void Update()
    {

        GameObject player = GameObject.FindWithTag("Player");

        // Calcular la velocidad deseada
        Vector3 desiredVelocity = player.transform.position - transform.position;
        desiredVelocity.y = 0;
        desiredVelocity = desiredVelocity.normalized * pursuitSpeed;

        float distance = Vector3.Distance(transform.position, player.transform.position);
        //Debug.Log(distance);

        if (distance <= maxDistanceToFollow) {
            if (distance > distanceToAway) {

                // Aplica la desviaci�n aleatoria con la velocidad de desviaci�n
                Vector3 desiredVelocityWithOffset = desiredVelocity + randomOffset;
                desiredVelocityWithOffset = desiredVelocityWithOffset.normalized * deviationSpeed;

                //Calcula la Pos objetivo con la desviaci�n aleatoria
                Vector3 targetPos = player.transform.position + desiredVelocityWithOffset;
                Vector3 clampedPos = Vector3.ClampMagnitude(targetPos - transform.position, maxDistanceToPlayer);
                targetPos = transform.position + clampedPos;

                //Moverse hacia la posici�n objetivo m�s el suavizado
                transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref currentVelocity, smoothness);

                //Actualizar la desviaci�n aleatoria
                rTimer -= Time.deltaTime;
                if (rTimer <= 0f)
                {

                    randomOffset = GetRandomOffset();
                    rTimer = rInterval;
                }
            }

            else {

                Vector3 targetPosition = player.transform.position - desiredVelocity.normalized * (distanceToAway + additionalSpace);
                targetPosition.y = initialYPos;

                //Seguir al jugador con la Velocidad de persecusi�n
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, pursuitSpeed * Time.deltaTime);
            }

        }

    } 

    #endregion

    Vector3 GetRandomOffset()
    {
        //Obtiene un valor aleatorio en los 3 ejes para desviar el movimiento (esquivar balas del jugador)
        return new Vector3(
            UnityEngine.Random.Range(-xzMaxOffset,xzMaxOffset),
            UnityEngine.Random.Range(-yMaxOffset,yMaxOffset),
            UnityEngine.Random.Range(-xzMaxOffset, xzMaxOffset));
    }
}
