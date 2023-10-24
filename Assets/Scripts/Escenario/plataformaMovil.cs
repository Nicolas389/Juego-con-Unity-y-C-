using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaMovil : MonoBehaviour
{
    public GameObject[] posiciones;
    int posicionIndex = 0;
    public float velocidad;
    
  
    // Update is called once per frame
    void Update()
    {
        Mover();
    }


    private void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.CompareTag("Final"))
        {
            posicionIndex = 1;

        }else if (colision.gameObject.CompareTag("Inicio"))
        {
            posicionIndex = 0;
        }
    }

    void Mover()
    {     
      transform.position = Vector3.MoveTowards(transform.position, posiciones[posicionIndex].transform.position, velocidad * Time.deltaTime);

    }
}
