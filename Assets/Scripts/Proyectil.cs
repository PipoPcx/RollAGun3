using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velocidad = 10f;
    public int daño = 10;

    private void Update()
    {
        // Mover el proyectil hacia adelante
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }

   
}

