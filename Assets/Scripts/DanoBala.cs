using UnityEngine;

public class DanoBala : MonoBehaviour
{
    public int dano = 1; // Cantidad de vida a restar a la torreta

    private void OnCollisionEnter(Collision collision)
    {
        VidaEnemigos torreta = collision.gameObject.GetComponent<VidaEnemigos>(); // Obtener referencia al script de la torreta

        if (torreta != null)
        {
            torreta.RecibirDano(dano); // Reducir la vida de la torreta
           
        }

        Destroy(gameObject); // Destruir la bala
    }
}

