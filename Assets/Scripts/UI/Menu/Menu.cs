using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] protected GameObject _panel;
    
    protected void OnOpenPanel()
    {
        _panel.SetActive(true);
        Time.timeScale = 0;
    }
    
    protected void OnClosePanel()
    {
        _panel.SetActive(false);
        Time.timeScale = 1;
    }
}
