using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("highscore",0);
        PlayerPrefs.SetInt("prescore",0);
    }
}
