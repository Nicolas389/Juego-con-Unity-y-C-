using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinEscenario : MonoBehaviour
{

    public BoxCollider2D colision;
    public LayerMask boxCastMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Fin() && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("Win");           
        }
       
    }
      
    bool Fin()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(colision.bounds.center, size: colision.bounds.size, 0, Vector2.left, 0.2f, boxCastMask);

        return raycastHit2D.collider != null;
    }
}
