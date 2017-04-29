using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBackgroundScript : MonoBehaviour
{
    public RawImage ImageOnPanel;
    public float SekundyDoZmiany;
    private RawImage img;
    public Texture[] NewTexture;

    void Start()
    {
        StartCoroutine(ChangeBackground());
    }

    IEnumerator ChangeBackground()
    {
        img = ImageOnPanel.GetComponent<RawImage>();
        while (true)
        {
            foreach (Texture i in NewTexture)
            {

                img.color = new Color32(255, 255, 255, 69);
                img.texture = i;

                yield return new WaitForSeconds(SekundyDoZmiany);

            }
        }
    }
    void Update()
    {

    }
}