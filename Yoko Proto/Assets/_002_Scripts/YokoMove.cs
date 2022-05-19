using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokoMove : MonoBehaviour
{
    public float moveTime;
    public GameObject[] Yoko;
    public int moveBy = 1;
    public bool isGameStarted;
    void Start()
    {
        Yoko = GameObject.FindGameObjectsWithTag("Yoko");
        moveTime = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTime <= 0 && isGameStarted)
        {
            Yoko[0].transform.Translate(moveBy, 0, 0);
            Yoko[1].transform.Translate(moveBy, 0, 0);
            Yoko[2].transform.Translate(moveBy, 0, 0);
            moveTime = 1;
        }
        else moveTime -= Time.deltaTime;
    }
}
