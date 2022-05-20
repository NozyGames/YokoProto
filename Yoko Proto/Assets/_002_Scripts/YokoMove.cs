using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokoMove : MonoBehaviour
{
    public float moveTime;
    public GameObject Yoko;
    public int moveBy = 1;
    public bool isGameStarted;
    void Start()
    {
        //Je r�cup�re mon objet Yoko (qui sera en l'occurrence le "Loader") via le tag "Yoko"
        Yoko = GameObject.FindGameObjectWithTag("Yoko");
        moveTime = 1;
    }

    void Update()
    {
        //Si "moveTime" est � 0 ou inf�rieur et que le bouton a �t� appuy�, je d�place mon objet Yoko de "moveBy" (int modifiable) en x
        if (moveTime <= 0 && isGameStarted)
        {
            Yoko.transform.Translate(moveBy, 0, 0);
            moveTime = 1;
        }
        else moveTime -= Time.deltaTime;
    }
}
