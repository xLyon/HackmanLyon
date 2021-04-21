using System;
using System.IO;
using System.Net.Mime;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;


public class SerializationExample : MonoBehaviour
{
    //public TextAsset EnemmyFile;
    public Enemmy Enemmy;
    public Text EnemmyText;
    public void OnEnable()
    {
        //Enemmy = new Enemmy() {Name = "Nat", ID = Guid.NewGuid(), HP = 9000};
        //var serializedEnemmy = JsonConvert.SerializeObject(Enemmy);
        //File.WriteAllText($"{Application.dataPath}/EnemmyFile.json", serializedEnemmy);
        //Debug.Log(serializedEnemmy);
        var EnemmyData = File.ReadAllText($"{Application.dataPath}/StreamingAssets/Data/{typeof(Enemmy)}s/EnemmyFile.json");
        Enemmy = JsonConvert.DeserializeObject<Enemmy>(EnemmyData);
        EnemmyText.text = $"{Enemmy.Name}: {Enemmy.HP}HP";
    }

    public void OnDisable()
    {
        var serializedEnemmy = JsonConvert.SerializeObject(Enemmy);
        File.WriteAllText($"{Application.dataPath}/StreamingAssets/Data/{typeof(Enemmy)}s/EnemmyFile.json", serializedEnemmy);
        Debug.Log(serializedEnemmy);
    }
}


[Serializable]
public class Enemmy
{
    public string Name;
    public Guid ID;
    public int HP;
}
