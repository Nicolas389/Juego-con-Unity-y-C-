using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paredesFalsas : MonoBehaviour
{

    [SerializeField] Rigidbody2D personaje;
    
    [SerializeField] GameObject spawn;
    [SerializeField] BoxCollider2D colision;
    [SerializeField] LayerMask boxCastMask;
    Vector3 posicionInicial;



    // Start is called before the first frame update
    void Start()
    {
        posicionInicial = spawn.transform.position;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (CaidaVacio())
        {
           
            personaje.transform.localPosition = posicionInicial;
            
        }
    }

    bool CaidaVacio()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(colision.bounds.center, size: colision.bounds.size, 0, Vector2.up, 0.1f, boxCastMask);

        return raycastHit2D.collider != null;
    }

    
  
}
