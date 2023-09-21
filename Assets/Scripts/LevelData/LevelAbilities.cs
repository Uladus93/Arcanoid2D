using UnityEngine;

public class LevelAbilities
{
    private const string KeyName = "Save";
    private ProgressOfLevels _progressOfLevels = new ProgressOfLevels();

    private void SaveData()
    {
        string saveJson = JsonUtility.ToJson(_progressOfLevels);
        PlayerPrefs.SetString(KeyName, saveJson);
    }

    public void NewData()
    {
        var levelsCount = Resources.LoadAll<TextAsset>("Levels").Length;
        for (int i = 0; i < levelsCount; i++)
        {
            _progressOfLevels.Levels.Add(new Progress());
        }

        _progressOfLevels.Levels[0].IsOpened = true;
        SaveData();
        Resources.UnloadUnusedAssets();
    }

    public ProgressOfLevels GetLevelProgress()
    {
        
        if (PlayerPrefs.HasKey(KeyName))
        {
            string saveJson = PlayerPrefs.GetString(KeyName);
            _progressOfLevels = JsonUtility.FromJson<ProgressOfLevels>(saveJson);
        }
        else
        {
            NewData();
        }

        return _progressOfLevels;
    }

    public void SaveLevelData(int index, Progress progress, int result)
    {
        _progressOfLevels = GetLevelProgress();
        _progressOfLevels.Levels[index] = progress;
        if (result > 100 && result <= 200)
        {
            _progressOfLevels.Levels[index].StarsCount = 1;
        }
        else if (result > 200 && result <= 300)
        {
            _progressOfLevels.Levels[index].StarsCount = 2;
        }
        else
        {
            _progressOfLevels.Levels[index].StarsCount = 3;
        }
        _progressOfLevels.Levels[index].IsOpened = true;
        if (index + 1 < _progressOfLevels.Levels.Count)
        {
            _progressOfLevels.Levels[index + 1].IsOpened = true;
        }
        SaveData();
    }
}