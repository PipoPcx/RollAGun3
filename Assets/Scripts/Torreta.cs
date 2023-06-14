using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    public Transform player;
    public float distanciaDisparo = 10f;
    public float anguloMaximo = 45f;
    public GameObject proyectilPrefab;
    public Transform puntoDisparo;
    public float velocidadRotacion = 5f;
    public float tiempoEntreDisparos = 1f;
    public int vidaMaxima = 3; // Vida máxima de la torreta

    private int vidaActual; // Vida actual de la torreta
    private float tiempoUltimoDisparo;

    private void Start()
    {
        vidaActual = vidaMaxima;
    }

    private void Update()
    {
        if (vidaActual <= 0)
        {
            // La torreta ha sido destruida, realizar acciones necesarias (por ejemplo, reproducir efecto de explosión, sonidos, etc.)
            Destroy(gameObject); // Destruir la torreta
            return;
        }
     
        if (Vector3.Distance(transform.position, player.position) <= distanciaDisparo)
        {
            Vector3 direccionJugador = player.position - transform.position;
            float angulo = Vector3.Angle(direccionJugador, Vector3.down);
            Quaternion rotacion = Quaternion.LookRotation(direccionJugador);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, velocidadRotacion * Time.deltaTime);

            if (Time.time > tiempoUltimoDisparo + tiempoEntreDisparos && angulo > anguloMaximo)
            {
                Disparar();
                tiempoUltimoDisparo = Time.time;
            }
        }
    }

    private void Disparar()
    {
        // Realizar acciones de disparo

        Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);
    }

    public void RecibirDanio(int cantidad)
    {
        vidaActual -= cantidad;

        if (vidaActual <= 0)
        {
            vidaActual = 0;
        }
    }
}
