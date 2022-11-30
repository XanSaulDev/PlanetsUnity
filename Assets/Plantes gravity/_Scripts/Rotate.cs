using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // que tan rapido va a girar, se puede cambiar desde el editor
    public float speedRotation = 0.1f;
    void Update()
    {
        // por cada frame lo hacemos rotar
        // multiplicamos el deltatime por la variable de velocidad y listo
        transform.Rotate(0, Time.deltaTime * speedRotation,  0, Space.Self); 
    }
}
