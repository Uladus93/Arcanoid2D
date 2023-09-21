using System.Collections.Generic;

[System.Serializable]
public class ProgressOfLevels
{
    public List<Progress> Levels = new List<Progress>();

    public ProgressOfLevels()
    {
        Levels = new List<Progress>();
    }
}