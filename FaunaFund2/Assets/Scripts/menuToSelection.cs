using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class menuToSelection : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        Console.WriteLine("hello");
        Application.LoadLevel(sceneName);
    }
}
