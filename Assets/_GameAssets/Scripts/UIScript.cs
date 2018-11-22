﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {
   
    public Image prefabImagenVida;
    public GameObject panelVidas;
    public PlayerScript ms;
    private int numeroVidas;
   
    Image[] imagenesVida;
    void Start() {
       
        
        numeroVidas = ms.GetVidas();
        imagenesVida = new Image[numeroVidas];

        for (int i = 0; i < imagenesVida.Length; i++) {
            imagenesVida[i] = Instantiate(prefabImagenVida, panelVidas.transform);
        }
    }

    public void RestarVida() {
        numeroVidas = ms.GetVidas();
        for (int i = numeroVidas; i < imagenesVida.Length; i++) {
            imagenesVida[i].color = new Color32(160, 160, 160, 128);
        }


    }
    public void BotonRecheck() {
        

        PlayerPrefs.DeleteAll();
    }
}
