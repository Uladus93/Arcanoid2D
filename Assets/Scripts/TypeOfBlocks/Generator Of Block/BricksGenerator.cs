using UnityEngine;

public class BricksGenerator : MonoBehaviour
{
    private BlockData[] _bricks;
    [Header("Fabricks")]
    [SerializeField] private BlockFactory _blockFactory;
    [SerializeField] private StoneFactory _stoneFactory;

    [Header ("BlockData")]
    [SerializeField] private BlockData _redBlock;
    [SerializeField] private BlockData _orangeBlock;
    [SerializeField] private BlockData _yellowBlock;
    [SerializeField] private BlockData _greenBlock;
    [SerializeField] private BlockData _whiteBlueBlock;
    [SerializeField] private BlockData _blueBlock;
    [SerializeField] private BlockData _purpleBlock;
    [SerializeField] private BlockData _stone;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _ball;
    private LevelData _levelData;
    private int _numberOfLevel = 0;
    public int NumberOfLevel { get { return _numberOfLevel; } }

    public void LoadLevel(int level)
    {
        ClearLevel();
        _numberOfLevel = level;
        LoadJson(level);
        SetBricks();
        GeneratorOfBlocks();
        _player.SetActive(true);
        _ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    void ClearLevel()
    {
        DestroyObjects(_stoneFactory.GetComponentsInChildren<IBrick>());
        DestroyObjects(_blockFactory.GetComponentsInChildren<IBrick>());

        void DestroyObjects(IBrick[] bricks)
        {
            foreach (IBrick brick in bricks)
            {
                brick.DestroyBrick();
            }
        }
    }

    private void GeneratorOfBlocks()
    {
        for (int i = _bricks.Length - 1; i >= 0; i--)
        {
            if (_bricks[i] == null) continue;
            int y = _levelData._height - i / _levelData._weight + 1;
            int x = i % _levelData._weight - 3;
            switch (_bricks[i].GetType().ToString())
            {
                case "ColoredBlockData":
                    ColoredBlock block = (ColoredBlock)_blockFactory.GenerateBrick(x, y);
                    block.SetData((ColoredBlockData)_bricks[i]);
                    break;
                case "StoneBlockData":
                    Stone stone = (Stone)_stoneFactory.GenerateBrick(x, y);
                    stone.SetData((StoneBlockData)_bricks[i]);
                    break;
                default: break;
            }
        }
    }

    private void SetBricks()
    {
        _bricks = new BlockData[_levelData._blocks.Length];
        
        for (int j = 0; j < _levelData._blocks.Length; j++)
        {
            switch (_levelData._blocks?[j])
            {
                case "redBlock":
                    _bricks[j] =_redBlock; break;
                case "orangeBlock":
                    _bricks[j] = _orangeBlock; break;
                case "yellowBlock":
                    _bricks[j] = _yellowBlock; break;
                case "greenBlock":
                    _bricks[j] = _greenBlock; break;
                case "whiteBlueBlock":
                    _bricks[j] = _whiteBlueBlock; break;
                case "blueBlock":
                    _bricks[j] = _blueBlock; break;
                case "purpleBlock":
                    _bricks[j] = _purpleBlock; break;
                case "stone":
                    _bricks[j] = _stone; break;
                default: break;
            }
        }
    }

    private void LoadJson(int level)
    {
        var levelfile = Resources.Load($"Levels/Level{level}");
        string json = levelfile.ToString();
        _levelData = JsonUtility.FromJson<LevelData>(json);
    }
}