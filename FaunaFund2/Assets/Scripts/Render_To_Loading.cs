using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Render_To_Loading : MonoBehaviour
{
    public void test()
    {
        Debug.Log("Hello");
        Application.LoadLevel("Loading Page");
    }

}