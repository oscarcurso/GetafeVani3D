﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esqueletoScript : MonoBehaviour {


    private Player player;
    // Use this for initialization
    private void Start() {
        player = GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.name == "Player") {

            player.Recibirdanyo(10);
        }
    }
}
