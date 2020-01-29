using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayPicture : MonoBehaviour
{
    private Texture defaultBackground;
    public RawImage background;
    public Rect sourceRect;

    // Start is called before the first frame update
    void Start()
    {

        /*int width = Mathf.FloorToInt(sourceRect.width);
        int height = Mathf.FloorToInt(sourceRect.height);

        Texture2D newTex = new Texture2D(width, height);

        newTex.SetPixels(pixContainer.pix);
        newTex.Apply();

        background.texture = newTex;*/

        /*background.texture = pixContainer.Pix;*/
    }
}
