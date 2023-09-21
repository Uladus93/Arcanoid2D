using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _numberOfLevel;
    [SerializeField] private Image _starsImage;
    [SerializeField] private Sprite[] _starsSprites = new Sprite[4];

    private LinksForButtons _parent;

    public void SetData(Progress progress, int indexOfButton)
    {
        _numberOfLevel.text = (indexOfButton + 1).ToString();
        _button.interactable = progress.IsOpened;
        _starsImage.sprite = _starsSprites[progress.StarsCount];
        _parent = transform.parent.gameObject.GetComponent<LinksForButtons>();
        GameObject playerPanel = _parent.PlayerPanel;
        GameObject ball = _parent.Ball;
        GameObject mainMenu = _parent.MainMenu;
        GameObject levelGenerator = _parent.LevelGenerator;
        GameObject backGround = _parent.Background;
        GameObject scrollWiew = _parent.ScrollWiew;
        GameObject playButton = _parent.PlayButton;
        GameObject pauseButton = _parent.PauseButton;
        GameObject userName = _parent.UserName;
        GameObject inputField = _parent.InputField;
        _button.onClick.AddListener(() =>
        {
            mainMenu.SetActive(false);
            levelGenerator.GetComponent<BricksGenerator>().LoadLevel(indexOfButton + 1);
            pauseButton.GetComponent<PauseManager>().ResumeGame();
            playerPanel.SetActive(true);
            ball.SetActive(true);
            playerPanel.transform.position = new Vector3(0, -10, playerPanel.transform.position.z);
            ball.transform.position = new Vector3(0, -9, ball.transform.position.z);
            playerPanel.GetComponent<PlayerPanel>().NewLifesAndFoil();
            backGround.SetActive(true);
            scrollWiew.SetActive(false);
            playButton.SetActive(true);
            playerPanel.GetComponentInChildren<UserName>().SetUserName(userName.GetComponent<TextMeshProUGUI>().text);
            inputField.GetComponent<InputField>().SaveLastName();
        });
    }

    public void SetIsOpened()
    {
        _button.interactable = true;
    }

    public void SetStars(int result)
    {
        if (result <= 200)
        {
            _starsImage.sprite = _starsSprites[1];
        }
        else if (result <= 300 && result > 200)
        {
            _starsImage.sprite = _starsSprites[2];
        }
        else if (result  > 300)
        {
            _starsImage.sprite = _starsSprites[3];
        }
    }
}