using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsqueletoScript : MonoBehaviour
{
    [SerializeField] ParticleSystem prefabExplosion;
   
    int velocidad = 1;

    private void Start()
    {
       // rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        transform.Translate(Vector2.left * velocidad * Time.deltaTime);
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().Recibirdanyo(20);
        }
    }*/



}
