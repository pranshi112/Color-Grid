using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public Color baseColor;
    public SpriteRenderer _renderer;

    public void init()
    {
        _renderer.color = baseColor;
    }
}
