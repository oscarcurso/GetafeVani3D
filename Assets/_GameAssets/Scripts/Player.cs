using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [SerializeField] Text txtPuntuacion;
    [SerializeField] Image imVidas;
    [SerializeField] float speed = 10;
    Rigidbody2D rb2D;
    [SerializeField] int vidas;
    [SerializeField] int puntos = 0;
    [SerializeField] float jumpForce = 50;
    [SerializeField] Transform posPies;
    [SerializeField] float radioOverlap = 0.1f;
    [SerializeField] LayerMask floorLayer;
    [SerializeField] GameObject[] corazonVidas;
    bool saltando = true;
    int vidasMaximas = 3;



    void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        txtPuntuacion.text = "Score: " + puntos.ToString();
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Space)) {

            saltando = true;
        }
    }



    void FixedUpdate() {


        
        float xPos = Input.GetAxis("Horizontal");
        float ySpeedActual = rb2D.velocity.y;

        if (saltando) {
            saltando = false;
            if (EstaEnElSuelo()) {
                rb2D.velocity = new Vector2(xPos * speed, jumpForce);
            } else {
                rb2D.velocity = new Vector2(xPos * speed, ySpeedActual);
            }
        } else {
            rb2D.velocity = new Vector2(xPos * speed, ySpeedActual);
        }
    }

    private bool EstaEnElSuelo() {
        bool enSuelo=false;
        Collider2D col = Physics2D.OverlapCircle(posPies.position, radioOverlap, floorLayer);
        if(col != null) {
            enSuelo = true;
        }
        return enSuelo;
    }
 
    
    /*
     * Version basada en tag y utilizando overlapcircleall
    private bool EstaEnElSuelo() {

        bool enSuelo = false;
        Collider2D[] cols = Physics2D.OverlapCircleAll(posPies.position, radioOverlap);
        for (int i = 0; i < cols.Length; i++) {
            if (cols[i].gameObject.tag == "Suelo") {
                enSuelo = true;
                break;

            }
        }


        return enSuelo;
    }*/ 

    public void IncrementarPuntuacion(int puntosAIncrementar) {

        puntos = puntos + puntosAIncrementar;
        txtPuntuacion.text = "Score: " + puntos.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Moneda")) {

            IncrementarPuntuacion(1);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("CajaVida")) {

            IncrementarVidas(1);
            Destroy(collision.gameObject);
        }
    }

    public void IncrementarVidas(int vidasAIncrementar) {

        vidas = vidas + vidasAIncrementar;
        //Renderer.Instantiate("Vidas", new Vector3(23, 34, 0), Quaternion rotation);
        print("Hasta aqui llego");

    }
}
