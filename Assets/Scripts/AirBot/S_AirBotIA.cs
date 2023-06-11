using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class S_AirBotIA : MonoBehaviour
{
    #region Variables

    [Header("Parámetros")]

    [Tooltip("Si el jugador se encuentro dentro de esta distancia, el bot perseguirá. Si es mayor, dejará de perseguir")]
    public float maxDistanceToFollow;

    [Tooltip("Si el bot se acerca lo suficiente, éste se alejará para no pegarse al jugador")]
    public float distanceToAway;

    [Tooltip("La distancia a la que se encontrará el bot del jugador")]
    public float additionalSpace;

    public float pursuitSpeed;

    [Tooltip("El suavizado en la desviación del movimiento")]
    public float smoothness = 1f;

    [Header("Controladores del Offset")]
    public float xzMaxOffset; // Rango máximo de desviación
    public float yMaxOffset; // Rango máximo de desviación

    [Tooltip("Define cada cuanto se hará una nueva desviación aleatoria")]
    public float rInterval = 1f; // Intervalo de actualización de la desviación aleatoria

    [Tooltip("La distancia máxima a la que puede estar el Bot del jugador, así no se aleja demasiado")]
    public float maxDistanceToPlayer; // El bot no se puede alejar tanto del player

    [Tooltip("Velocidad con la que el bot se desvía aleatoriamente")]
    public float deviationSpeed;


    private float rTimer; // Temporizador para controlar actaulización de la desviación aleatoria
    private float initialYPos;
    private Vector3 randomOffset;
    private Vector3 currentVelocity;
    #endregion


    #region Métodos
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

                // Aplica la desviación aleatoria con la velocidad de desviación
                Vector3 desiredVelocityWithOffset = desiredVelocity + randomOffset;
                desiredVelocityWithOffset = desiredVelocityWithOffset.normalized * deviationSpeed;

                //Calcula la Pos objetivo con la desviación aleatoria
                Vector3 targetPos = player.transform.position + desiredVelocityWithOffset;
                Vector3 clampedPos = Vector3.ClampMagnitude(targetPos - transform.position, maxDistanceToPlayer);
                targetPos = transform.position + clampedPos;

                //Moverse hacia la posición objetivo más el suavizado
                transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref currentVelocity, smoothness);

                //Actualizar la desviación aleatoria
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

                //Seguir al jugador con la Velocidad de persecusión
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
