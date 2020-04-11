using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreen : MonoBehaviour
{
    private SpriteRenderer sprite_Renderer;

    void Awake()
    {
        sprite_Renderer = GetComponent<SpriteRenderer>();   
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // will return the 6 planes of the camera view - it will alow as to know if an object is in the camera view
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);


        /* THE CAMERA VIEW : THE PLANES
         *  _______________
         * |       |       |
         * |   1   |   2   |
         * |_______|_______|
         * |       |       |
         * |   3   |   4   |
         * |_______|_______|
         * |       |       |
         * |   5   |   6   |
         * |_______|_______|
         */
         
        // will test if the sprite is rendered in the planes
        if (!GeometryUtility.TestPlanesAABB(planes, sprite_Renderer.bounds)) 
        {
            if (transform.position.x - Camera.main.transform.position.x < 0.0f)
            { 
                // the tile is out of bounds
                CheckTile();
            }
        }
    }

    void CheckTile()
    {
        // ROAD
        if (this.tag == MyTags.ROAD)
        {
            Change(ref MapGenerator.instance.last_Pos_Of_Road_Tile, new Vector3(1.5f, 0f, 0f), 
                ref MapGenerator.instance.last_Order_Of_Road);
        }
        // TOP_NEAR_GRASS
        else if (this.tag == MyTags.TOP_NEAR_GRASS)
        {
            Change(ref MapGenerator.instance.last_Pos_Of_Top_Near_Grass, new Vector3(1.2f, 0f, 0f),
                ref MapGenerator.instance.last_Order_Of_Top_Near_Grass);
        }
        // TOP_FAR_GRASS
        else if (this.tag == MyTags.TOP_FAR_GRASS)
        {
            Change(ref MapGenerator.instance.last_Pos_Of_Top_Far_Grass, new Vector3(4.8f, 0f, 0f),
                ref MapGenerator.instance.last_Order_Of_Top_Far_Grass);
        }
        // BOTTOM_NEAR_GRASS
        else if (this.tag == MyTags.BOTTOM_NEAR_GRASS)
        {
            Change(ref MapGenerator.instance.last_Pos_Of_Bottom_Near_Grass, new Vector3(1.2f, 0f, 0f),
                ref MapGenerator.instance.last_Order_Of_Bottom_Near_Grass);
        }
        // BOTTOM_FAR_LAND_1
        else if (this.tag == MyTags.BOTTOM_FAR_LAND_1)
        {
            Change(ref MapGenerator.instance.last_Pos_Of_Bottom_Far_Land_F1, new Vector3(1.6f, 0f, 0f),
                ref MapGenerator.instance.last_Order_Of_Bottom_Far_Land_F1);
        }
        // BOTTOM_FAR_LAND_2
        else if (this.tag == MyTags.BOTTOM_FAR_LAND_2)
        {
            Change(ref MapGenerator.instance.last_Pos_Of_Bottom_Far_Land_F2, new Vector3(1.6f, 0f, 0f),
                ref MapGenerator.instance.last_Order_Of_Bottom_Far_Land_F2);
        }
        // BOTTOM_FAR_LAND_3
        else if (this.tag == MyTags.BOTTOM_FAR_LAND_3)
        {
            Change(ref MapGenerator.instance.last_Pos_Of_Bottom_Far_Land_F3, new Vector3(1.6f, 0f, 0f),
                ref MapGenerator.instance.last_Order_Of_Bottom_Far_Land_F3);
        }
        // BOTTOM_FAR_LAND_4
        else if (this.tag == MyTags.BOTTOM_FAR_LAND_4)
        {
            Change(ref MapGenerator.instance.last_Pos_Of_Bottom_Far_Land_F4, new Vector3(1.6f, 0f, 0f),
                ref MapGenerator.instance.last_Order_Of_Bottom_Far_Land_F4);
        }
        // BOTTOM_FAR_LAND_5
        else if (this.tag == MyTags.BOTTOM_FAR_LAND_5)
        {
            Change(ref MapGenerator.instance.last_Pos_Of_Bottom_Far_Land_F5, new Vector3(1.6f, 0f, 0f),
                ref MapGenerator.instance.last_Order_Of_Bottom_Far_Land_F5);
        }
    }

    void Change(ref Vector3 pos, Vector3 offset, ref int orderLayer)
    {
        transform.position = pos;
        pos += offset;

        sprite_Renderer.sortingOrder = orderLayer;
        orderLayer++; // increase for next move
    }
}
