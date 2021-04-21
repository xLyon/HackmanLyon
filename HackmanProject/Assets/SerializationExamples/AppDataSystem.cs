using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System;
using UnityEngine;

public class TestApp : MonoBehaviour
{
    //public Enemy enemyOne;

    public void OnEnable()
    {
        var enemyOne = AppDataSystem.instance.Load<Enemy>("Lyon");
        AppDataSystem.instance.Save(enemyOne, "Lyon");
    }
}

public class AppDataSystem
{
    private static AppDataSystem appDataSystem;
    public static AppDataSystem instance => appDataSystem ?? (appDataSystem = new AppDataSystem());

    // Save method, for saving an object to a file -- of any type -- with a name provided by the person saving
    public void Save<T>(T gameObj, string userName)
    {
        var filePath = $"{Application.dataPath}/StreamingAssets/Data/{typeof(T)}s/{userName}.json";
        var serializedObject = JsonConvert.SerializeObject(gameObj);

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, serializedObject);
        }
        else
        {
            Debug.LogError("File Already Exist");
        }
    }

    // Load method, for Loading and returning objects of any type, given a filename
    public T Load<T>(string userName)
    {
        var filePath = $"{Application.dataPath}/StreamingAssets/Data/{typeof(T)}s/{userName}.json";

        if (!File.Exists(filePath))
        {
            Debug.LogError("File Doesn't Exist");
            return default(T);
        }

        var fileData = File.ReadAllText(filePath);
        T appObject = JsonConvert.DeserializeObject<T>(fileData);
        return appObject;
    }

    // The system should check if directories/files you're saving/Loading to already exist, and if not, create them
    // The system should be robust enough to not explode if a wrong file name or type is given to it

    // This should give me an Enemy object 
    // var enemy = AppDataSystem.Load<Enemy>("Enemy1");
    // AppDataSystem.Save(enemy, "Enemy1");
}
