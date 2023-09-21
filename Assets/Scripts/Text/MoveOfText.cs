using UnityEngine;

public class MoveOfText : MonoBehaviour
{
    [SerializeField] private PlayerPanel _panel;

    public void FixedUpdate()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Move: " + _panel.FoilForPlayerPanel.Foil.ToString();
    }
}