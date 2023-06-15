using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class Proyectil : MonoBehaviour
{
    public float velocidad = 10f;
    public int daño = 10;

    private void Update()
    {
        
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }


}

