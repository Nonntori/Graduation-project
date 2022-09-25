using UnityEngine;

public class HelpMenu : Menu
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        OnOpenPanel();
    }
    
    public void ClosePanel()
    {
        OnClosePanel();
    }
}
