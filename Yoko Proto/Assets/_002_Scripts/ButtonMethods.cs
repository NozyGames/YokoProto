using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMethods : MonoBehaviour
{
    public YokoMove Yoko;
    public Animator animator;
    public void StartGame()
    {
        //Si le bouton est appuyé, je met "isGameStarted" appartenant à la class YokoMove à "true"
        Yoko.isGameStarted = true;
        animator.SetBool("isClicked", true);
    }
}
