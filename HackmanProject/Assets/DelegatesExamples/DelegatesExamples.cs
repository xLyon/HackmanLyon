using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DelegatesExamples : MonoBehaviour
{
    //Delegates are converted to classes by the compiler
    //And since they're classes... we can create NEW objects
    private delegate void MeDelegate();
    private delegate int Dele1();
    private delegate void Dele2(int num);

    private delegate bool MeDelegateInt(int i);

    private delegate bool MeDelegateTakeIntReturnBool(int number);

    private delegate int MeDelegateReturnInt();

    private event Action myAction;

    //Generic delegate
    private delegate T MeDelegateGeneric<T>();

    public static TrainSignal TrainSignal;
    public void OnEnable()
    {
        #region Delegates
        ////We're not invoking Foo here, we're just passing it...
        ////MeDelegate meDelegate = Foo;
        //MeDelegate meDelegate = new MeDelegate(Foo);
        //Dele1 dele1 = new Dele1(FooReturnInt);
        ////This is a reference to a class, but it's also treated like a METHOD
        //meDelegate.Invoke();

        //MeDelegate meDelegate2 = Goo;
        //Dele2 dele2 = FooTakeInt;
        ////If we write this, the compiler will replace this with an INVOKE call
        ////This is shorthand/syntactic sugar
        //meDelegate2();
        //dele1();
        //dele2(1);

        ////When this is compiled, we'll get a new MeDelegate, and it's invoke method will be called
        ////With delegates, we are able to treat methods like first class objects,表示可以把方法当成一个类来使用，所以可以将参数设为一个方法

        //InvokeTheDelegate(Foo);

        ////Delegates are references to objects AND methods
        //Debug.Log($"Target:{meDelegate.Target},Method:{meDelegate.Method}");
        ////因为Goo是static方法，所以它没有target，而Foo是静态方法，所以它
        //Debug.Log($"Target:{meDelegate2.Target},Method:{meDelegate2.Method}");

        //MeDelegateTakeIntReturnBool medel = FooTakeIntReturnBool;
        //medel(5);


        ////The same reason we parameterize this, is why we parameterize code, or references to code (methods/functions)
        //var result = GetAllTheNumberLessThanFive(new List<int>() {1, 25, 4, 765, 4});

        //foreach (var number in result)
        //{
        //    Debug.Log(number);
        //}

        //var numbers = new List<int>() {1, 25, 3, 6, 2, 7, 19, 3, 2};

        //var numbersLessThanFive = RunNumbersThroughTheGauntLet(numbers, LessThanFive);
        //var numbersLessThanTen = RunNumbersThroughTheGauntLet(numbers, LessThanTen);
        //var numbersLessThanTwenty = RunNumbersThroughTheGauntLet(numbers, GreaterThanTwenty);
        ////use lambda "=>" to simplize our delegate.(syntactic sugar)
        ////Because delegate has already had the struct.
        ////"=>" means ((parameter) => (return))
        //var numbersLessThanTwo = RunNumbersThroughTheGauntLet(numbers, i => i < 2);

        //Delegate Chaining
        //Adding and removing delegates...
        MeDelegate meDelegate = Moo;
        meDelegate = (MeDelegate) Delegate.Combine(meDelegate, (MeDelegate) Boo);
        meDelegate = meDelegate + Sue;
        meDelegate += Moo;
        meDelegate -= Moo;//The Result will be"Moo,Boo,Sue".The last one "Moo" will be removed;
        meDelegate.Invoke();

        foreach (var del in meDelegate.GetInvocationList())
        {
            Debug.Log($"Target:{del.Target}, Method:{del.Method}");
        }

        //What will get returned?
        MeDelegateReturnInt meDelRetInt = ReturnFive;
        meDelRetInt += ReturnTen;
        var value = meDelRetInt();
        Debug.Log(value);//The Result is 10.I will get the last value.

        foreach (var del in meDelRetInt.GetInvocationList())
        {
            Debug.Log(del.DynamicInvoke());
        }//The Result is 5 and then 10. we will get 2 value;


        //Generic Delegate
        MeDelegateGeneric<int> delegateGeneric = () => 5;
        delegateGeneric += () => 10;

        MeDelegateGeneric<string> meDelegateString = () => "Jeff";
        meDelegateString += (() => "Chris");

        //Usually, just like with generics, we don't have to create our own delegates
        //Because Actions and Funcs
        //Funcs have a return
        Func<int> meFunc = () => 5;//Func|Return~~~Fountain
        meFunc += () => 10;

        foreach (var f in meFunc.GetInvocationList())
        {
            Debug.Log(f.DynamicInvoke());
        }

        Func<int, int, string> meFunc2 = (i, i1) => ("me");
        //The last one is return

        //Action return void ,just parameter
        //Because 'Action' means do something. So Action have no return, just doing things in the method
        Action<int> meAct = TakeAnIntReturnVoid;
        #endregion
       

        #region Events
        //The difference between delegates, and events...


        //!!!An event is a delegate, with TWO restrictions: you can't assign them directly, and you can't invoke them directly
        
        TrainSignal.TrainsCOMING += ATrainsComing;
        #endregion

    }

    private void TakeAnIntReturnVoid(int obj)
    {
        Debug.Log(obj);
    }

    private int ReturnTen()
    {
        return 10;
    }

    private int ReturnFive()
    {
        return 5;
    }

    private static void Sue()
    {
        Debug.Log("Sue");
    }

    private void Boo()
    {
        Debug.Log("BOOOOOOOOOOOOO!");
    }

    private static void Moo()
    {
        Debug.Log("Moooooo");
    }
    ///// <summary>
    ///// Example for parameterize a method.
    ///// </summary>
    ///// <param name="numbers"></param>
    ///// <param name="gaunlet"></param>
    ///// <returns></returns>
    //private List<int> RunNumbersThroughTheGauntLet(List<int> numbers, MeDelegateInt gaunlet)
    //{
    //    return numbers.Where(number => gaunlet(number)).ToList();

    //    //var gaunletSurvivors = new List<int>();

    //    //foreach (var number in numbers)
    //    //{
    //    //    if (gaunlet(number))
    //    //    {
    //    //        gaunletSurvivors.Add(number);
    //    //    }
    //    //}
    //}

    //private bool LessThanFive(int n)
    //{
    //    return n < 5;
    //}

    //private bool LessThanTen(int n)
    //{
    //    return n < 10;

    //}

    //private bool GreaterThanTwenty(int n)
    //{
    //    return n > 20;
    //}



    //private List<int> GetAllTheNumberLessThanFive(List<int> ints)
    //{
    //    //List<int> listLessThanFive = new List<int>();
    //    //foreach (var i in ints)
    //    //{
    //    //    if (i<5)
    //    //    {
    //    //        listLessThanFive.Add(i);
    //    //    }
    //    //}
    //    return ints.Where(s => s < 5).ToList();
    //}

    //private List<int> GetAllTheNumberLessThanTen(List<int> ints)
    //{
    //    return ints.Where(s => s < 10).ToList();
    //}



    //private float Square(float i)
    //{
    //    return i * i;
    //}

    //private bool FooTakeIntReturnBool(int number)
    //{
    //    Debug.Log("Foo take int return bool!");
    //    return false;
    //}

    //private void Foo()
    //{
    //    Debug.Log("Foo!");
    //}

    //private static void Goo()
    //{
    //    Debug.Log("Goo!");
    //}

    //private static void InvokeTheDelegate(MeDelegate del)
    //{
    //    del();
    //}

    //private void FooTakeInt(int number)
    //{
    //    Debug.Log("Foo take int!");
    //}

    //private int FooReturnInt()
    //{
    //    Debug.Log("Foo return int!");
    //    return 0;
    //}

    private void ATrainsComing()
    {
        Debug.Log("Screeeeeeetch");
    }


}

public class TrainSignal
{
    public event Action TrainsCOMING;

    public void HereComesATrain()
    {
        if (TrainsCOMING != null)
        {
            TrainsCOMING.Invoke();
        }
    }
}

public class NaughtyBoy : MonoBehaviour
{

    private void OnEnable()
    {
        var trainsSignal = DelegatesExamples.TrainSignal;
        trainsSignal = null;
    }
}
