using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private const string StartTransition = nameof(StartTransition);
    
    [SerializeField] private Animator _animator;
    [SerializeField] private string _nextLevelName;

    private Coroutine _loadScene;

    public void LoadNextLevel()
    {
        if (_loadScene != null)
            return;

        _loadScene = StartCoroutine(LoadScene(_nextLevelName));
    }

    private IEnumerator LoadScene(string sceneName)
    {
        _animator.SetTrigger(StartTransition);

        yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0).Length);

        SceneManager.LoadScene(sceneName);
    }
}
