using UnityEngine;

public class PauseMenu : Menu
{
    public void OpenPanel()
    {
        OnOpenPanel();
    }
    
    public void ClosePanel()
    {
        OnClosePanel();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
