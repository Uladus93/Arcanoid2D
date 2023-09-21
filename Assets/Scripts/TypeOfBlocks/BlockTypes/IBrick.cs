using System.Collections.Generic;
using UnityEngine;

public interface IBrick
{
    public Collider2D Collider2D { get; }
    public SpriteRenderer SpriteRenderer2D { get; }
    public List<Sprite> Skins { get; }
    public void DestroyBrick();
}