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
    private Vector3 startPos;

    private void Start()
    {
        //Je récupère "Loader" via son component "YokoMove"
        Yoko = FindObjectOfType<YokoMove>();
    }
    private void Awake()
    {
        //Je met sous une variable la caméra principale
        cam = Camera.main;
    }
    private void OnMouseDown()
    {
        startPos = transform.position;
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
        Tilemap tHigh = new Tilemap();
        tHigh = highlitedTilemap;
        TileBase[] tbHigh = tHigh.GetTilesBlock(new BoundsInt(new Vector3Int(0, 0, 0), new Vector3Int(5, 5, 0)));

        //for (int d = 0; d < tbHigh.Length; d++)
        foreach(Tile highlited in tbHigh)
        {
            Tile _ti = highlited;//(Tile)tbHigh[d];
            Vector3 _tpos = _ti.transform.GetPosition();
            Vector3 _tscale = _ti.transform.lossyScale;
            Vector3Int _tposint = Vector3Int.FloorToInt(_tpos);
            Vector3 worldposcell = highlitedTilemap.CellToWorld(_tposint);

            Bounds _b = new Bounds(_tpos, _tscale);
            plPos.Set(worldposcell.x, worldposcell.y, 0);

            if (_b.Contains(transform.position))
            {
                transform.position = plPos;
            }
            else transform.position = startPos;
            Debug.Log("worldposcell = " + worldposcell);
        } 
    }
    Vector3 GetMousePos()
    {
        //Je stock dans une variable la position de la souris par rapport à la caméra
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
