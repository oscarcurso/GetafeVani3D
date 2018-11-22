using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoInicio : MonoBehaviour {

    private AudioSource audioFondo;
	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>();
        audioFondo.Play();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
