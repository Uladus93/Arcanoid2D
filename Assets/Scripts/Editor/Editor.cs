using UnityEngine;
using UnityEditor;
using System.IO;

public class Editor : EditorWindow
{
	private int _level;
	private string[] _sectionsOfEditor = { "Designer of Level" };
	private int _sectionIndexForEditor;

	//Level's designer
	private int _sectionIndexForLevelsDesigner;
	private string[] _sectionOfLevelsDesigner = { "Block", "Stones" };
	private Texture2D _selectedObject;
	private string _idOfTexture;
	private static int _weight = 7;
	private static int _height = 8;
	private static int _howManyBlocks = _weight * _height;
	private Texture2D[] _objectsOfGameField = new Texture2D[_howManyBlocks];
	private string[] _objectsOfGameFieldForLoad = new string[_howManyBlocks];

	//TypeOfBlocks
	[SerializeField] private Texture2D _redBlock;
	[SerializeField] private Texture2D _orangeBlock;
	[SerializeField] private Texture2D _yellowBlock;
	[SerializeField] private Texture2D _greenBlock;
	[SerializeField] private Texture2D _whiteBlueBlock;
	[SerializeField] private Texture2D _blueBlock;
	[SerializeField] private Texture2D _purpleBlock;
	[SerializeField] private Texture2D _stone;

    [MenuItem("Window/Editor of levels for Arcanoid")]

	public static void OpenWindow()
	{
		EditorWindow window = (Editor)GetWindow(typeof(Editor));
		window.minSize = new Vector2(500, 700);
		window.maxSize = new Vector2(700, 900);
		window.Show();
	}

	private void OnGUI()
	{
		_level = EditorGUILayout.IntField("level", _level);

		_sectionIndexForEditor = GUILayout.Toolbar(_sectionIndexForEditor, _sectionsOfEditor);

		switch (_sectionIndexForEditor)
		{
			case 0:
                LevelDesigner();
				break;
		}
	}

	private void LevelDesigner()
	{
		EditorGUILayout.BeginHorizontal();
		GUILayout.Space(200);
		EditorGUILayout.LabelField("Designer of levels:", EditorStyles.boldLabel);
		GUILayout.EndHorizontal();
		_sectionIndexForLevelsDesigner = GUILayout.Toolbar(_sectionIndexForLevelsDesigner, _sectionOfLevelsDesigner);
		EditorGUILayout.Space(10);
		switch (_sectionIndexForLevelsDesigner)
		{
			case 0:
				Blocks();
				break;
			case 1:
				Stones();
				break;
		}


		EditorGUILayout.BeginHorizontal();
		GUILayout.Space(220);
		EditorGUILayout.LabelField("Game field:", EditorStyles.boldLabel);
		GUILayout.EndHorizontal();


		for (int i = 0; i < _objectsOfGameField.Length ; i++)
		{
				if (i % _weight == 0)
				{
					GUILayout.Space(20);
					EditorGUILayout.BeginHorizontal();
					GUILayout.Space(63);
				}

				if (GUILayout.Button(_objectsOfGameField[i], GUILayout.MaxHeight(50), GUILayout.MaxWidth(50)))
				{
					_objectsOfGameField[i] = _selectedObject;
					_objectsOfGameFieldForLoad[i] = _idOfTexture;
				}

				if ((i + 1) % _weight == 0)
				{
					EditorGUILayout.EndHorizontal();
				}
		}

		GUILayout.Space(50);
		EditorGUILayout.BeginHorizontal();
		if (GUILayout.Button("Save Blocks"))
		{
			SaveField();
		}
		if (GUILayout.Button("Load Field"))
		{
			LoadField();
		}
		EditorGUILayout.EndHorizontal();
	}

	private void Blocks()
	{
		EditorGUILayout.BeginHorizontal();
		GUILayout.Space(226);
		EditorGUILayout.LabelField("Blocks:", EditorStyles.boldLabel);
		EditorGUILayout.EndHorizontal();
		EditorGUILayout.BeginHorizontal();
		GUILayout.Space(63);

		if (GUILayout.Button(_redBlock, GUILayout.MaxHeight(50), GUILayout.MaxWidth(50)))
		{
			_selectedObject = _redBlock;
			_idOfTexture = "redBlock";
		}

		if (GUILayout.Button(_orangeBlock, GUILayout.MaxHeight(50), GUILayout.MaxWidth(50)))
		{
			_selectedObject = _orangeBlock;
			_idOfTexture = "orangeBlock";
		}

        if (GUILayout.Button(_yellowBlock, GUILayout.MaxHeight(50), GUILayout.MaxWidth(50)))
        {
            _selectedObject = _yellowBlock;
            _idOfTexture = "yellowBlock";
        }

        if (GUILayout.Button(_greenBlock, GUILayout.MaxHeight(50), GUILayout.MaxWidth(50)))
		{
			_selectedObject = _greenBlock;
			_idOfTexture = "greenBlock";
		}

		if (GUILayout.Button(_whiteBlueBlock, GUILayout.MaxHeight(50), GUILayout.MaxWidth(50)))
		{
			_selectedObject = _whiteBlueBlock;
			_idOfTexture = "whiteBlueBlock";
		}

		if (GUILayout.Button(_blueBlock, GUILayout.MaxHeight(50), GUILayout.MaxWidth(50)))
		{
			_selectedObject = _blueBlock;
			_idOfTexture = "blueBlock";
		}

        if (GUILayout.Button(_purpleBlock, GUILayout.MaxHeight(50), GUILayout.MaxWidth(50)))
        {
            _selectedObject = _purpleBlock;
            _idOfTexture = "purpleBlock";
        }

        EditorGUILayout.EndHorizontal();
	}

	private void Stones()
	{
		EditorGUILayout.BeginHorizontal();
		GUILayout.Space(225);
		EditorGUILayout.LabelField("Stones:", EditorStyles.boldLabel);
		EditorGUILayout.EndHorizontal();
		EditorGUILayout.BeginHorizontal();
		GUILayout.Space(150);

		if (GUILayout.Button(_stone, GUILayout.MaxHeight(50), GUILayout.MaxWidth(50)))
		{
			_selectedObject = _stone;
			_idOfTexture = "stone";
		}
		EditorGUILayout.EndHorizontal();
	}

	private void SaveField()
	{
		LevelData levelData = new LevelData();
		levelData._blocks = new string[_howManyBlocks];
		for (int i = 0; i < _objectsOfGameFieldForLoad.Length; i++)
		{
			levelData._weight = _weight;
			levelData._height = _height;
			levelData._blocks[i] = _objectsOfGameFieldForLoad[i];
		}

        string json = JsonUtility.ToJson(levelData);
		string path = $"Assets/Resources/Levels/Level{_level}.json";
        File.WriteAllText(path, json);
    }

	private void LoadField()
	{
		string path = $"Assets/Resources/Levels/Level{_level}.json";
		if (File.Exists(path))
		{
			string json = File.ReadAllText(path);
            LevelData levelData = JsonUtility.FromJson<LevelData>(json);
			_weight = levelData._weight;
			_height = levelData._height;
			for (int j = 0; j < levelData._blocks.Length; j++)
			{
				switch (levelData._blocks[j])
				{
					case "redBlock":
						_objectsOfGameField[j] = _redBlock;
						_objectsOfGameFieldForLoad[j] = "redBlock";
                        break;
                    case "orangeBlock":
                        _objectsOfGameField[j] = _orangeBlock;
						_objectsOfGameFieldForLoad[j] = "orangeBlock";
                        break;
                    case "yellowBlock":
                        _objectsOfGameField[j] = _yellowBlock;
						_objectsOfGameFieldForLoad[j] = "yellowBlock";
                        break;
                    case "greenBlock":
                        _objectsOfGameField[j] = _greenBlock;
						_objectsOfGameFieldForLoad[j] = "greenBlock";
                        break;
                    case "whiteBlueBlock":
                        _objectsOfGameField[j] = _whiteBlueBlock;
						_objectsOfGameFieldForLoad[j] = "whiteBlueBlock";
                        break;
                    case "blueBlock":
                        _objectsOfGameField[j] = _blueBlock;
						_objectsOfGameFieldForLoad[j] = "blueBlock";
                        break;
                    case "purpleBlock":
                        _objectsOfGameField[j] = _purpleBlock;
						_objectsOfGameFieldForLoad[j] = "purpleBlock";
                        break;
                    case "stone":
                        _objectsOfGameField[j] = _stone;
						_objectsOfGameFieldForLoad[j] = "stone";
                        break;
					default: break;
				}
			}
		}
	}
}