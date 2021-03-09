using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour
{

    public void FullScene(bool isFull)
    {
        Screen.fullScreen = isFull;
    }
}
