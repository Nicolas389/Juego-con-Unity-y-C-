using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{

    [Header("Personaje")] //elementos del personaje
    [SerializeField] private Rigidbody2D personaje;
    [SerializeField] EdgeCollider2D colision;
    [SerializeField] SpriteRenderer render;
    [SerializeField] TrailRenderer trail;
    Animator animator;

    [Header("Movimiento")] // elementos de la accion mover
    [SerializeField] public float velocidadMovimiento;
    bool puedeGirar = true;
    int direccionMira = 1;    


    [Header("Salto")] // elementos de la accion saltar
    [SerializeField] public float fuerzaSalto;
    private float fuerzaSegundoSalto = 10f;
    [SerializeField] public float fuerzaCaida;
    public bool salto;
    public bool caida;
    public int cantidadSaltos = 1;
    public int numSaltos;

     
    [Header("Dash")] // elementos de la accion dash
    [SerializeField] float velocidadDash;
    [SerializeField] float tiempoDash;
    [SerializeField] float enfriamiento;
    bool puedeDash = true;
    bool Dasheando;

    [Header("Layer")] // para colision con paredes y suelo
    [SerializeField] LayerMask boxCastMask;

    [Header("Pausa")]
    bool pausado;

    private void Start()
    {
        animator = GetComponent<Animator>();
        pausado = false;
    }

    void Update()
    {
        if (Dasheando) // activa el dash
        {
            return;
        }

        // Mover horizontalmente

        Movimiento();
        if (Input.GetKeyDown(KeyCode.A) && puedeGirar)
        {
            
            render.flipX = !render.flipX; //cambia la direccion donde ve el personaje
            puedeGirar = false; 
            direccionMira = -1; // para que el dash funcione en la direccion que mira el personaje
            
        }
        else if (Input.GetKeyDown(KeyCode.D) && !puedeGirar)
        {
            
            render.flipX = false;
            puedeGirar=true;
            direccionMira = 1;
            
        }

        

        
        // Saltar
        if (Input.GetKeyDown(KeyCode.Space) && numSaltos > 0) 
        {
            salto = true; // para que pueda saltar
            caida = false; 
            numSaltos--; // para el doble salto
            animator.SetFloat("velocidadSalto", personaje.velocity.y);
        }

        if(!Input.GetKey(KeyCode.Space))
        {
            caida = true; // para caida cuando no hay piso debajo
            animator.SetFloat("velocidadSalto", personaje.velocity.y);
        }

        if (tocaElSuelo())
        {
            numSaltos = cantidadSaltos; //para el doble salto
            caida = false;
            animator.SetBool("tocaSuelo",true);
        }
        else
        {
            animator.SetBool("tocaSuelo", false);
        }
       
        //Dash
        if (Input.GetKeyDown(KeyCode.K) && puedeDash)
        {
            StartCoroutine(Dash(direccionMira)); // para hacer el dash                      

        }
    }

    private void FixedUpdate()
    {
        if (Dasheando)
        {
            return;
        }

        if (salto)
        {
           if(numSaltos > 0)
            {
                Salto(fuerzaSalto);
            }else if (numSaltos == 0)
            {
                Salto(fuerzaSegundoSalto);
            }         
           
        }
        
    }

    bool tocaElSuelo() 
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(colision.bounds.center, size: colision.bounds.size, 0, Vector2.down, 0.3f, boxCastMask);
         
        return raycastHit2D.collider != null;
    }


    private void Movimiento()
    {
        
        float movimientoHorizontal = Input.GetAxis("Horizontal");   

        if(movimientoHorizontal !=  0)
        {
            animator.SetBool("Corriendo",true);
        }
        else
        {
            animator.SetBool("Corriendo", false);
        }
        Vector2 movimiento = new Vector2(movimientoHorizontal, 0);
        personaje.velocity = new Vector2(movimiento.x * velocidadMovimiento, personaje.velocity.y);        
    }

    
    

    private void Salto(float fSalto)
    {
        
        personaje.AddForce(Vector2.up * fSalto, ForceMode2D.Impulse);
        salto = false;
        
    }

    

    private IEnumerator Dash(int direccion)
    {
        print("Empieza");
        
        puedeDash = false;
        Dasheando = true;
        personaje.gravityScale = 2f;
        animator.SetTrigger("Dash");

        personaje.velocity = new Vector2((transform.localScale.x * direccion) * velocidadDash, 0f);
        trail.emitting = true;
        
        yield return new WaitForSeconds(tiempoDash);
        trail.emitting = false;
        personaje.gravityScale = 5f;
        Dasheando = false;
        

        yield return new WaitForSeconds(enfriamiento);
        puedeDash = true;
        print("Termina");
       
    }


   
 
    }
