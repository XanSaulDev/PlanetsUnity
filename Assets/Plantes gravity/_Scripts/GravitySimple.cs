using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySimple : MonoBehaviour
{
    // para establecer desde el editor cuanta fuerza ejercer en el campo
    public float gravity;
    // para cachear y no consumir tanta memoria buscando el componente a cada frame
    private Transform _transform;

    private void Awake()
    {
        // obtenermos la componente transform
        _transform = gameObject.transform.parent.GetComponent<Transform>();
        // agrandamos el radio del trigger para que tengamos buen rango del campo
        GetComponent<SphereCollider>().radius = _transform.localScale.x*1000;
        
    }

    private void OnTriggerStay(Collider other)
    {
        // aqui si un obbjeto entra en el campo le sacamos la direccion a donde tiene que ir 
        Vector3 direction = (_transform.position - other.transform.position).normalized;
        // y me marcaba un error de que no encontraba el rigidbody entonces cree la condicion para que no llorar unity
        if(other.GetComponent<Rigidbody>()){
            /* y le aplicamos la fuerza en la direccion del planeta que esta ejerciendo la aceleracion
             la multiplicamos por el tiempo para que independiente de la maquino se le ejerza la misma aceleracion
             y le decimos que es de tipo aceleración.
             aqui obtengo en cada frame que el objeto que este dentro porque van a existir muchos objetos dentro
             entonces no puedo cachear los rigidbodys, bueno solo uno no, pero esta bien de esta manera.
            */
            other.GetComponent<Rigidbody>().AddForce(direction*( gravity* Time.deltaTime),ForceMode.Acceleration);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        // Para ver en consola el nombre del objeto
        Debug.Log(collision.transform.name);
    }
}
