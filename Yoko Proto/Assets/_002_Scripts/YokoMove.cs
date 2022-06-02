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
    private List<GameObject> allYokos = new List<GameObject>();
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        //Je r�cup�re tous mes Yoko et je les mets dans une list
        allYokos.AddRange(GameObject.FindGameObjectsWithTag("Yoko"));
        moveTime = 1.75f;
        allEnti.AddRange(FindObjectsOfType<EntityRaycast>());
    }

    void Update()
    {
        //Quand le bouton a �t� appuy�, j'applique un d�compte en temps r�el � moveTime
        if (isGameStarted)
        {
            moveTime -= Time.deltaTime;
            //Si "moveTime" est �gal ou inf�rieur � 0, je d�place mon objet Yoko de "moveBy" (int modifiable) en x
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
            if (allYokos.Count == 0) SceneManager.LoadScene("Menu");
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
