﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SoundManager.instance.PlayButtonSfx();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }    
}