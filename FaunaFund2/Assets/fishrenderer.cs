using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static System.Console;


public class fishrenderer : MonoBehaviour


    /*
     * TO DO:
     *  1 - Fish1
     *  2 - Fish2
     *  3 - Seaweed
     */ 

  

{
    private static float threshold = 0.18f;
    public Rect sourceRect;

    public static List<KeyValuePair<int, KeyValuePair<int, int>>> combined = new List<KeyValuePair<int, KeyValuePair<int, int>>>();

    public void initPixels()
    {

        Texture2D sourceTex = takePhoto.sourText;
        int x = Mathf.FloorToInt(sourceRect.x);
        Debug.Log(x);
        int y = Mathf.FloorToInt(sourceRect.y);
        int width = Mathf.FloorToInt(sourceRect.width);
        int height = Mathf.FloorToInt(sourceRect.height);
        Debug.Log(y);
        Debug.Log(width);
        Debug.Log(height);
        Color[] pixels = sourceTex.GetPixels(0, 0, sourceTex.width, sourceTex.height);
        Color[,] grid = Make2DArray<Color>(pixels, sourceTex.width, sourceTex.height);
        //Debug.Log("Beginning Conversion");
        GridToList(grid);
        foreach (var item in combined)
        {
           // Debug.Log(item);
        }
    }

    static T[,] Make2DArray<T>(T[] input, int height, int width)
    {
        T[,] output = new T[height, width];
        //Debug.Log(height);
       // Debug.Log(width);
       // Debug.Log(input.Length);
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                output[i, j] = input[i * width + j];
            }
        }
        return output;
    }


    static void GridToList(Color[,] grid)
    {
        combined = FindObject(grid);
    }
    static bool isWhite(Color input)
    {
        float r = input.r - 0;
        float g = input.g - 0;
        float b = input.b - 0;
        bool n = (r * r + g * g + b * b) <= threshold * threshold;

        return n;
    }
    static bool isRed(Color input)
    {
        float r = input.r - 1;
        float g = input.g - 0;
        float b = input.b - 0;

        return (r * r + g * g + b * b) <= threshold * threshold;
    }

    static bool isGreen(Color input)
    {
        float r = input.r - 0;
        float g = input.g - 1;
        float b = input.b - 0;

        return (r * r + g * g + b * b) <= threshold * threshold;
    }

    static bool isBlue(Color input)
    {
        float r = input.r - 0;
        float g = input.g - 0;
        float b = input.b - 1;

        return (r * r + g * g + b * b) <= threshold * threshold;
    }

    static int findColor(Color input)
    {
        if (isWhite(input))
        {
            return -1;
        }
        else if (isRed(input))
        {
            return 1;
        } 
        else if (isBlue(input))
        {
            //Debug.Log("Is Blue");
            return 2;
        } 
        else if (isGreen(input))
        {
            return 3;
        }
        Debug.Log("NOTHING");
        return -1;

    }

    static List<KeyValuePair<int, KeyValuePair<int, int>>> FindObject(Color[,] grid)
    {
        //Debug.Log("Beginning Debug");
        var fishList = new List<KeyValuePair<int, KeyValuePair<int, int>>>();
        for (int i = 0; i < grid.GetLength(0); i += 25)
        {
            for (int j = 0; j < grid.GetLength(1); j += 25)
            {
                // Debug.Log("Colour  at " + i + " " + j+ "is"+ findColor(grid[i, j]));
                int pixelColour = findColor(grid[i, j]);

                //Debug.Log("the color is " + pixelColour + " "+ i +" "+j);

                if ( pixelColour!= -1)
                {
                    //Debug.Log("Found Colour");
                    //Debug.Log(findColor(grid[i, j]));
                    var tempList = new List<KeyValuePair<int, int>>();
                    floodSearch(grid, tempList, pixelColour, i, j);
                    //Debug.Log(tempList);
                    fishList.Add(new KeyValuePair<int, KeyValuePair<int, int>>(pixelColour, TopLeft(tempList)));
                    for (int k =0; k<fishList.Count;k++) {

                        Debug.Log(fishList[k].Key + ": " + fishList[k].Value.Key + ", " + fishList[k].Value.Value);

                        
                    }
                   
                }
            }
        }
        return fishList;
    }

    static void floodSearch(Color[,] grid, List<KeyValuePair<int, int>> traverseList, int type, int x, int y)
    {
        //Debug.Log("Searching");
        //Debug.Log("position at " + x + " " + y);
       // Debug.Log(grid.GetLength(0)-1);
        //Debug.Log(grid.GetLength(1) - 1);
        if (x < 0 || x > grid.GetLength(0) - 1 || y < 0 || y > grid.GetLength(1) - 1 ||  findColor(grid[x, y]) != type)
        {
           
            {
                //Debug.Log("MINUS FOUND");
                return;
            }
        }
        traverseList.Add(new KeyValuePair<int, int>(x, y));
        grid[x,y] = new Color(0, 0, 0, 0);

        floodSearch(grid, traverseList, type, x - 25, y);
        floodSearch(grid, traverseList, type, x + 25, y);
        floodSearch(grid, traverseList, type, x, y - 25);
        floodSearch(grid, traverseList, type, x, y + 25);
    }

    static KeyValuePair<int, int> TopLeft(List<KeyValuePair<int, int>> pointList)
    {
        int x = int.MaxValue;
        int y = int.MaxValue;

        foreach (var val in pointList)
        {
            if (val.Key < x)
            {
                x = val.Key;
            }

            if (val.Value < y)
            {
                y = val.Value;
            }
        }

        return new KeyValuePair<int, int>(x, y);
    }
}