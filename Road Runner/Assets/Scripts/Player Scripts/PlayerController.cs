using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private Animator anim;

    private string jump_Animation = "PlayerJump", change_Line_Animation = "ChangeLine";

    public GameObject player, shadow;

    public Vector3 first_PosOfPlayer, second_PosOfPlayer;

    [HideInInspector]
    public bool player_Died;

    [HideInInspector]
    public bool player_Jumped;

    void Awake()
    {
        MakeInstance();

        anim = player.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleChangeLine();
        HandleJump();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    void HandleChangeLine()
    {
        if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            anim.Play(change_Line_Animation);
            transform.localPosition = second_PosOfPlayer;

            // TODO: PLAY SOUND
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            anim.Play(change_Line_Animation);
            transform.localPosition = first_PosOfPlayer;

            // TODO: PLAY SOUND
        }
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!player_Jumped) // to avoid double jump
            {
                anim.Play(jump_Animation);
                player_Jumped = true;
            }

            // TODO: PLAY SOUND
        }
    }

} // class
