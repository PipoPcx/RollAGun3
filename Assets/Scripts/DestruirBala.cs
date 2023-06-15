using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirBala : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colision pares");
        if (collision.gameObject.CompareTag("Pared"))
        {
            Destroy(gameObject); // Destruir la bala
        }
    }
}
