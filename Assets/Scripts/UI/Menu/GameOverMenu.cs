using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : Menu
{
    [SerializeField] private Player _player;
    [SerializeField] private AudioSource _backgroundSound;
    [SerializeField] private string _levelName;
    [SerializeField] private float _delayBeforeOpenLooseScreen;
    
    private float _elapsedTime = 0f;
    
    private void OnEnable()
    {
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
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
    
    private void OnDied()
    {
        StartCoroutine(OpenLooseGameScreen());
        _backgroundSound.Stop();
    }
    
    private IEnumerator OpenLooseGameScreen()
    {
        while (_elapsedTime < _delayBeforeOpenLooseScreen)
        {
            _elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        OnOpenPanel();
    }
}
