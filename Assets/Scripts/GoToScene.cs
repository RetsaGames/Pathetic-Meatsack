﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    [SerializeField] string scene;

    public void goToScene()
    {
        SceneManager.LoadScene(scene);
    }
}
