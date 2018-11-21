using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasmascript : MonoBehaviour {

    bool activa;
    [SerializeField] GameObject puntoGeneracion;
    [SerializeField] GameObject prefabBala;
    [SerializeField] int potenciaDisparo = 100;


    private void Start() {
      
    }

    public void Disparar() {
        
        GameObject nuevaBala = Instantiate(
            prefabBala,
            puntoGeneracion.transform.position,
            puntoGeneracion.transform.rotation);
        nuevaBala.GetComponent<Rigidbody2D>().AddRelativeForce(Vector3.left * Time.deltaTime * potenciaDisparo);
    }

    public void Canyonazo() {

        Invoke("Disparar", 2);
    }
}
