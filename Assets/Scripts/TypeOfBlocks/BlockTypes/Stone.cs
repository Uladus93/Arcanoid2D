using System.Collections.Generic;
using UnityEngine;

public class Stone : Brick, IBrick
{
    public void SetData(StoneBlockData stoneData)
    {
        _skins = new List<Sprite>(stoneData.Sprites);
    }
}