using UnityEngine;

[RequireComponent (typeof(TMPro.TextMeshProUGUI))]
public class BestResultForLevelTextView : MonoBehaviour
{
    public void SetResult(int level, string name, int score)
    {
        string bestPlayer = name.TrimEnd();
        string bestScore = score.ToString().TrimEnd();
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = $"Level {level}: {bestPlayer} {bestScore}";
    }
}
