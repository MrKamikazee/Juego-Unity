using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPersonaje : MonoBehaviour
{
    public Rigidbody2D rb;
    [Header("Move Mechanics")] public Transform personajeTransform;
    public float speedPersonaje;
    public float dashCooldown;
    //public GameObject particulasDash; PARTICULAS DEL DASH
    public float dashForce=30;
    public SpriteRenderer SpriteRenderer;
    [Header("Jump Mechanics")] [Range(1, 20)]
    public float strenghJump;
    public float fallMultipler = 2.5f;
    public float lowJumpMultipler = 2;
    public bool isGrounded = true;
    public float doubleJumpSpeed = 2.5f;
    public bool canDoubleJump; 
    bool tocandoPared=false;
    bool deslizarPared;
    public float velocidadDeslizarPared = 0.80f;
    bool tocandoParedIzq;
    bool tocandoParedDer;

    private void Update()
    {
        dashCooldown -= Time.deltaTime;
        //Mueve el personaje de izquierda a derecha
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            personajeTransform.Translate((Vector2.right * Time.deltaTime * speedPersonaje));
                SpriteRenderer.flipX = false;
        }
        else if (Input.GetKey("c")&& dashCooldown<=2)
        {
            Dash();
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            personajeTransform.Translate((Vector2.left * Time.deltaTime * speedPersonaje));
            SpriteRenderer.flipX = true;
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
            transform.parent = other.transform; //Arreglar linea de codigo
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
