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
        // Verificar si el jugador está dentro del rango de disparo
        if (Vector3.Distance(transform.position, player.position) <= distanciaDisparo)
        {
            // Calcular la dirección hacia el jugador
            Vector3 direccionJugador = player.position - transform.position;

            // Calcular el ángulo entre la dirección hacia el jugador y la dirección hacia abajo
            float angulo = Vector3.Angle(direccionJugador, Vector3.down);

            // Rotar hacia la posición del jugador
            Quaternion rotacion = Quaternion.LookRotation(direccionJugador);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, velocidadRotacion * Time.deltaTime);

            // Disparar si ha pasado suficiente tiempo desde el último disparo y el ángulo es mayor que el máximo permitido
            if (Time.time > tiempoUltimoDisparo + tiempoEntreDisparos && angulo > anguloMaximo)
            {
                Disparar();
                tiempoUltimoDisparo = Time.time;
            }
        }
    }

    private void Disparar()
    {
        // Instanciar el proyectil en el punto de disparo
        Instantiate(proyectilPrefab, puntoDisparo.position, puntoDisparo.rotation);
    }
}

