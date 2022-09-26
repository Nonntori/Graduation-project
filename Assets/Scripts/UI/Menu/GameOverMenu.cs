using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : Menu
{
    [SerializeField] private Player _player;
    [SerializeField] private AudioSource _backgroundSound;
    [SerializeField] private string _levelName;
    [SerializeField] private Animator _animator;
    
    private Coroutine _openLooseGameScreen;
    
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
        if (_openLooseGameScreen != null)
            return;

        _openLooseGameScreen = StartCoroutine(OpenLooseGameScreen());
        _backgroundSound.Stop();
    }
    
    private IEnumerator OpenLooseGameScreen()
    {
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0).Length);
        
        OnOpenPanel();
    }
}
