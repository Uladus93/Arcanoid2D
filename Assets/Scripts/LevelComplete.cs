using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _levelCompleteImage;
    [SerializeField] private BricksGenerator _generatorOfBricks;
    [SerializeField] private GameObject _content;
    [SerializeField] private TMPro.TextMeshProUGUI _sessionPoints;
    [SerializeField] private TMPro.TextMeshProUGUI _bestPoints;
    [SerializeField] private PlayerPanel _playerPanel;
    [SerializeField] private TopList _topList;
    [SerializeField] private Sprite[] _starsSprites;
    [SerializeField] private Image _starsImage;

    public int HowManyLevels { get; private set; }

    public void LevelIsDone()
    {
        if (gameObject.transform.childCount <= 1)
        {
            _topList.CheckBestResult();
            _ball.SetActive(false);
            int result = _playerPanel.LifesOfPlayer.Lifes * 100 + _playerPanel.FoilForPlayerPanel.Foil;
            _sessionPoints.text = $"Âàø âûí³ê: {result}";

            if (result > _topList.BestScores[_generatorOfBricks.NumberOfLevel - 1])
            {
                _bestPoints.text = $"Ëåïøû âûí³ê: {result}";
            }
            else
            {
                _bestPoints.text = $"Ëåïøû âûí³ê: {_topList.BestScores[_generatorOfBricks.NumberOfLevel - 1]}";
            }

            _levelCompleteImage.SetActive(true);
            LevelAbilities levelAbilities = new LevelAbilities();
            ProgressOfLevels progressOfLevels = levelAbilities.GetLevelProgress();
            HowManyLevels = progressOfLevels.Levels.Count;

            if (_generatorOfBricks.NumberOfLevel - 1 < progressOfLevels.Levels.Count)
            {
                levelAbilities.SaveLevelData(_generatorOfBricks.NumberOfLevel - 1, progressOfLevels.Levels[_generatorOfBricks.NumberOfLevel - 1], result);
                LevelButton[] progresses = _content.GetComponentsInChildren<LevelButton>();
                if (_generatorOfBricks.NumberOfLevel < progresses.Length)
                {
                    progresses[_generatorOfBricks.NumberOfLevel - 1].SetStars(result);
                    progresses[_generatorOfBricks.NumberOfLevel].SetIsOpened();
                }
            }

            if (result < 200)
            {
                _starsImage.sprite = _starsSprites[0];
            }
            else if (result > 200 && result < 300)
            {
                _starsImage.sprite = _starsSprites[1];
            }
            else if (result > 300)
            {
                _starsImage.sprite = _starsSprites[2];
            }
        }
    }
}