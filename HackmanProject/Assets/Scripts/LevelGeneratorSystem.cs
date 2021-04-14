using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneratorSystem : MonoBehaviour
{
    //LevelGenerator:To make a level
    public BaseGridObject[] BaseGridObjectsPrefab;

    public static int[,] Grid = new int[,]
    {
            {1,1,1,1,1,1,1,1,1,1},
            {1,0,1,0,0,0,0,3,0,1},
            {1,0,2,0,1,1,1,1,1,1},
            {1,0,1,0,0,0,0,0,0,1},
            {1,0,1,0,1,1,1,1,1,1},
            {1,0,0,0,0,0,0,3,0,1},
            {1,1,1,1,1,1,1,1,1,1},
    };

    private void Awake()
    {
        for (int y = 0; y < Grid.GetLength(0) ; y++)
        {
            for (int x = 0; x < Grid.GetLength(1); x++)
            {
                var objectType = Grid[y, x];
                var gridObjectPrefab = BaseGridObjectsPrefab[objectType];
                var gridObjectClone = Instantiate(gridObjectPrefab);
                gridObjectClone.GridPositon = new IntVector2(x, -y);
                gridObjectClone.transform.position = new Vector3(gridObjectClone.GridPositon.x, gridObjectClone.GridPositon.y, 0);
            }
        }
    }


}
