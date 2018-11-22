using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasmascript : MonoBehaviour {

    bool activa;
    [SerializeField] ParticleSystem ps;
    [SerializeField] GameObject puntoGeneracion;
    [SerializeField] GameObject prefabBala;
    [SerializeField] int potenciaDisparo = 100;


    private void Start() {
        
        InvokeRepeating("Disparar", 1f, 5f);
    }

    public void Disparar() {
        
        GameObject nuevaBala = Instantiate(
            prefabBala,
            puntoGeneracion.transform.position,
            puntoGeneracion.transform.rotation);
        nuevaBala.GetComponent<Rigidbody2D>().AddRelativeForce(Vector3.left * potenciaDisparo);
    }

    public void Canyonazo() {

        Invoke("Disparar", 2);
    }
    private void OnCollisionEnter2D(Collision2D collision) {

        Instantiate(ps, transform.position, Quaternion.identity);
        Invoke("Morir", 0.1f);


    }

    private void Morir() {


        Destroy(transform.gameObject);
    }
}
