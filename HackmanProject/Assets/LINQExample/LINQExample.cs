using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//LINQ stand for language Integrated Query
public class LINQExample : MonoBehaviour
{
    private void Awake()
    {
        #region LINQIntro
        //    //Data source
        //    var names = new[] { "Bill", "Steve", "James", "Juno" };

        //    //Query syntax
        //    var namesWithAQuery = from name in names
        //                          where name.Contains('a')
        //                          select name;

        //    //Method syntax
        //    //'n' goes to... => This is called a Lambda expression
        //    //Method syntax has more operators and methods, and is what the compiler converts query syntax to. It doesn't really matter which style you use, but keep this in mind
        //    var namesWithAMethod = names.Where(n => n.Contains('a'));

        //    foreach (var name in namesWithAQuery)
        //    {
        //        Debug.Log(name);
        //    }

        //    foreach (var name in namesWithAMethod)
        //    {
        //        Debug.Log(name);
        //    }
        #endregion

        #region LINQ Example1

        var students = new List<Student>()
        {
            new Student()
            {
                Name = "Chris", Age = 22, IQ = 218,
                Courses = new List<string>() {"Programming", "Being Cool", "The Art of Eating Eggs", "Music"}
            },
            new Student()
            {
                Name = "Chris", Age = 67, IQ = 100,
                Courses = new List<string>() {"Programming", "Being Cool", "The Art of Eating Eggs", "Music"}
            },
            new Student()
            {
                Name = "Jeff", Age = 24, IQ = 100,
                Courses = new List<string>() {"Programming", "WangZheRongYao", "Eating","Get Platinum Trophy"}
            },
            new Student()
            {
                Name = "Jesson", Age = 23, IQ = 120,
                Courses = new List<string>() {"Programming", "WangZheRongYao", "Maya","BengBengBeng"}
            },
            new Student()
            {
                Name = "Nan", Age = 23, IQ = 60,
                Courses = new List<string>() {"Design", "WangZheRongYao", "Dancing", "Sleeping","BubbleQueen"}
            },
            new Student()
            {
                Name = "Lyon", Age = 24, IQ = 90,
                Courses = new List<string>() {"PE", "Watch People", "Being fit"}
            },

            new Student()
            {
                Name = "Nico", Age = 25, IQ = 210,
                Courses = new List<string>() {"Design", "NS", "Watch shows"}
            },
        };

        //TakeWhile这个方法就是，while（条件）就放进列表中，一旦条件不达成就停止loop了
        //想要获取所有的，就用where这个方法
        var studentsWhoAreSmart = students
            .OrderByDescending(s => s.IQ)
            .TakeWhile(s => s.IQ > 100);

        foreach (var student in studentsWhoAreSmart)
        {
            Debug.Log(student.Name);
        }

        //Select这个方法可以选取你想要的一类数据，youngStudentNames这个类型就是只是string，因为我选择的是s.Name，而name只是string而已
        var youngStudentNames = students
            .Where(s => s.Age < 23)
            .Select(s => s.Name);

        //列表中有两个叫Chris的，如果遍历，会打印出两次Chris，但是用Distinct（）就只会打印出一次Chris，后一次的Chris会被删除
        var distictStudents = students.Select(s => s.Name).Distinct();

        //SkipWhile（条件）方法是，按顺序判断，如果碰到条件的，就跳过这一个，然后全部遍历
        var skipYoungerStudents = students.SkipWhile(s => s.Age < 60);
    }
    #endregion

    #region Generics and Delegates
    //Method syntax 
    //Filter Operators: filter a sequence based on some arguments/criteria(Where,OfType)
    //Sorting Operators: arranges elements in a collection(OrderBy, OrderBy)
    #endregion

}

public class Enemy
{
    public string Name;
    public int HP;
}

public class Student
{
    public string Name;
    public int Age;
    public int IQ;
    public List<String> Courses;
}

