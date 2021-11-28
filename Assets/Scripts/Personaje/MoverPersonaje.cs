using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoverPersonaje : MonoBehaviour
{
    [Header("General Variables")]
    public Rigidbody2D rb;
    public Animator animator;
    public int nivel;

    [Header("Move Mechanics")] 
    public float speed; 
    public float velX, velY;
    public SpriteRenderer SpriteRenderer;

    [Header("Jump Mechanics")] [Range(1, 20)]
    public float strenghJump;
    [Range(1, 20)]
    public float fallMultipler = 2.5f, lowJumpMultipler = 2, doubleJumpSpeed = 2.5f;
    public bool isGrounded = true, canDoubleJump = true;
    
    [Header("Escalar paredes Mechanics")]
    public bool tocandoPared;
    private bool tocandoParedDer = false, tocandoParedIzq = false;
    public float velocidadDeslizarPared = 0.80f;
    
    [Header("sonidos")] 
    public AudioSource clipSalto;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Movimiento personaje
        velX = Input.GetAxisRaw("Horizontal");
        velY = rb.velocity.y;
        // Controla si esta tocando alguna pared
        if (tocandoParedDer && velX == 1)
        {
            velX = 0;
        }

        if (tocandoParedIzq && velX == -1)
        {
            velX = 0;
        }
        rb.velocity = new Vector2(velX * speed, rb.velocity.y);
        if (velX < 0)
        {
            SpriteRenderer.flipX = true;
            animator.SetBool("correr",true);
        }
        else if (velX > 0)
        {
            SpriteRenderer.flipX = false;
            animator.SetBool("correr",true);
        }

        if (velX == 0)
        {
            animator.SetBool("correr",false);
        }

        if (tocandoPared == true)
        {
            animator.Play("pared");
        }
    }

    void Update()
    {
        // salto normal y doble salto poto sexo
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                canDoubleJump = true;
                Jump();
                clipSalto.Play();
                
            }
            if (canDoubleJump && !isGrounded)
            {
                //rb.velocity = Vector2.up * doubleJumpSpeed;
                canDoubleJump = false;
                Jump();
                clipSalto.Play();
            }
        }
            // animaciones
        if (isGrounded == false)
        {
            animator.SetBool("saltar", true);
            animator.SetBool("correr", false);
        }

        if (isGrounded == true)
        {
            animator.SetBool("saltar", false);
        }
        if (!isGrounded && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultipler + 1) * Time.deltaTime;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultipler - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultipler - 1) * Time.deltaTime;
        }

        if (tocandoPared)
        {
            //Animator.Play("wall"); ANIMACION
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -velocidadDeslizarPared, float.MaxValue));
        }

    }

    private void Jump()
    {
        rb.velocity = Vector2.up * strenghJump;
    }

    private void OnTriggerStay2D(Collider2D other) // Controla que es lo que esta tocando el jugador
    {
        if (other.CompareTag("Floor") || other.CompareTag("PlataformaMovil"))
        {
            isGrounded = true;
            canDoubleJump = true;
        }

        if (other.CompareTag("PlataformaMovil"))
        {
            transform.parent = other.transform;
        }

        if (other.CompareTag("ParedDerecha"))
        {
            isGrounded = true;
            canDoubleJump = true;
            tocandoPared = true;
            tocandoParedDer = true;
        }

        if (other.CompareTag("ParedIzquierda"))
        {
            isGrounded = true;
            canDoubleJump = true;
            tocandoPared = true;
            tocandoParedIzq = true;
        }

        if (other.CompareTag("Finish"))
        {
            switch (nivel)
            {
                case 1:
                    SceneManager.LoadScene("Nivel 1");
                    break;
                case 2:
                    SceneManager.LoadScene("Nivel 2");
                    break;
                case 3:
                    SceneManager.LoadScene("Nivel 3");
                    break;
                case 4:
                    SceneManager.LoadScene("Jefe Final");
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) // Controla si dejó de tocar algo el jugador
    {
        if (other.CompareTag("Floor") || other.CompareTag("PlataformaMovil"))
        {
            isGrounded = false;
        }

        if (other.CompareTag("PlataformaMovil"))
        {
            transform.parent = null;
        }
        if (other.CompareTag("ParedDerecha"))
        {
            isGrounded = false;
            tocandoPared = false;
            tocandoParedDer = false;
        }

        if (other.CompareTag("ParedIzquierda"))
        {
            isGrounded = false;
            tocandoPared = false;
            tocandoParedIzq = false;
        }
    }
}
