using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathbox : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<DragDrop>())
        {
            Debug.Log(collision.gameObject.name);
            Destroy(collision.gameObject);
        }
    }
}