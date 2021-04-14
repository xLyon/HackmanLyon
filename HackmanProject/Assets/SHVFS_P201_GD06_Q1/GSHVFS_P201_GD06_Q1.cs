using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SHVFS_P201_GD06_Q1
{
    public class GSHVFS_P201_GD06_Q1:MonoBehaviour
    {
        public int num = 5;
        public string name = "Jeff";

        public string[] nameList=new string[] {"Jeff","Lyon","Jesson","Nan","Nico"};

        private void Start()
        {
            for (int i = 0; i < nameList.Length; i++)
            {
                Debug.Log(nameList[i]);
            }
        }

        public int AddNum(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}

