using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIleft : MonoBehaviour
{
    public LayerMask Yoko;
    void Update()
    {
        //Je créé un Raycast nommé Hit qui part de la position du Yoko et va vers la gauche sur une distance de 1 et qui ne touche que les Yokos
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(-Vector2.right), 1, Yoko);
        //Je debug un rayon rouge qui représente le Raycast (uniquement sur l'éditeur)
        Debug.DrawRay(transform.position, transform.TransformDirection(-Vector2.right) * 1, Color.blue);

        if (hit)
        {
            //Quand le Raycast rentre en contact avec une cible, je log le nom de la cible et la détruit
            Debug.Log("Destroyed " + hit.collider.name);
            Destroy(hit.transform.gameObject);
        }
    }
}
