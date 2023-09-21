using UnityEngine;
using UnityEngine.UI;

public class LevelButtonGenerator : MonoBehaviour
{
    [SerializeField] private Button _buttonPrefab;
    [SerializeField] private GameObject _content;

    private void Start()
    {
        Generate();
    }

    private void Generate()
    {
        LevelAbilities levelsAbilities = new LevelAbilities();
        ProgressOfLevels progressOfLevels = levelsAbilities.GetLevelProgress();
        for (int i = 0; i < progressOfLevels.Levels.Count; i++)
        {
            Button button = Instantiate(_buttonPrefab, _content.transform);
            if (button.gameObject.TryGetComponent(out LevelButton levelButton))
            {
                levelButton.SetData(progressOfLevels.Levels[i], i);
            }
        }
    }
}