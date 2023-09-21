[System.Serializable]
public class LevelData
{
    public int _weight;
    public int _height;
    public string[] _blocks;

    public LevelData()
    {
        _weight = 7;
        _height = 8;
        _blocks = null;
    }
}
