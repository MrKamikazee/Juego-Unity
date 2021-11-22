using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HudManager : MonoBehaviour
{
    public GameObject menuPausa, player, menuOpciones, menuInicio;
    public RespawnPersonaje datosPlayer;
    private bool permitirEscape = true;

    // Boton de jugar en el menu principal
    public void BotonJugar()
    {
        PlayerPrefs.DeleteKey("checkPointPositionX");
        PlayerPrefs.DeleteKey("checkPointPositionY");
        PlayerPrefs.DeleteKey("posX");
        PlayerPrefs.DeleteKey("posY");
        PlayerPrefs.DeleteKey("vidas");
        SceneManager.LoadScene("Nivel 1");
    }

    // Botones en el menu de pausa
    // Boton de pausa
    public void MenuPausa()
    {
        Time.timeScale = 0;
        menuPausa.SetActive(true);
    }
    
    // Boton para quitar el menu de pausa
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
        PlayerPrefs.DeleteKey("posX");
        PlayerPrefs.DeleteKey("posY");
        PlayerPrefs.DeleteKey("vidas");
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
    
    // Boton para abrir las opciones
    public void Opciones()
    {
        menuInicio.SetActive(false);
        menuOpciones.SetActive(true);
    }
    
    // Boton para cerrar las opciones
    public void VolverOpciones()
    {
        menuOpciones.SetActive(false);
        menuInicio.SetActive(true);
    }
}
