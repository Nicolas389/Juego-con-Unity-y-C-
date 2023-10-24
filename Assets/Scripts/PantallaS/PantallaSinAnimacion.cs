using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PantallaSinAnimacion : MonoBehaviour
{
    [Header("Puerta")]
    [SerializeField] GameObject puerta;
    [SerializeField] BoxCollider2D colision;
    [SerializeField] LayerMask boxCastMask;
    private float tiempoEspera = 1.5f;

    [Header("Animacion")]
    [SerializeField] Animator animacionPuerta;
    [SerializeField] GameObject F;

    // Update is called once per frame
    void Update()
    {
        if (abrirPuerta(Vector2.right) || abrirPuerta(Vector2.left))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {

                Destroy(puerta, 1f);
                Destroy(F,1f);
                StartCoroutine(AnimacionApretarPantalla());


            }
        }
    }


    public IEnumerator AnimacionApretarPantalla()
    {             
        yield return new WaitForSeconds(tiempoEspera);
        
        animacionPuerta.SetBool("puertaAbierta", true);    
                
    }



    bool abrirPuerta(Vector2 direccion)
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(colision.bounds.center, size: colision.bounds.size, 0, direccion, 0.2f, boxCastMask);

        return raycastHit2D.collider != null;
    }
}
