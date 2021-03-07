using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    [SerializeField] GameObject MainMenuPanel; 
    [SerializeField] GameObject HowToPanel; 
    
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GotoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void HowToPlay()
    {
        MainMenuPanel.SetActive(false);
        HowToPanel.SetActive(true);
    }

    public void BackToMain()
    {
        MainMenuPanel.SetActive(true);
        HowToPanel.SetActive(false);
    }
}
