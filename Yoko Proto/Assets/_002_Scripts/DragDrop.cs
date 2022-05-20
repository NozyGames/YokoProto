using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{
    private Vector3 dragOffset;
    private Camera cam;
    private YokoMove Yoko;

    private void Start()
    {
        //Je r�cup�re "Loader" via son component "YokoMove"
        Yoko = gameObject.GetComponentInParent<YokoMove>();
    }
    private void Awake()
    {
        //Je met sous une variable la cam�ra principale
        cam = Camera.main;
    }
    private void OnMouseDown()
    {
        //Tant que le bouton n'est pas appuy�, je set "dragOffset"
        if (!Yoko.isGameStarted) dragOffset = transform.position - GetMousePos();
    }
    private void OnMouseDrag()
    {
        //Tant que le bouton n'est pas appuy�, je set la position de l'objet
        if (!Yoko.isGameStarted) transform.position = GetMousePos() + dragOffset;
    }
    Vector3 GetMousePos()
    {
        //Je stock dans une variable la position de la souris par rapport � la cam�ra
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
