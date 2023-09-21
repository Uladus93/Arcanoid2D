using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class Brick : MonoBehaviour, IBrick
{
    protected Collider2D _collider2D;
    protected SpriteRenderer _spriteRenderer;
    protected List<Sprite> _skins;

    public List<Sprite> Skins { get { return _skins; } protected set { _skins = value; } }
    public Collider2D Collider2D { get { return _collider2D; } protected set { _collider2D = value; } }
    public SpriteRenderer SpriteRenderer2D { get { return _spriteRenderer; } protected set { _spriteRenderer = value; } }

    public void DestroyBrick()
    {
        Destroy(gameObject);
    }
}
