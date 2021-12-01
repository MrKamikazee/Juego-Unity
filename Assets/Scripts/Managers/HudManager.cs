using UnityEngine;
using UnityEngine.SceneManagement;

public class HudManager : MonoBehaviour
{
    public GameObject menuPausa, player, menuOpciones, menuInicio, creditos;
    private bool permitirEscape = true;

    // Boton de jugar en el menu principal
    public void BotonJugar()
    {
        PlayerPrefs.DeleteKey("checkPointPositionX");
        PlayerPrefs.DeleteKey("checkPointPositionY");
        PlayerPrefs.DeleteKey("posX");
        PlayerPrefs.DeleteKey("posY");
        PlayerPrefs.DeleteKey("vidas");
        SceneManager.LoadScene("Tutorial");
    }

    public void BotonCreditos()
    {
        menuInicio.SetActive(false);
        creditos.SetActive(true);
    }

    public void VolverCreditos()
    {
        creditos.SetActive(false);
        menuInicio.SetActive(true);
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
        if (Input.GetKey(KeyCode.Escape) && permitirEscape || Input.GetButtonDown("Fire1"))
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

    // Boton para reiniciar nivel
    public void ReniciarNivel()
    {
        Time.timeScale = 1;
        menuPausa.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        PlayerPrefs.DeleteAll();
        Application.Quit();
        Time.timeScale = 1;
    }
    
    // Botones generales
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
