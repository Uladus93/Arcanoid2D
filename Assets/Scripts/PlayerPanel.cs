using UnityEngine;

public class PlayerPanel : MonoBehaviour
{
    private LifesOfPlayer _lifes;
    private FoilForPlayerPanel _foilForPlayerPanel;
    public LifesOfPlayer LifesOfPlayer { get { return _lifes; } }
    public FoilForPlayerPanel FoilForPlayerPanel { get { return _foilForPlayerPanel; } }

    private void Awake()
    {
        _lifes = new LifesOfPlayer();
        _foilForPlayerPanel = gameObject.AddComponent<FoilForPlayerPanel>();
    }

    public void NewLifesAndFoil()
    {
        _lifes.ReloadLifes();
        _foilForPlayerPanel.ReloadFoil() ;
    }

    public void FoilUp()
    {
        _foilForPlayerPanel.FoilUp();
    }
}