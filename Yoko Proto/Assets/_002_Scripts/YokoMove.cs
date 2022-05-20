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
        //Je récupère mon objet Yoko (qui sera en l'occurrence le "Loader") via le tag "Yoko"
        Yoko = GameObject.FindGameObjectWithTag("Yoko");
        moveTime = 1;
    }

    void Update()
    {
        //Si "moveTime" est à 0 ou inférieur et que le bouton a été appuyé, je déplace mon objet Yoko de "moveBy" (int modifiable) en x
        if (moveTime <= 0 && isGameStarted)
        {
            Yoko.transform.Translate(moveBy, 0, 0);
            moveTime = 1;
        }
        else moveTime -= Time.deltaTime;
    }
}
