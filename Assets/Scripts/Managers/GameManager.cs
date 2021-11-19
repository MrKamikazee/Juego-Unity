using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public MoverPersonaje player;

    private void Awake()
    {
        instance = this;
    }
}
