using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sueloFalso : MonoBehaviour
{

    [Header("Plataformas")]
    [SerializeField] public Rigidbody2D plataforma;
    [SerializeField] private float tiempoEspera;
    [SerializeField] BoxCollider2D boxcol;
    private bool desactivada = false;
    [SerializeField] Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
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
        desactivada = true;

        boxcol.isTrigger = true;
        animator.SetBool("Activada", true);

        yield return new WaitForSeconds(3);

        animator.SetBool("Activada", false);

        boxcol.isTrigger = false;

    }

}
