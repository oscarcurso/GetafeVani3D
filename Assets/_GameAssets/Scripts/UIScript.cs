using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {
    [SerializeField] Player player;
    [SerializeField] GameObject panelVidas;
    public GameObject prefabImagenVida;
    Image nuevaImage;
    // Image[] imagenesVida= new Image[5];
    public GameObject[] imagenesVida;
    private int numeroVidas;
    



    void Start () {
        numeroVidas = player.GetVidas();
        imagenesVida = new GameObject[numeroVidas];


        for(int i=0; i< imagenesVida.Length; i++) {
            imagenesVida[i] = Instantiate(prefabImagenVida, panelVidas.transform);
            
        }
		
	}

    public void RestarVida() {
        numeroVidas = player.GetVidas();
        for (int i = numeroVidas; i > imagenesVida.Length; i++) {
            Destroy(imagenesVida[i].gameObject);
        }

    }

}
