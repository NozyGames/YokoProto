using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMethods : MonoBehaviour
{
    public YokoMove Yoko;
    public Animator animator;
    public void StartGame()
    {
        //Si le bouton est appuy�, je met "isGameStarted" appartenant � la class YokoMove � "true"
        Yoko.isGameStarted = true;
        animator.SetBool("isClicked", true);
    }
}
