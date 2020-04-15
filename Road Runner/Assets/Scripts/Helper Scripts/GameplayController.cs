using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    // the script will move the camera

    public static GameplayController instance;

    public float moveSpeed, distance_Factor = 1f;

    private float distance_Move;
    private bool gameJustStarted; // the default is false

    public GameObject obstacle_Obj;
    public GameObject[] obstacle_List;

    [HideInInspector]
    public bool obstacle_Is_Active;

    private string Coroutine_Name = "SpawnObstacles";


    void Awake()
    {
        MakeInstance();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameJustStarted = true;

        GetObstacles();
        StartCoroutine(Coroutine_Name);
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance!= null)
        {
            Destroy(gameObject);
        }
    }

    void MoveCamera()
    {
        if (gameJustStarted)
        {
            // check if player is alive
            if (!PlayerController.instance.player_Died)
            {
                if (moveSpeed < 12.0f)
                {
                    moveSpeed += Time.deltaTime * 5.0f;
                }
                else
                {
                    // set the initial speed of the camera 
                    moveSpeed = 12f;
                    gameJustStarted = false;
                }
            }
        }

        // check if player is alive
        if (!PlayerController.instance.player_Died)
        {
            Camera.main.transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
            UpdateDistance();
        }        
    }

    // use it to calculate score
    void UpdateDistance()
    {
        distance_Move += Time.deltaTime * distance_Factor;
        float round = Mathf.Round(distance_Move); // the value will be rounded up to the nearest integer

        // TODO: COUNT AND SHOW THE SCORE

        if (round >= 30.0f && round < 60.0f)
        {
            moveSpeed = 14f;
        }
        else if(round >= 60f)
        {
            moveSpeed = 16f;
        }
    }

    void GetObstacles()
    {
        obstacle_List = new GameObject[obstacle_Obj.transform.childCount];

        for (int i = 0; i < obstacle_List.Length; i++)
        {
            // it will get the game objects that has the obstacleHolder even if the object is enable
            obstacle_List[i] = obstacle_Obj.GetComponentsInChildren<ObstacleHolder>(true)[i].gameObject;
        }
    }

    IEnumerator SpawnObstacles()
    {
        while(true)
        {
            if (!PlayerController.instance.player_Died)
            {
                if (!obstacle_Is_Active)
                {
                    if (Random.value <= 0.85f) // 85% chance to create an obstacle
                    {
                        int randomIndex = 0;

                        do
                        {
                            randomIndex = Random.Range(0, obstacle_List.Length);
                        }
                        while (obstacle_List[randomIndex].activeInHierarchy);

                        obstacle_List[randomIndex].SetActive(true);
                        obstacle_Is_Active = true;
                    }
                }
            }

            // the game will not crush beacause the loop will be called every 0.6 seconds
            yield return new WaitForSeconds(0.6f); 
        }
    }

    
}
