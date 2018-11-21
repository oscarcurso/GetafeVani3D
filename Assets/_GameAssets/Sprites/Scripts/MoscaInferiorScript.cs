using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoscaInferiorScript : MonoBehaviour {

    public int danyo = 20;
    private void OnCollisionEnter2D(Collision2D collision) {
       
        if (collision.gameObject.name == "Player") {
            collision.gameObject.GetComponent<PlayerScript>().RecibirDanyo(danyo);
        }
    }
}
