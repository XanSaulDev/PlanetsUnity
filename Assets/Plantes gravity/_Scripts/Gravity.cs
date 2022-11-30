using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{   
    //declaro la variable para obtener mi rigidbody
    private Rigidbody rb;
    // obtengo mi transform para agrandar por script nuestro campo
    private Transform _transform;
    // declaro la constante de la ley de gravitacion
    private double G = 6.67428 * Math.Pow(10, -11);
    // declaro nuestro diametro
    public float diameter;
    // y a la potencia que va a ir nuestro diametro con notacion cientifica
    public int diameterPow;
    // lo mismo para la masa
    public float mass;
    public int massPow;
    /*
     * Cabe decir que se tuvo que hacer de esta manera, ya que no podemos escalar las esferas
     * demasido grandes ya que no caben en pantalla, ademas de que a gran escala se deforman
     * e igual con la masa, desde script tomo los datos hago el calculo y se lo asigno al rigidbody
     */
    private void Awake()
    {
        // obtenemos nuestro rigidbody
        rb = GetComponentInParent<Rigidbody>();
        // obtenemos nuestro transform
        _transform = gameObject.transform.parent.GetComponent<Transform>();
        // agrandamos nuestro campo en el cual detectamos los objetos cerca de nosotros
        GetComponent<SphereCollider>().radius = _transform.localScale.x*1000;
        
    }
    void Update()
    {
        // this is not the way
        //_direction = (sun.transform.position - transform.position).normalized; 
    }

    private void OnTriggerStay(Collider other)
    {
        // obtenemos la direccion hacia donde se le tiene que aplicar la fuerza
        Vector3 direction = (_transform.position - other.transform.position).normalized;
        // esto es nuevo, ya que en funcion a la distancia la aceleracion disminuye
        // necesitamos sabes que tan lejos esta el objetos de nosotros, entonces este metodo
        // de la clase Vector3 nos dice a que distancia esta en metros
        // como nota, podemos multiplicar este numero por 10 o por 100 dependiendo de nuestra simulacion
        float distance = Vector3.Distance(transform.parent.transform.position,other.transform.position);
        // comprobamos que exista el rigidbody del objeto para que no marque errores
        if(other.GetComponent<Rigidbody>()){
            // le aplicamos la fuerza de tipo aceleracion
            // en la direccion correcta(hacia nosotros)
            other.GetComponent<Rigidbody>().AddForce(direction*( GravityAcceleration(mass, massPow, diameter, diameterPow,distance*1000)* Time.deltaTime),ForceMode.Acceleration);
        }
    }
    
    // le declaramos las variables que va a recibir para hacer los calculos
    public float GravityAcceleration(float mass,int massPow,float diameter, int diameterPow, float distance=0)
    {
        /*
         * masa, la potencia de la masa, el diametro, la potencia del diametro, y la distancia
         * la distancia por default es 0 por si no se le manda este no afecta en los calculos y no se vera
         * afectada la operacion.
         * Esto quiere decir que podemos hacer que tome la distancia o no depende de nuestra simulacion.
         */
        // calculo por parte para que no se vea feo y se pueda leer por el ojo humano
        
        // calculamos la masa
        double massCalcule =mass * Math.Pow( 10, massPow);
        // y se la asignamos a nuestro planeta, esto para que tenga el peso real y no solo
        // calcule la aceleracion
        rb.mass = Convert.ToSingle(massCalcule);
        // igual para el diametro, lo calculammos, en este caso solo el calculo para la operacion.
        double diameterCalcule = diameter * Math.Pow(10, diameterPow);
        // esta es la operacion de la ley de gravitacion...
        double calcule = G * (massCalcule/ Math.Pow(diameterCalcule+distance, 2));
        // lo convertimos a flotante ya que nos arroja un numero tipo double por los decimales
        float gravityForce = Convert.ToSingle(calcule);
        //la retornamos
        Debug.Log(gravityForce);
        return gravityForce;
    } 
}
