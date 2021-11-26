using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnPersonaje : MonoBehaviour
{
    private float checkPointPositionX, checkPointPositionY, posX, posY;
    public GameObject[] vida, checkpoint;
    public int life;
    private bool continuarLVL = true;
    public Transform posInicial;

    private void Start()
    {
        transform.position = new Vector2(posInicial.position.x, posInicial.position.y);
        life = vida.Length;
        if (continuarLVL)
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("posX"), PlayerPrefs.GetFloat("posY"));
            life = PlayerPrefs.GetInt("vidas");
            ControladorVida();
            continuarLVL = false;
        }
        if (PlayerPrefs.GetFloat("checkPointPositionX") != 0)
        {
            TPCheckPoint();
        }
    }

    public void TPCheckPoint()
    {
        transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"),
            PlayerPrefs.GetFloat("checkPointPositionY")));
    }
    
    public void GuardarDatos()
    {
        PlayerPrefs.SetFloat("posX", transform.position.x);
        PlayerPrefs.SetFloat("posY", transform.position.y);
        PlayerPrefs.DeleteKey("checkPointPositionX");
        PlayerPrefs.DeleteKey("checkPointPositionY");
        PlayerPrefs.SetString("sceneName", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("vidas", life);
    }

    public void CargarDatos()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("sceneName"));
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

    public void ControladorVida()
    {
        
        if(life < 1)
        {
            ReiniciarNivel();
            ControladorVida();
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                if (life <= i)
                {
                    vida[i - 1].gameObject.SetActive(false);
                }
            }
        } 
        if (life == 5)
        {
            for (int i = 0; i < 4; i++)
            {
                vida[i].gameObject.SetActive(true);
            }
        }
    }

    public void ReiniciarNivel()
    {
        life = 5;
        for (int i = 0; i < checkpoint.Length; i += 2)
        {
            checkpoint[i].gameObject.SetActive(true);
            checkpoint[i + 1].gameObject.SetActive(false);
        }
        ResetearCheckpoint();
        transform.position = new Vector2(posInicial.position.x, posInicial.position.y);
    }
    
    private void ResetearCheckpoint()
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
                ResetearCheckpoint();
            }
        }
        else
        {
            life--;
            ControladorVida();
            transform.position = new Vector2(posInicial.position.x, posInicial.position.y);
        }
    }
}
