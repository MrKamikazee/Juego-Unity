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
    public float strenghJump;
    [Range(1, 20)]
    public float fallMultipler = 2.5f, lowJumpMultipler = 2, doubleJumpSpeed = 2.5f;
    public bool isGrounded = true, canDoubleJump = true;
    
    [Header("Escalar paredes Mechanics")]
    bool tocandoPared;
    public float velocidadDeslizarPared = 0.80f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Movimiento personaje
        velX = Input.GetAxisRaw("Horizontal");
        velY = rb.velocity.y;
        rb.velocity = new Vector2(velX * speed, rb.velocity.y);
    }

    void Update()
    {
        dashCooldown -= Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && dashCooldown <= 0)
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
            if (canDoubleJump && !isGrounded)
            {
                //rb.velocity = Vector2.up * doubleJumpSpeed;
                canDoubleJump = false;
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

        if (tocandoPared)
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
            canDoubleJump = true;
            tocandoPared = true;
        }

        if (other.CompareTag("PlataformaMovil"))
        {
            transform.parent = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Floor") || other.CompareTag("PlataformaMovil"))
        {
            isGrounded = false;
            tocandoPared = false;
        }

        if (other.CompareTag("PlataformaMovil"))
        {
            transform.parent = null;
        }
    }

    public void Dash()
    {
        //GameObject dashObject;
        //dashObject = Instantiate();
        if (SpriteRenderer.flipX)
        {
            rb.velocity = Vector2.left * dashForce;
        }
        else
        {
            rb.velocity = Vector2.right * dashForce;
        }
        dashCooldown = 2;
       // Destroy(dashObject,1);
    }
}
