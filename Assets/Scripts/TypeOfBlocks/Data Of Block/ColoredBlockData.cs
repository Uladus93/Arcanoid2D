using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColoredStone", menuName = "GameData/Create/ColoredData")]
public class ColoredBlockData : BlockData
{
    public List<Sprite> Sprites;
    public Color BaseColor;
    public int Score;
}
