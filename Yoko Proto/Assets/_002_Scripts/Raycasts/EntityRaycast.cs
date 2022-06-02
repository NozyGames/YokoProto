using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityRaycast : MonoBehaviour
{
    public LayerMask hitLayer;
    [SerializeField]
    private Directions direction;
    public Directions EntityDirection { get { return direction; } }
    private Vector2 entiDirection;
    private void OnDrawGizmos()
    {
        //Je debug un rayon rouge qui représente le Raycast (uniquement sur l'éditeur)
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + (Vector3)(entiDirection * 0.7f), transform.position + (Vector3)(entiDirection * 0.9f));
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position + (Vector3.right * 0.2f), transform.position + (Vector3.right * 0.4f));
    }
    void Start()
    {
        switch (direction)
        {
            case Directions.Up:
                entiDirection = Vector2.up;
                break;
            case Directions.Down:
                entiDirection = Vector2.down;
                break;
            case Directions.Right:
                entiDirection = Vector2.right;
                break;
            case Directions.Left:
                entiDirection = Vector2.left;
                break;
        }
    }
    public void CheckRaycast()
    {
        //Je créé un Raycast nommé Hit qui part de la position du Yoko et va vers le bas sur une distance de 1 et qui ne touche que les Kyokos
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3)(entiDirection * 0.7f), transform.position + (Vector3)(entiDirection * 0.9f), 1, hitLayer);

        if (hit)
        {
            if (hit.transform.GetComponent<EntityRaycast>())
            {
                Directions tempDir = hit.transform.GetComponent<EntityRaycast>().EntityDirection;
                //Quand le Raycast rentre en contact avec une cible, je log le nom de la cible et la détruit
                Debug.Log("Hit " + hit.collider.name);
                Destroy(hit.transform.gameObject);
                YokoMove.Instance.allKyokos.Remove(GameObject.FindGameObjectWithTag("Kyoko"));
                switch (EntityDirection)
                {
                    case Directions.Up:
                        if (tempDir == Directions.Down) Destroy(gameObject);
                        break;
                    case Directions.Down:
                        if (tempDir == Directions.Up) Destroy(gameObject);
                        break;
                    case Directions.Right:
                        if (tempDir == Directions.Left) Destroy(gameObject);
                        break;
                    case Directions.Left:
                        if (tempDir == Directions.Right) Destroy(gameObject);
                        break;
                }
            }
        }
    }
    public void OnDestroy()
    {
        YokoMove.Instance?.RemoveEntity(this);
        YokoMove.Instance?.RemoveYoko(gameObject);
    }
    public bool IsBlocked()
    {
        RaycastHit2D blocker = Physics2D.Raycast(transform.position + (Vector3.right * 0.2f), transform.position + (Vector3.right * 0.4f), 1);
        if (blocker)
        {
            Debug.Log(blocker.transform.name + " blocked: " + name);
            if (blocker.transform.CompareTag("Yoko") || blocker.transform.name == "Deathbox") return false;
        }
        return blocker;
    }
}
