using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_Bala360 : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 3f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void FireInLine()
    {
        
    }

    internal void FireInLine(Vector3 direction)
    {
        throw new NotImplementedException();
    }
}
