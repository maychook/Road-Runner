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
        current_Index = GameManager.instance.selected_Index;

        for (int i = 0; i < available_Heroes.Length; i++)
        {
            available_Heroes[i].SetActive(false);
        }
        // activate the current selected hero
        available_Heroes[current_Index].SetActive(true);

        heroes = GameManager.instance.heroes;
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

        CheckIfCharacterIsUnlocked();
    }

    public void PreviousHero()
    {
        available_Heroes[current_Index].SetActive(false);

        if (current_Index - 1 == -1)
        {
            current_Index = available_Heroes.Length - 1;
        }
        else
        {
            current_Index--;
        }

        available_Heroes[current_Index].SetActive(true);

        CheckIfCharacterIsUnlocked();
    }
    
    void CheckIfCharacterIsUnlocked()
    {
        if (heroes[current_Index])
        {
            // the hero is not locked
            starIcon.SetActive(false);

            if (current_Index == GameManager.instance.selected_Index)
            {
                selectBtn_Image.sprite = button_Green;
                selectedText.text = "Selected";
            }
            else
            {
                selectBtn_Image.sprite = button_Blue;
                selectedText.text = "Select?";
            }
        }
        else
        {
            // the hero is locked

            selectBtn_Image.sprite = button_Blue;
            starIcon.SetActive(true);
            selectedText.text = "1000";
        }
    }

    public void SelectHero()
    {
        if (!heroes[current_Index])
        {
            // IF THE HERO IS LOCKED
            if (current_Index != GameManager.instance.selected_Index)
            {
                // UNLOCK HERO IF THE PLAYER HAS ENOUGH COINS
                if (GameManager.instance.star_Score >= 1000)
                {
                    GameManager.instance.star_Score -= 1000;

                    selectBtn_Image.sprite = button_Green;
                    selectedText.text = "Selected";
                    heroes[current_Index] = true;
                    starIcon.SetActive(false);

                    starScoreText.text = GameManager.instance.star_Score.ToString();

                    GameManager.instance.selected_Index = current_Index;
                    GameManager.instance.heroes = heroes;
                    // saving the game data
                    GameManager.instance.SaveGameData();
                }
                else
                {
                    print("NOT ENOUGH STAR POINTS TO UNLOCK THE PLAYER");
                }
            }
        }
        else
        {
            selectBtn_Image.sprite = button_Green;
            selectedText.text = "Selected";

            GameManager.instance.selected_Index = current_Index;
            GameManager.instance.SaveGameData();
        }
    }

} // class
