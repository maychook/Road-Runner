using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject hero_Menu;
    public Text starScoreText;

    public Image musig_Img;
    public Sprite music_Off, music_On;

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void HeroMenu()
    {
        hero_Menu.SetActive(true);
        // display the star score
    }

    public void HomeButton()
    {
        hero_Menu.SetActive(false);
    }
}
