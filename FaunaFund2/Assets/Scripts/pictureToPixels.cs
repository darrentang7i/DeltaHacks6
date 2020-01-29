using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pictureToPixels : MonoBehaviour
{
    private WebCamTexture backCam;
    private Texture defaultBackground;
    public RawImage background;

    // Start is called before the first frame update
    void Start()
    {
        defaultBackground = background.texture;

        backCam = new WebCamTexture();
        backCam.Play();

        background.texture = backCam;
    }

}
