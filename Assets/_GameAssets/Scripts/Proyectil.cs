using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {

    private void Start() {
      
        Invoke("Destruir", 3);
    }
   
    private void Destruir() {
        Destroy(this.gameObject);
    }
}
