using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ColoredBlock : Brick, IBrick
{
    private int _points;
    protected int _blockLifes;
    public int Points { get { return _points; } }

    public void SetData(ColoredBlockData blockData)
    {
        _skins = new List<Sprite>(blockData.Sprites);
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _blockLifes = _skins.Count;
        _spriteRenderer.sprite = _skins[_blockLifes - 1];
        _spriteRenderer.color = blockData.BaseColor;
        _points = blockData.Score;
    }

    public void SetDamage()
    {
        _blockLifes--;
        if (_blockLifes == 0)
        {
            GetComponentInParent<BrickLess>().BrickLessOnOne();
            Destroy(gameObject);        
        }
        else
        {
            _spriteRenderer.sprite = _skins[_blockLifes - 1];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<BallMoved>(out BallMoved ball))
        {
            SetDamage();
        }
    }
}