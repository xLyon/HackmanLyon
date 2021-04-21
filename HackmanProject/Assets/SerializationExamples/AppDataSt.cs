using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System;
using UnityEngine;

public class AppDataSt
{
    public static T Save<T>(T appData, string fileName)
    {
        // Get path and folder based on the type, automatically
        // For example, if we save an Enemy type object, it will be in a folder called "Enemys"
        var path = $"{Application.dataPath}/StreamingAssets/Data/{typeof(T)}/";

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        if (!File.Exists($"{path}{fileName}"))
        {
            var fileStream = File.Create($"{path}{fileName}.json");
            fileStream.Close();
        }

        File.WriteAllText($"{path}/{fileName}.json", JsonConvert.SerializeObject(appData));
        return appData;
    }

    public static T Load<T>(string fileName) where T : new()
    {
        var path = $"{Application.dataPath}/StreamingAssets/Data/{typeof(T)}/";

        if (File.Exists($"{path}{fileName}.json"))
        {
            var appData = JsonConvert.DeserializeObject<T>(File.ReadAllText($"{path}{fileName}.json"));
            return appData;
        }

        return Save(new T(), fileName);
    }
}
