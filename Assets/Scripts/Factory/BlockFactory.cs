using UnityEngine;

internal class BlockFactory : Factory
{
    [SerializeField] private ColoredBlock _coloredBlock;
    public override IBrick GenerateBrick(int x, int y)
    {
        ColoredBlock coloredBlock = Instantiate(_coloredBlock, new Vector3(x, y, gameObject.transform.position.z), Quaternion.identity, gameObject.transform);
        return coloredBlock;
    }
}