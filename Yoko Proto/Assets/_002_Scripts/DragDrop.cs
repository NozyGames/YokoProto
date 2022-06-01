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
        //Je r�cup�re "Loader" via son component "YokoMove"
        Yoko = FindObjectOfType<YokoMove>();
        tileBase = highlitedTilemap.GetTilesBlock(highlitedTilemap.cellBounds);
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
    private void OnMouseUp()
    {
        Vector3 plPos = transform.position;
        for (int i = 0; i < tileBase.Length; i++)
        {
            Tile tileda = (Tile)tileBase[i];
            Tilemap tHigh = new Tilemap();
            tHigh = highlitedTilemap;
            TileBase[] tbHigh = tHigh.GetTilesBlock(new BoundsInt(new Vector3Int(0, 0, 0), new Vector3Int(5, 5, 0)));

            for (int d = 0; d < tbHigh.Length; d++)
            {
                Tile _ti = (Tile)tbHigh[d];
                Vector3 _tpos = _ti.transform.GetPosition();
                Vector3 _tscale = _ti.transform.lossyScale;

                Bounds _b = new Bounds(_tpos, _tscale);

                if (_b.Contains(transform.position))
                {
                    plPos.Set(_tpos.x, _tpos.y, 0);
                }
            }
        }
    }
    Vector3 GetMousePos()
    {
        //Je stock dans une variable la position de la souris par rapport � la cam�ra
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
