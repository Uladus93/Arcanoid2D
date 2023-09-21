using UnityEngine;
using System.IO;
using TMPro;

[System.Serializable]
public class TopList : MonoBehaviour
{
    [SerializeField] private GameObject[] _topList;
    [SerializeField] private int[] _bestScores;
    [SerializeField] private BricksGenerator _generator;
    [SerializeField] private PlayerPanel _player;
    [SerializeField] private GameObject _resultPrefab;
    [SerializeField] private UserName _userName;

    public int[] BestScores { get { return _bestScores; } private set { }  }

    public void SetArrays()
    {
        _topList = new GameObject[LevelsCount.HowMuchLevels];
        _bestScores = new int[LevelsCount.HowMuchLevels];
        for (int i = 0; i < _topList.Length; i++)
        {
            _topList[i] = Instantiate(_resultPrefab, new Vector3(0, gameObject.transform.position.y - 3 * i, gameObject.transform.position.z), Quaternion.identity, gameObject.transform);
        }
        LoadResultsFromJSON();
    }

    public void CheckBestResult()
    {
        if (_player.LifesOfPlayer.Lifes * 100 + _player.FoilForPlayerPanel.Foil > _bestScores[_generator.NumberOfLevel - 1])
        {
            SaveResultToJSON();
            _topList[_generator.NumberOfLevel - 1].GetComponent<BestResultForLevelTextView>().SetResult(_generator.NumberOfLevel, _userName.UserNickName, _player.LifesOfPlayer.Lifes * 100 + _player.FoilForPlayerPanel.Foil);
        }
    }

    public void SaveResultToJSON()
    {
        BestResultData bestResultData = new BestResultData();
        bestResultData._name = _userName.UserNickName;
        bestResultData._score = _player.LifesOfPlayer.Lifes * 100 + _player.FoilForPlayerPanel.Foil;
        string json = JsonUtility.ToJson(bestResultData);
        File.WriteAllText(Application.persistentDataPath + $"/BestResultForLevel{_generator.NumberOfLevel}.json", json);
        _bestScores[_generator.NumberOfLevel - 1] = bestResultData._score;
    }

    public void LoadResultsFromJSON()
    {
        for (int i = 1; i <= _topList.Length; i++)
        {
            string path = Application.persistentDataPath + $"/BestResultForLevel{i}.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                BestResultData bestResult = JsonUtility.FromJson<BestResultData>(json);
                _bestScores[i - 1] = bestResult._score;
                _topList[i - 1].GetComponent<BestResultForLevelTextView>().SetResult(i, bestResult._name, bestResult._score);
            }
        }
    }
}