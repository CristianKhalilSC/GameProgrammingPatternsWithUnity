using UnityEngine;
using System.Collections.Generic;
using System;

public class TerrainGenerator : MonoBehaviour
{

    int[,] terrain = new int[20, 20]{
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,1,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0},
        {0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
    };
    private Sprite reusableGrassSprite;
    private Sprite reusableWaterSprite;
    private List<GameObject> terrainGameObjects;

    public bool useFlyweight = false;

    void Awake()
    {
        terrainGameObjects = new List<GameObject>();
    }

    // Use this for initialization
    void Start()
    {
        reusableGrassSprite = GenerateTexture(Color.green);
        reusableWaterSprite = GenerateTexture(Color.blue);

        GenerateTerrain();
    }

    private Sprite GenerateTexture(Color color)
    {
        Texture2D tex = new Texture2D(100, 100);
        for (int i = 0; i < tex.width; i++)
        {
            for (int j = 0; j < tex.height; j++)
            {
                tex.SetPixel(i, j, color);
            }
        }
        tex.Apply();
        return Sprite.Create(tex, new Rect(0, 0, 1, 1), Vector2.zero, 1);
    }

    private GameObject GenerateNewSprite(int type, int posX, int posY)
    {
        GameObject go = new GameObject();
        go.transform.position = new Vector3(posX, posY, 0);
        SpriteRenderer spriteRenderer = go.AddComponent<SpriteRenderer>();

        if (useFlyweight)
        {
            spriteRenderer.sprite = type == 0 ? reusableGrassSprite : reusableWaterSprite;
        }
        else
        {
            spriteRenderer.sprite = type == 0 ? GenerateTexture(Color.green) : GenerateTexture(Color.blue);
        }

        return go;
    }

    public void GenerateTerrain()
    {
        for (int i = 0; i < terrainGameObjects.Count; i++)
        {
            Destroy(terrainGameObjects[i]);
        }

        GC.Collect();

        for (int i = 0; i < terrain.GetLength(0); i++)
        {
            for (int j = 0; j < terrain.GetLength(1); j++)
            {
                GameObject go = GenerateNewSprite(terrain[i, j], i, j);
                terrainGameObjects.Add(go);
            }
        }
    }

}
