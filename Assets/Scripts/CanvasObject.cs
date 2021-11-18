using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasObject : MonoBehaviour
{
    public static CanvasObject CO;
    public Image[] healthImage;

    private void Awake()
    {
        CO = GetComponent<CanvasObject>();   
    }
}
