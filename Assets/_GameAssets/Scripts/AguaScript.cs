using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguaScript : MonoBehaviour {
    private PlayerScript player;

    private void Start() {
        player = GetComponent<PlayerScript>();
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.name == "Player") {
            player.RecibirDanyo(20);
        }
        
    }
}
