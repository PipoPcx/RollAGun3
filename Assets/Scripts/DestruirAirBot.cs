using UnityEngine;

public class DestruirAirBot : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AirBot"))
        {
            Destroy(collision.gameObject);
        }
    }
}