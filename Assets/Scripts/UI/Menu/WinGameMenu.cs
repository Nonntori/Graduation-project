using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGameMenu : Menu
{
    [SerializeField] private Player _player;
    [SerializeField] private string _levelName;

    private void OnEnable()
    {
        _player.Won += OnWon;
    }

    private void OnDisable()
    {
        _player.Won -= OnWon;
    }

    public void OnWon()
    {
        OnOpenPanel();
    }
    
    public void Exit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(_levelName);
        Time.timeScale = 1;
    }
}
