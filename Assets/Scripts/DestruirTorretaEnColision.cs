using UnityEngine;

public class DestruirTorretaEnColision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            Destroy(gameObject);
        }
    }
}
