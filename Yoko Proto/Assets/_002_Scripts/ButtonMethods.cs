using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMethods : MonoBehaviour
{
    public YokoMove Yoko;
    public void StartGame()
    {
        Yoko.isGameStarted = true;
    }
}
