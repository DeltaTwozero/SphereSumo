using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    [SerializeField] GameObject MainMenuPanel; 
    [SerializeField] GameObject HowToPanel; 
    
    public void PlayGame()
    {
            
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
