using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnPersonaje : MonoBehaviour
{
    private float checkPointPositionX, checkPointPositionY, posX, posY;
    public GameObject[] vida;
    public int life;
    public Transform posInicial;

    private void Start()
    {
        ReiniciarCheckpoint();
        transform.position = new Vector2(posInicial.position.x, posInicial.position.y);
        life = vida.Length + 1;
        ControladorVida();
    }

    public void ControladorVida()
    {
        
        if(life < 1)
        {
            ReiniciarCheckpoint();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            for (int i = 0; i < (vida.Length + 1); i++)
            {
                if (life <= i)
                {
                    vida[i - 1].gameObject.SetActive(false);
                }
            }
        } 
        if (life == (vida.Length + 1))
        {
            for (int i = 0; i < vida.Length; i++)
            {
                vida[i].gameObject.SetActive(true);
            }
        }
    }

    public void ReiniciarCheckpoint()
    {
        PlayerPrefs.DeleteKey("checkPointPositionX");
        PlayerPrefs.DeleteKey("checkPointPositionY");
    }

    public void FinCaida()
    {
        if (PlayerPrefs.GetFloat("checkPointPositionX") != 0)
        {
            life--;
            if (life != 0)
            {
                ControladorVida();
                TPCheckPoint();
            }
            else
            {
                ControladorVida();
            }
        }
        else
        {
            life--;
            ControladorVida();
            transform.position = new Vector2(posInicial.position.x, posInicial.position.y);
        }
    }
    
    public void TPCheckPoint()
    {
        if (PlayerPrefs.GetFloat("checkPointPositionX") != 0)
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"),
                PlayerPrefs.GetFloat("checkPointPositionY"));
        }
        else
        {
            transform.position = new Vector2(posInicial.position.x, posInicial.position.y);
        }
        
    }

    public void ReachedCheckPonit(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPositionX", x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }
    
    public void PlayerDamaged()
    {
        life--;
        ControladorVida();
    }
}
