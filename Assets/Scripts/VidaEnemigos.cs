using UnityEngine;

public class VidaEnemigos : MonoBehaviour
{
    public int vidaMaxima = 3;
    
    public int vidaActual; 

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
        }
    }

    public void RecibirDano(int cantidad)
    {
        Debug.Log("vidatorreta1");
        vidaActual -= cantidad;

        if (vidaActual <= 0)
        {
            vidaActual = 0;
            Debug.Log("vidatorreta2");
        }
    }
}

