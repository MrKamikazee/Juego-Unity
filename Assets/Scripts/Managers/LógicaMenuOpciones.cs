using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LógicaMenuOpciones : MonoBehaviour
{
    [Header("Lógica Volumen")]
    public Slider slider;
    public float sliderValue;
    public Image imageMute;

    [Header("Lógica Pantalla Completa")] 
    public Toggle toggle;
    
    [Header("Lógica Resoluciones")]
    public TMP_Dropdown resolucionesDropDown;
    public Resolution[] resoluciones;

    private void Start()
    {
        LogicaVolumen();
        LogicaPantallaCompleta();
        RevisarResolutions();
    }
    
    // Toda la lógica del volumen
    public void LogicaVolumen()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        //MuteCheck();
    }

    public void MuteCheck()
    {
        if (sliderValue == 0)
        {
            imageMute.enabled = true;
        }
        else
        {
            imageMute.enabled = false;
        }
    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        MuteCheck();
    }

    // Toda la lógica de la pantalla completa
    public void LogicaPantallaCompleta()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
    }

    public void PantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }
    
    // Toda la lógica del cambio de resoluciones
    public void RevisarResolutions()
    {
        resoluciones = Screen.resolutions;
        resolucionesDropDown.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionActual = 0;
        
        for (int i = 0; i < resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            opciones.Add(opcion);
            
            if (Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height)
            {
                resolucionActual = i;
            }
        }
        resolucionesDropDown.AddOptions(opciones);
        resolucionesDropDown.value = PlayerPrefs.GetInt("numeroResolucion", 0);
        resolucionesDropDown.RefreshShownValue();
    }

    public void CambiarResolucion(int indiceResolucion)
    {
        PlayerPrefs.SetInt("numeroResolucion", resolucionesDropDown.value);
        Resolution resolucion = resoluciones[indiceResolucion];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }
}
