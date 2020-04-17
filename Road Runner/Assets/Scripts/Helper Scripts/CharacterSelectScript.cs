using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectScript : MonoBehaviour
{
    public GameObject[] available_Heroes;

    private int current_Index;

    public Text selectedText;
    public GameObject starIcon;
    public Image selectBtn_Image;
    public Sprite button_Green, button_Blue;

    private bool[] heroes;

    public Text starScoreText;


    // Start is called before the first frame update
    void Start()
    {
        InitializeCharacters();
    }

    void InitializeCharacters()
    {
        current_Index = 0;

        for (int i = 0; i < available_Heroes.Length; i++)
        {
            available_Heroes[i].SetActive(false);
        }
        // activate the current selected hero
        available_Heroes[current_Index].SetActive(true); 

        // heroes = gameManager
    }

    public void NextHero()
    {
        available_Heroes[current_Index].SetActive(false);

        if (current_Index + 1 == available_Heroes.Length)
        {
            current_Index = 0;
        }
        else
        {
            current_Index++;
        }
        // only if clicked?
        available_Heroes[current_Index].SetActive(true);
    }

    public void PreviousHero()
    {
        available_Heroes[current_Index].SetActive(false);

        if (current_Index - 1 == -1)
        {
            current_Index = available_Heroes.Length - 1;
        }
        else;
        {
            current_Index--;
        }

        available_Heroes[current_Index].SetActive(true);
    }

} // class
