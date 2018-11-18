using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsqueletoScript : MonoBehaviour
{
    [SerializeField] ParticleSystem prefabExplosion;
    Rigidbody rb;
    public Rigidbody rbPlayer;
    int velocidad = 4;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        transform.Translate(Vector2.left * velocidad * Time.deltaTime);
    }
    public void Morir()
    {
        
        ParticleSystem ps = Instantiate(prefabExplosion, transform.position, Quaternion.identity);
        ps.Play();
        Destroy(this.gameObject);

    }
   
}
