public class LifesOfPlayer
{
    private int _lifes = 3;
    public int Lifes { get { return _lifes; } }

    public void LifeLess()
    {
        _lifes--;
    }

    public void ReloadLifes()
    {
        _lifes = 3;
    }
}
