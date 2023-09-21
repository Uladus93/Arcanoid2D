using UnityEngine;

internal class StoneFactory : Factory
{
    [SerializeField] private Stone stone;
    public override IBrick GenerateBrick(int x, int y)
    {
        Stone newStone = Instantiate(stone, new Vector3(x, y, gameObject.transform.position.z), Quaternion.identity, gameObject.transform);
        return newStone;
    }
}