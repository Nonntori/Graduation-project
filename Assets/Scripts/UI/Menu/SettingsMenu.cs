using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : Menu
{
  [SerializeField] private AudioSource _attackSound;
  [SerializeField] private Slider _attackSlider;
  [SerializeField] private AudioSource _runningSound;
  [SerializeField] private Slider _runningSlider;
  [SerializeField] private AudioSource _jumpedSound;
  [SerializeField] private Slider _jumpedSlider;
  [SerializeField] private AudioSource _musicSound;
  [SerializeField] private Slider _musicSlider;

  public void OpenPanel()
  {
    OnOpenPanel();
  }
    
  public void ClosePanel()
  {
    OnClosePanel();
  }
  
  public void AttackVolume()
  {
    _attackSound.volume = _attackSlider.value;
  }
  
  public void RunningVolume()
  {
    _runningSound.volume = _runningSlider.value;
  }
  
  public void JumpedVolume()
  {
    _jumpedSound.volume = _jumpedSlider.value;
  }
  
  public void MusicVolume()
  {
    _musicSound.volume = _musicSlider.value;
  }
}
