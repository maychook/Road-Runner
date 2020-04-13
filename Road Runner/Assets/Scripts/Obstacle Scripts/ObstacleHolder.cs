using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHolder : MonoBehaviour
{
    public GameObject[] childs;

    public float limitAxisX;

    public Vector3
        firstPos,
        secondPos;

    // Awake function is called first when the game starts
    private void Awake()
    {
        
    }

    // Start function is called third when the game starts - after OnEnable()
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(
            -GameplayController.instance.moveSpeed * Time.deltaTime, 0f, 0f);

        if (transform.localPosition.x <= limitAxisX)
        {
            // Inform gameplay controller that the obstacle is not active
            gameObject.SetActive(false);
        }
    }

    // OnEnable functoin is called second when the game starts - after Awake()
    // called also every time when a game object is anable or disable
    void OnEnable()
    {
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].SetActive(true);
        }

        // 50-50 chance
        if (Random.value <= 0.5f)
        {
            transform.localPosition = firstPos;
        }
        else
        {
            transform.localPosition = secondPos;
        }

    }
}
