using UnityEngine;
using System.IO;
using TMPro;

public class InputField : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    private void Start()
    {
        LoadLastName();
    }

    public void SaveLastName()
    {
        BestResultData lastName = new BestResultData();
        lastName._name = gameObject.GetComponent<TextMeshProUGUI>().text;
        string json = JsonUtility.ToJson(lastName);
        File.WriteAllText(Application.persistentDataPath + $"/LastName.json", json);
    }

    public void LoadLastName()
    {
        string path = Application.persistentDataPath + $"/LastName.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestResultData playerLastName = JsonUtility.FromJson<BestResultData>(json);
            _inputField.text = playerLastName._name;
        }
    }
}