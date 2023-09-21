using UnityEngine;

internal abstract class Factory : MonoBehaviour
{
    public abstract IBrick GenerateBrick(int x, int y);
}
