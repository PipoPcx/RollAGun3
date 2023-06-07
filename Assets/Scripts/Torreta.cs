using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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

    private float tiempoUltimoDisparo;

    private void Update()
    {
     
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
        
        Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);
    }
}

