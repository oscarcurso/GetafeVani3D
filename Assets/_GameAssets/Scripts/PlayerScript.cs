﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    enum EstadoPlayer { Pausa, Parado, AndandoDer, AndandoIzq, Saltando, Sufriendo };
    EstadoPlayer estado = EstadoPlayer.Parado;

    [SerializeField] EsqueletoScript Esqueleto;

    [SerializeField] Text txtPuntuacion;
    [SerializeField] Text txtSalud;
    [SerializeField] float speed = 10;
    Rigidbody2D rb2D;
    [SerializeField] int vidas;
    [SerializeField] int puntos = 0;
    [SerializeField] float jumpForce = 7;
    [SerializeField] Transform posPies;
    [SerializeField] float radioOverlap = 0.1f;
    [SerializeField] LayerMask floorLayer;
    [SerializeField] GameObject[] corazonVidas;
    int saludMaxima = 100;
    [SerializeField] int salud;
    int vidasMaximas = 5;
    Animator playerAnimator;
    bool mirarFrente = true;


    public int fuerzaimpactoX = 5;
    public float fuerzaImpactoY = 0.2f;
    public UIScript uiScript;

    private void Awake()
    {
        vidas = vidasMaximas;
        salud = saludMaxima;
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        txtPuntuacion.text = "Score: " + puntos.ToString();
        txtSalud.text = "Salud: " + salud.ToString();
        Vector2 position = GameController.GetPosition();
        if (position != Vector2.zero) {
            this.transform.position = position;
        }



    }

    private void Update()
    {


        if (Input.GetKey(KeyCode.Space))
        {

            estado = EstadoPlayer.Saltando;
        }
        if (estado == EstadoPlayer.Sufriendo && EstaEnElSuelo())
        {
            estado = EstadoPlayer.Pausa;
        }
    }

    void CambiarOrientacion()
    {

        if (mirarFrente)
        {
            // transform.localScale = new Vector3(-1, 1,0);
        }
        else
        {
            // transform.localScale = new Vector3(1, 1,0);

        }
        mirarFrente = !mirarFrente;
    }



    void FixedUpdate()
    {



        float xPos = Input.GetAxis("Horizontal");
        float ySpeedActual = rb2D.velocity.y;



        if (estado == EstadoPlayer.Sufriendo)
        {
            return;
        }

        if (Mathf.Abs(xPos) > 0.01f)
        {
            playerAnimator.SetBool("andando", true);

        }
        else
        {

            playerAnimator.SetBool("andando", false);
        }




        if (estado == EstadoPlayer.Saltando)
        {
            estado = EstadoPlayer.Pausa;
            if (EstaEnElSuelo())
            {
                rb2D.velocity = new Vector3(xPos * speed, jumpForce);

            }
            else
            {
                rb2D.velocity = new Vector3(xPos * speed, ySpeedActual);

            }
        }
        else if (xPos > 0.01f)
        {
            {
                rb2D.velocity = new Vector3(xPos * speed, ySpeedActual);
                estado = EstadoPlayer.AndandoDer;


            }
        }
        else if (xPos < -0.01f)
        {

            rb2D.velocity = new Vector3(xPos * speed, ySpeedActual);
            estado = EstadoPlayer.AndandoIzq;

        }





     /*   if (mirarFrente && xPos < -0.01)
        {
            CambiarOrientacion();
        }
        else if (!mirarFrente && xPos > 0.01)
        {
            CambiarOrientacion();
        }*/

    }

    private bool EstaEnElSuelo()
    {
        bool enSuelo = false;
        Collider2D col = Physics2D.OverlapCircle(posPies.position, radioOverlap, floorLayer);
        if (col != null)
        {
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

    public void IncrementarPuntuacion(int puntosAIncrementar)
    {

        puntos = puntos + puntosAIncrementar;
        txtPuntuacion.text = "Score: " + puntos.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objetivoImpacto = collision.gameObject;

        // objetivoImpacto.GetComponent<EsqueletoScript>().Chocar();


        if (collision.gameObject.CompareTag("Moneda"))
        {

            IncrementarPuntuacion(1);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("CajaVida"))
        {

            IncrementarVidas(1);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("esqueleto"))
        {
           // print("colision esqueleto");
            Recibirdanyo(10);
            rb2D.AddRelativeForce(
            new Vector2(-fuerzaimpactoX, fuerzaImpactoY), ForceMode2D.Impulse);

        }

        if (collision.gameObject.CompareTag("cabeza")) {
            // print("colision esqueleto");

            Destroy(transform.parent.gameObject);

        }
    }


public void IncrementarVidas(int vidasAIncrementar)
{

    vidas = vidas + vidasAIncrementar;
    //Renderer.Instantiate("Vidas", new Vector3(23, 34, 0), Quaternion rotation);
    print("Hasta aqui llego");

}
public void Recibirdanyo(int danyo)
{


    salud = salud - danyo;

    if (salud <= 0)
    {

        vidas--;
        uiScript.RestarVida();
        salud = saludMaxima;
       

    }

    if (estado == EstadoPlayer.AndandoDer)
    {
        estado = EstadoPlayer.Sufriendo;
        GetComponent<Rigidbody2D>().AddRelativeForce(
        new Vector2(-fuerzaimpactoX, fuerzaImpactoY));
    }
    else if (estado == EstadoPlayer.AndandoIzq)
    {

        estado = EstadoPlayer.Sufriendo;
        GetComponent<Rigidbody2D>().AddRelativeForce(
       new Vector2(fuerzaimpactoX, fuerzaImpactoY));
    }

}

public void RecibirSalud(int incrementoSalud)
{
    salud = salud + incrementoSalud;
    salud = Mathf.Min(salud, saludMaxima); // igual que un if para que coja el valor menor
        txtSalud.text = "Salud: " + salud.ToString();
}


public int GetVidas()
{
    return this.vidas;
}
}
