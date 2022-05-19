using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLdown : MonoBehaviour
{
    public LayerMask Kyoko;
    void Update()
    {
        //Je cr�� un Raycast nomm� Hit qui part de la position du Yoko et va vers le bas sur une distance de 1 et qui ne touche que les Kyokos
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(-Vector2.up), 1, Kyoko);
        //Je debug un rayon rouge qui repr�sente le Raycast (uniquement sur l'�diteur)
        Debug.DrawRay(transform.position, transform.TransformDirection(-Vector2.up) * 1, Color.red);

        if (hit)
        {
            //Quand le Raycast rentre en contact avec une cible, je log le nom de la cible et la d�truit
            Debug.Log("Hit " + hit.collider.name);
            Destroy(hit.transform.gameObject);
        }
    }
}
