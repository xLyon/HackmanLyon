using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericsExample : MonoBehaviour
{

    //Generics

    public void OnEnable()
    {
        //var pairIntInt = new PairIntInt() {First = 5, Second = 10};
        var marriage1 = new Pair<string,string>() {First = "HanMeiMei", Second = "ZhangQiang"};
        var number = 5;
        PrintTheThing(number);
        PrintTheThings(new List<int>(){1,2,3,4,5,6,7,8,9});
    }

    //GenericMethod
    public void PrintTheThing<T>(T thing)
    {
        Debug.Log(thing);
    }

    public void PrintTheThings<T>(List<T> things)
    {
        for (int i = 0; i < things.Count; i++)
        {
            Debug.Log(things[i]);
        }
    }

    public T Produce<T>() where T : new()
    {
        T returnValue = new T();
        return returnValue;
    }

}

//This is not DRY, our program is EXPLODING in complexity, and will become difficult to maintain over time
//Generics to the rescue!
public class PairIntInt
{
    public int First;
    public int Second;
}

public class PairStringString
{
    public string First;
    public string Second;
}



//Generic Classes
public class Pair<T, U>
{
    public T First;
    public U Second;
}


