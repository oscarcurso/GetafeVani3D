using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoscaInferiorScript : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Player") {
            collision.gameObject.GetComponent<Player>().Recibirdanyo(20);
        }
    }
}
