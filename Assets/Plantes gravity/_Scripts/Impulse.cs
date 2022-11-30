using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour
{
    // fuerza en newtons que se le aplicara en el comienzo de la simulacion
    public float impulseForce=0;
    // nuestro rigidbody que sirve para ejercer la fuerza
    private Rigidbody rb;
    // la direccion en la que ira nuestro impulso
    public Vector3 direction;

    private void Awake()
    {
        // obtenemos nuestro rigidbody
        rb = GetComponent<Rigidbody>();
    }
    
    void Start()
    { 
        // le damos el impulso en la direccion deseada justo en el inicio de la simulacion
        rb.AddForce(direction*impulseForce,ForceMode.Impulse);
    }
}