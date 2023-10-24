using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformasFalsas : MonoBehaviour
{


    [Header("Plataformas")]
    [SerializeField] public Rigidbody2D plataforma;
    [SerializeField] private float tiempoEspera;
    
    private Vector2 plataformaPosicionInicial;
    
    private bool caida = false;

    // Start is called before the first frame update
    void Start()
    {        
        
        plataformaPosicionInicial = plataforma.position;

    }

    // Update is called once per frame
    void Update()
    {
        

    }


    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Caida(colision));

        }
    }


    private IEnumerator Caida(Collision2D colision)
    {
        yield return new WaitForSeconds(tiempoEspera);
        caida = true;
       
        plataforma.constraints = RigidbodyConstraints2D.None;
        plataforma.constraints = RigidbodyConstraints2D.FreezeRotation;

        yield return new WaitForSeconds(3);

        plataforma.constraints = RigidbodyConstraints2D.FreezeAll;
        plataforma.position = plataformaPosicionInicial;      

    }

}
