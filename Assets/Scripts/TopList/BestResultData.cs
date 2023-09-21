using UnityEngine;

[System.Serializable]
public class BestResultData
{
    public int _score;
    public string _name;

    public BestResultData()
    {
        _score = 0;
        _name = string.Empty;
    }
}
