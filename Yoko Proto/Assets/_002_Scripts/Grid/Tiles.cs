using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    [SerializeField] private SpriteRenderer tileRenderer;
    [SerializeField] private Sprite gridBaseSprite, gridOffsetSprite;
    [SerializeField] private GameObject Highlight;
    public void Init(bool isOffset) // Faire alterner le sprite pour faire un damier
    {
        tileRenderer.sprite = isOffset ? gridOffsetSprite : gridBaseSprite;
    }

    private void OnMouseEnter()
    {
        Highlight.SetActive(true);
    }
    private void OnMouseExit()
    {
        Highlight.SetActive(false);
    }
}
