using UnityEngine;

public class LevelsCount : MonoBehaviour
{
    [SerializeField] TopList _toplist;
    private static int _levelsCount;

    public static int HowMuchLevels { get { return _levelsCount; } private set { } }

    private void Start()
    {
        LevelAbilities levelsAbilities = new LevelAbilities();
        ProgressOfLevels progressOfLevels = levelsAbilities.GetLevelProgress();
        _levelsCount = progressOfLevels.Levels.Count;
        _toplist.SetArrays();
    }
}
