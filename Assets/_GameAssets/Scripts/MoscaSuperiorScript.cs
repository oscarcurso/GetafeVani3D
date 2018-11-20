using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoscaSuperiorScript : MonoBehaviour {

   
    public ParticleSystem ps;

    private void Start() {
       
    }
    private void OnCollisionEnter2D(Collision2D collision) {

        Instantiate(ps, transform.position, Quaternion.identity);
        Invoke("Morir", 0.2f);
        
        
    }

    private void Morir() {

        Destroy(transform.parent.gameObject);
    }
}
