using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPersonaje : MonoBehaviour
{
    [Header("General Variables")]
    public Rigidbody2D rb;

    [Header("Move Mechanics")] 
    public float speed; 
    public float velX, velY;
    
    [Header("Dash Mechanics")]
    public float dashCooldown;
    //public GameObject particulasDash; PARTICULAS DEL DASH
    public float dashForce=30;
    public SpriteRenderer SpriteRenderer;
    
    [Header("Jump Mechanics")] [Range(1, 20)]
    public float strenghJump, fallMultipler = 2.5f, lowJumpMultipler = 2, doubleJumpSpeed = 2.5f;
    public bool isGrounded = true, canDoubleJump;
    
    [Header("Escalar paredes Mechanics")]
    bool tocandoPared=false;
    bool deslizarPared;
    public float velocidadDeslizarPared = 0.80f;
    bool tocandoParedIzq;
    bool tocandoParedDer;
    public bool isTouchingWall;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        
        velX = Input.GetAxisRaw("Horizontal");
        velY = rb.velocity.y;
        rb.velocity = new Vector2(velX * speed, rb.velocity.y);

        if (velX < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
        }
    }

    void Update()
    {
        dashCooldown -= Time.deltaTime;
        if (Input.GetKey("c")&& dashCooldown<=2)
        {
            Dash();
        }

        // salto normal y doble salto poto sexo
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                canDoubleJump = true;
                Jump();
            }
            else
            {
                if (Input.GetButtonDown("Jump"))
                {
                    if (canDoubleJump)
                    {
                        //rb.velocity = Vector2.up * doubleJumpSpeed;
                        canDoubleJump = false;
                        Jump();
                    }
                }
            }

            if (isTouchingWall)
            {
                Jump();
            }
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

        if (tocandoPared==true)
        {
            deslizarPared = true;
        }
        else
        {
            deslizarPared = false;
        }

        if (deslizarPared)
        {
            //Animator.Play("wall"); ANIMACION
            rb.velocity = new Vector2(rb.velocity.x,
                Mathf.Clamp(rb.velocity.y, -velocidadDeslizarPared, float.MaxValue));
        }

    }

    private void Jump()
    {
        rb.velocity = Vector2.up * strenghJump;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Floor") || other.CompareTag("PlataformaMovil"))
        {
            isGrounded = true;
        }

        if (other.CompareTag("PlataformaMovil"))
        {
            transform.parent = other.transform;
        }

        if (other.CompareTag("ParedIzq") || other.CompareTag("ParedDer") )
        {
            isTouchingWall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Floor") || other.CompareTag("PlataformaMovil"))
        {
            isGrounded = false;
        }

        if (other.CompareTag("PlataformaMovil"))
        {
            transform.parent = null;
        }

        if (other.CompareTag("ParedDer")  || other.CompareTag("ParedIzq"))
        {
            isTouchingWall = false;
        }
    }

    public void Dash()
    {
        //GameObject dashObject;
        //dashObject = Instantiate();
        if (SpriteRenderer.flipX==true)
        {
            rb.AddForce(Vector2.left * dashForce,ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector2.right * dashForce,ForceMode2D.Impulse);
        }

        dashCooldown = 2;
       // Destroy(dashObject,1);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.CompareTag("ParedDer"))
        {
            tocandoPared = true;
            tocandoParedDer = true;
        }

        if (other.transform.CompareTag("ParedIzq"))
        {
            tocandoPared = true;
            tocandoParedIzq = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        tocandoPared = false;
        tocandoParedDer = false;
        tocandoParedIzq = false;
    }
}
