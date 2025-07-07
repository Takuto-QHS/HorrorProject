using Fungus;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class PauseManager : MonoBehaviour
{
    const string _strFlowchartTitle = "Title";
    const string _strOn = "ON";
    const string _strOff = "OFF";

    /// <summary>
    /// Buttonグループ
    /// </summary>
    [SerializeField]
    private Button btnResume;
    [SerializeField]
    private Button btnOption;
    [SerializeField]
    private Button btnTitle;

    private bool isShowCursol;
    [Space(10)]

    /// <summary>
    /// OptionButton
    /// </summary>
    [SerializeField]
    private GameObject dialogOption;

    [Header("SETTINGS")]
    [SerializeField]
    private TMP_Text txtFullscreen;
    [SerializeField]
    private Button btnFullscreen;

    [SerializeField]
    private TMP_Dropdown dropdownReso;
    private List<Resolution> listReso = new();

    [SerializeField]
    private Slider sliderMusic;
    [SerializeField]
    private Slider sliderSe;

    /// <summary>
    /// TitleButton
    /// </summary>
    [Header("TITLE")]
    [SerializeField]
    private Flowchart flowchart;
    [SerializeField]
    private Image clickGurdPanel;

    void Start()
    {
        btnResume.onClick.AddListener(OnResumeGame);
        btnOption.onClick.AddListener(OnActiveOption);
        btnTitle.onClick.AddListener(OnBackTitle);

        InitResolutions();
        clickGurdPanel.gameObject.SetActive(false);

        this.gameObject.SetActive(false);
    }

    void OnEnable()
    {
        Init();
    }

    void OnDisable()
    {
        Time.timeScale = 1;
    }

    void Init()
    {
        // 設定画面に入る際、ゲーム画面上でカーソルがOnだったかOffだったか保持してOn
        isShowCursol = (Cursor.lockState != CursorLockMode.Locked);
        GameManager.ShowCursol(true);

        Time.timeScale = 0;
        dialogOption.SetActive(false);
    }

    /// <summary>
    /// 各Button関数
    /// </summary>
    void OnResumeGame()
    {
        GameManager.ShowCursol(isShowCursol);
        GameManager.gameManager.ResumeGame();
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    void OnActiveOption()
    {
        if(dialogOption.activeSelf)
        {
            dialogOption.SetActive(false);
            return;
        }

        InitSettings();
        dialogOption.SetActive(true);
    }

    void OnBackTitle()
    {
        Time.timeScale = 1;
        GameManager.gameManager.LockPlayer();
        clickGurdPanel.gameObject.SetActive(true);

        // Fungusの機能を使用してフェード＆シーン遷移
        flowchart.SendFungusMessage(_strFlowchartTitle);
    }

    /// <summary>
    /// Settings画面
    /// </summary>
    void InitSettings()
    {
        txtFullscreen.text = Screen.fullScreen ? _strOff : _strOn;
        btnFullscreen.onClick.AddListener(OnChangeFullScreen);

        // AudioMixerの各値をスライダーと同期
        SoundManager.soundManager.GetAudioMixer().GetFloat("BGMVolumeParam", out float bgmVolume);  // 値
        sliderMusic.value = bgmVolume;
        sliderMusic.onValueChanged.RemoveAllListeners();
        sliderMusic.onValueChanged.AddListener(SetMusicSliderValue);
        SoundManager.soundManager.GetAudioMixer().GetFloat("SEVolumeParam", out float seVolume);    // 値
        sliderSe.value = seVolume;
        sliderSe.onValueChanged.RemoveAllListeners();
        sliderSe.onValueChanged.AddListener(SetSeSliderValue);
        //sliderMusic.value = PlayerPrefs.GetFloat("MusicVolume");
        //sliderSe.value = PlayerPrefs.GetFloat("SeVolume");
    }

    void OnChangeFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        txtFullscreen.text = Screen.fullScreen ? _strOff : _strOn;
    }

    /// <summary>
    /// ドロップダウンに、ディスプレイが対応する解像度の一覧を作成しAddListenerする
    /// (現在のディスプレイ変更等でScreen.resolutions配列の数が変更するのか分からない為
    ///  resolutions配列にScreen.resolutions配列を移して対応)
    /// </summary>
    void InitResolutions()
    {
        // 初期化
        listReso.Clear();
        dropdownReso.ClearOptions();

        List<string> options = new();
        int index = 0;
        int currentIndex = 0;

        // Screen.resolutions配列をoptions配列に、現在の解像度をresolutions配列にAdd
        foreach (Resolution reso in Screen.resolutions)
        {
            if (Screen.width == reso.width && Screen.height == reso.height)
            {
                currentIndex = index;
            }

            listReso.Add(reso);
            options.Add(reso.width.ToString() + "x" + reso.height.ToString());
            index++;
        }

        dropdownReso.AddOptions(options);
        dropdownReso.value = currentIndex;
        dropdownReso.onValueChanged.AddListener((x) => SetResolution(listReso[x]));
    }
    void SetResolution(Resolution resolution)
    {
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    void SetMusicSliderValue(float volume)
    {
        SoundManager.soundManager.GetAudioMixer().SetFloat("BGMVolumeParam", volume);
        //PlayerPrefs.SetFloat("MusicVolume", sliderMusic.value);// 保存用
    }

    void SetSeSliderValue(float volume)
    {
        SoundManager.soundManager.GetAudioMixer().SetFloat("SEVolumeParam", volume);
        //PlayerPrefs.SetFloat("MusicVolume", sliderSe.value);  // 保存用
    }
}
