using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class DragDrop : MonoBehaviour
{
    private Vector3 dragOffset;
    private Camera cam;
    private YokoMove Yoko;
    [SerializeField]
    private Tilemap highlitedTilemap;
    private TileBase[] tileBase;

    private void Start()
    {
        Debug.Log("Start");
        //Je récupère "Loader" via son component "YokoMove"
        Yoko = gameObject.GetComponentInParent<YokoMove>();
        tileBase = highlitedTilemap.GetTilesBlock(highlitedTilemap.cellBounds);
    }
    private void Awake()
    {
        //Je met sous une variable la caméra principale
        cam = Camera.main;
    }
    private void OnMouseDown()
    {
        Vector3 startPos = transform.position;
        //Tant que le bouton n'est pas appuyé, je set "dragOffset"
        if (!Yoko.isGameStarted) dragOffset = transform.position - GetMousePos();
    }
    private void OnMouseDrag()
    {
        //Tant que le bouton n'est pas appuyé, je set la position de l'objet
        if (!Yoko.isGameStarted) transform.position = GetMousePos() + dragOffset;
    }
    private void OnMouseUp()
    {
        Vector3 plPos = transform.position;
        for (int i = 0; i < tileBase.Length; i++)
        {
            Tile tileda = (Tile)tileBase[i];
            //Bounds bound = new Bounds(tileda.transform[0, 3], tileda.transform[1, 3], 0, tileda.transform[0, 2], tileda.transform[1, 2]);
        }
    }
    Vector3 GetMousePos()
    {
        //Je stock dans une variable la position de la souris par rapport à la caméra
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    private void Test()
    {
        Tilemap _t = new Tilemap();
        TileBase[] _tb = _t.GetTilesBlock(new BoundsInt(new Vector3Int(0, 0, 0), new Vector3Int(5, 5, 0)));

        for (int i = 0; i < 25; i++)
        {
            Tile _ti = (Tile)_tb[i];
            //Vector3 _tpos = _ti.transform.GetPosition();
        }
    }
}
