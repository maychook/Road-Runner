using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject hero_Menu;
    public Text starScoreText;

    public Image music_Img;
    public Sprite music_Off, music_On;

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void HeroMenu()
    {
        hero_Menu.SetActive(true);
        if (GameManager.instance.star_Score > 99999)
        {
            starScoreText.text = "99999";
        }
        else
        {
            starScoreText.text = "" + GameManager.instance.star_Score;
        }
    }

    public void HomeButton()
    {
        hero_Menu.SetActive(false);
    }

    public void MusicButton()
    {
        if (GameManager.instance.play_Sound)
        {
            music_Img.sprite = music_Off;
            GameManager.instance.play_Sound = false;
        }
        else
        {
            music_Img.sprite = music_On;
            GameManager.instance.play_Sound = true;
        }
    }
}
