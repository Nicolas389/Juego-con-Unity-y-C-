using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Autos : MonoBehaviour
{


    [Header("Auto")]
    public GameObject auto;
    public GameObject posicionFinal;
    public BoxCollider2D colision;
    public LayerMask boxCastMask;
    Vector3 posicion;
    public int x;
    public int y;
    public int z;
    public float velocidad;


    private void Start()
    {
        posicion = new Vector3(x, y, z);
        
    }

    void Update()
    {
        Mover();
        if (Choque())
        {
            auto.transform.localPosition = posicion;
        }    
        
    }

    

    void Mover()
    {
        transform.position = Vector3.MoveTowards(transform.position, posicionFinal.transform.position, velocidad * Time.deltaTime);

    }


    bool Choque()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(colision.bounds.center, size: colision.bounds.size, 0, Vector2.right, 0.1f, boxCastMask);

        return raycastHit2D.collider != null;
    }

}
