using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Button playButton;

    public TextMeshProUGUI highScoreText;

    public Button musicButton;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;

    public Button soundButton;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    private void Start()
    {
        SetMusicSprite();
        SetSoundSprite();

        SetHighScoreText();

        InitializeButton();
    }

    private void InitializeButton()
    {
        if (playButton != null)
        {
            playButton.onClick.RemoveAllListeners();
            playButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(1);
            });
        }

        if (musicButton != null)
        {
            musicButton.onClick.RemoveAllListeners();
            musicButton.onClick.AddListener(() =>
            {
                if (PlayerPrefs.GetFloat("MusicVolume") == 0)
                {
                    AudioManager.instance.OnMusic();
                    SetMusicSprite();
                }
                else
                {
                    AudioManager.instance.OffMusic();
                    SetMusicSprite();
                }
            });
        }

        if (soundButton != null)
        {
            soundButton.onClick.RemoveAllListeners();
            soundButton.onClick.AddListener(() =>
            {
                if (PlayerPrefs.GetFloat("SoundVolume") == 0)
                {
                    AudioManager.instance.OnSound();
                    SetSoundSprite();
                }
                else
                {
                    AudioManager.instance.OffSound();
                    SetSoundSprite();
                }
            });
        }
    }

    private void SetSoundSprite()
    {
        if (PlayerPrefs.GetFloat("SoundVolume") == 0)
        {
            soundButton.GetComponent<Image>().sprite = soundOffSprite;
        }
        else
        {
            soundButton.GetComponent<Image>().sprite = soundOnSprite;
        }
    }

    private void SetMusicSprite()
    {
        if (PlayerPrefs.GetFloat("MusicVolume") == 0)
        {
            musicButton.GetComponent<Image>().sprite = musicOffSprite;
        }
        else
        {
            musicButton.GetComponent<Image>().sprite = musicOnSprite;
        }
    }

    private void SetHighScoreText()
    {
        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore");
    }
}
