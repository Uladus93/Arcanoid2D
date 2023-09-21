using UnityEngine;

public class LifesText : MonoBehaviour
{
    [SerializeField] private PlayerPanel _panel;

    public void FixedUpdate()
    {
        if (_panel.LifesOfPlayer.Lifes == 1)
        {
            gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Life: " + _panel.LifesOfPlayer.Lifes.ToString();
        }
        else
        {
            gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Lifes: " + _panel.LifesOfPlayer.Lifes.ToString();
        }
    }
}
