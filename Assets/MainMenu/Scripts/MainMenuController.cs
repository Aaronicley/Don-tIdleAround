using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private UIDocument _UIDocument;
    private Button _Button;
    private Button _ButtonQuit;
    private List<Button> _menuButtons;

    [SerializeField] AudioSource _ButtonSound;
    [SerializeField] private string _StartLevel;

    private void Awake()
    {
        _ButtonSound = GetComponent<AudioSource>();
        _UIDocument = GetComponent<UIDocument>();
        _Button = _UIDocument.rootVisualElement.Q("Play") as Button;
        _Button.RegisterCallback<ClickEvent>(OnPlayGameClick);
        _ButtonQuit = _UIDocument.rootVisualElement.Q("Quit") as Button;
        _ButtonQuit.RegisterCallback<ClickEvent>(OnQuitGameClick);

        _menuButtons = _UIDocument.rootVisualElement.Query<Button>().ToList();
        for(int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].RegisterCallback<ClickEvent>(OnAllButtonClick);
        }
    }
    private void OnDisable()
    {
        _Button.UnregisterCallback<ClickEvent>(OnPlayGameClick);
        for (int i = 0; i < _menuButtons.Count; i++)
        {
            _menuButtons[i].UnregisterCallback<ClickEvent>(OnAllButtonClick);
        }
    }
    private void OnPlayGameClick(ClickEvent evt)
    {
        SceneManager.LoadScene(_StartLevel);
    }

    private void OnQuitGameClick(ClickEvent evt)
    {
        Debug.Log("Quit Game");
    }
    private void OnAllButtonClick(ClickEvent evt)
    {
        _ButtonSound.Play();
    }
        

}
