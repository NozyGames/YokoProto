using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField] private int gridWidth, gridHeight; //dimensions de la grille
    [SerializeField] private Tiles tilePrefab;
    [SerializeField] private Transform cameraTransform;

    private Dictionary<Vector3, Tiles> tilesDictionnary; // Dictionnaire pour accéder aux tiles

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateGrid()
    {
        tilesDictionnary = new Dictionary<Vector3, Tiles>(); //Créer le nouveau dictionnaire

        for (int x = 0;x < gridWidth; x++) // Pour tout x < largeur
        {
            for ( int y = 0; y < gridHeight; y++) // Pour tout y inferieur hauteur
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity); // faire spawn tuiles
                spawnedTile.name = $"Tile {x} {y}"; //Donner le nom à la tuile

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);  //x pair y impair ou x impair y pair
                spawnedTile.Init(isOffset);

                tilesDictionnary[new Vector3(x, y)] = spawnedTile; //Actualiser le dico
            }
        }

        cameraTransform.transform.position = new Vector3((float)gridWidth / 2 - 0.5f, (float)gridHeight / 2 - 0.5f, -10); //Centrer cam sur la grille
    }

    public Tiles GetTileAtPosition(Vector2 pos) // fonction a appeler pour obtenir une tile à telle pos
    {
        if(tilesDictionnary.TryGetValue(pos, out var tile))
        {
            return tile; // si on peut return la tile, return la tile
        }
        return null; // sinon ça return null
    }
}
