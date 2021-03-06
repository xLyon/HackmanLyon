using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UnityEngine;

public class LevelGeneratorSystem : MonoBehaviour
{
    //LevelGenerator:To make a level
    public BaseGridObject[] BaseGridObjectsPrefab;

    public List<string> LevelFileNames = new List<string>();
    [SerializeField]
    private string level;

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
        level = LevelFileNames[Random.Range(0, LevelFileNames.Count - 1)];
        Grid = AppDataSt.Load<Level>(level).Grid;

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

    public class Level
    {
        public int[,] Grid;
    }


}
