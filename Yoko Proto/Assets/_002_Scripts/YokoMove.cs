using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class YokoMove : MonoBehaviour
{
    public static YokoMove Instance { get; private set; }
    public float moveTime;
    public int moveBy = 1;
    public bool isGameStarted;
    private List<EntityRaycast> allEnti = new List<EntityRaycast>();
    public List<GameObject> allYokos = new List<GameObject>();
    public List<GameObject> allKyokos = new List<GameObject>();
    private Scene actual;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        //Je récupère tous mes Yoko et je les mets dans une list
        allYokos.AddRange(GameObject.FindGameObjectsWithTag("Yoko"));
        allKyokos.AddRange(GameObject.FindGameObjectsWithTag("Kyoko"));
        moveTime = 1.75f;
        allEnti.AddRange(FindObjectsOfType<EntityRaycast>());
    }

    void Update()
    {
        actual = SceneManager.GetActiveScene();
        //Quand le bouton a été appuyé, j'applique un décompte en temps réel à moveTime
        if (isGameStarted)
        {
            moveTime -= Time.deltaTime;
            //Si "moveTime" est égal ou inférieur à 0, je déplace mon objet Yoko de "moveBy" (int modifiable) en x
            if (moveTime <= 0)
            {
                foreach (GameObject yokos in allYokos)
                {
                    if (!yokos.GetComponent<EntityRaycast>().IsBlocked())
                    yokos.transform.Translate(moveBy, 0, 0);
                }
                moveTime = 1;
                foreach (EntityRaycast entity in allEnti)
                {
                    entity.CheckRaycast();
                }
            }
        }
        if (allYokos.Count == 0 && allKyokos.Count >= 1)
        {
            SceneManager.LoadScene("Menu");
        }
        if (allKyokos.Count == 0 && allYokos.Count >= 1)
        {
            SceneManager.LoadScene(actual.buildIndex + 1);
        }
    }
    public void RemoveEntity(EntityRaycast entity)
    {
        allEnti.Remove(entity);
    }

    public void RemoveYoko(GameObject yoko)
    {
        allYokos.Remove(yoko);
    }
}
