using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public GameObject menuPausa, player, menuOpciones, canvasMenuPrincipal;
    public RespawnPersonaje datosPlayer;
    private bool permitirEscape = true;

    // Boton de jugar en el menu principal
    public void BotonJugar()
    {
        SceneManager.LoadScene("Nivel 1");
    }

    public void Opciones()
    {
        canvasMenuPrincipal.SetActive(false);
        menuOpciones.SetActive(true);
    }

    // Botones en el menu de pausa
    // Boton de pausa
    public void MenuPausa()
    {
        Time.timeScale = 0;
        menuPausa.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && permitirEscape)
        {
            Time.timeScale = 0;
            menuPausa.SetActive(true);
        }
    }
    
    // Boton de renaudar
    public void Renaudar()
    {
        Time.timeScale = 1;
        menuPausa.SetActive(false);
        menuOpciones.SetActive(false);
    }
    
    // Boton de guardar
    public void Guardar()
    {
        datosPlayer.GuardarDatos();
    }
    
    // Boton para reiniciar nivel
    public void ReniciarNivel()
    {
        PlayerPrefs.DeleteKey("checkPointPositionX");
        PlayerPrefs.DeleteKey("checkPointPositionY");
        Time.timeScale = 1;
        menuPausa.SetActive(false);
        player.transform.position = new Vector2(0, 0);
        datosPlayer.life = 5;
        datosPlayer.ControladorVida();
    }

    // Boton para ir al menu principal
    public void IrMenuPrincipal()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    
    // Boton para salir del juego
    public void SalirJuego()
    {
        Application.Quit();
        Time.timeScale = 1;
    }
    
    // Botones generales
    // Boton de cargar
    public void Cargar()
    {
        datosPlayer.CargarDatos();
    }
}
