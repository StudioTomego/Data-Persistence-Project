using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class MenuUIHandler : MonoBehaviour
{

    public void ToGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ToTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        
        if(Data.data.m_Points > Data.data.savedHighScore)
        {
            Data.data.SaveHighScore();
        }

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }
}
