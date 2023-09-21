using UnityEngine;

public class FoilForPlayerPanel : MonoBehaviour
{ 
    private int _foil = 15;
    private int _standartFoil = 15;
    public int Foil { get { return _foil; } }

    public void FoilLess()
    {
        _foil--;
    }

    public void FoilUp()
    {
        float canister = 10 + gameObject.transform.position.y - gameObject.GetComponent<Move>().YMinPosition;
        _foil += (int)canister;
    }

    public void ReloadFoil()
    {
        _foil = _standartFoil;
    }
}