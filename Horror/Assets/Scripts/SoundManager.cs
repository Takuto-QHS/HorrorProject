using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using Cysharp.Threading.Tasks;

public class SoundManager : MonoBehaviour
{
    static public SoundManager soundManager;

    [SerializeField]
    AudioMixer audioMixer;

    /// <summary>
    /// BGM変数
    /// </summary>
    static string _strBGMName = "BGM Object";
    [SerializeField]
    AudioMixerGroup bgmGroup;
    GameObject parentObjectBGM;
    AudioSource audioSourceBGM;

    /// <summary>
    /// SE変数
    /// </summary>
    [SerializeField]
    AudioMixerGroup seGroup;
    static string _strSEName = "SE Object";
    GameObject parentObjectSE;

    void Awake()
    {
        soundManager = this;
    }

    void Start()
    {
        // BGM準備
        parentObjectBGM = new GameObject();
        parentObjectBGM.name = _strBGMName;
        parentObjectBGM.transform.SetParent(this.gameObject.transform);
        
        // BGMAudioSource
        audioSourceBGM = parentObjectBGM.AddComponent<AudioSource>();
        audioSourceBGM.outputAudioMixerGroup = bgmGroup;
        audioSourceBGM.loop = true;
        audioSourceBGM.spatialBlend = 0;

        // SE準備
        parentObjectSE = new GameObject();
        parentObjectSE.name = _strSEName;
        parentObjectSE.transform.SetParent(this.gameObject.transform);
    }

    public AudioMixer GetAudioMixer() { return audioMixer; }

    /// <summary>
    /// BGM
    /// </summary>
    public void PlayBGM(AudioClip clip = null)
    {
        if (clip != null) audioSourceBGM.clip = clip;
        audioSourceBGM.Play();
    }

    public void PauseBGM()
    {
        audioSourceBGM.Pause();
    }

    public void StopBGM()
    {
        audioSourceBGM.Stop();
    }

    public async UniTask PlayFadeInBGM(AudioClip clip = null,float fadeDuration = 2.0f)
    {
        audioSourceBGM.volume = 0.0f;
        PlayBGM(clip);

        float elapsedTime = 0.0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            audioSourceBGM.volume = Mathf.Lerp(0.0f, 1.0f, elapsedTime / fadeDuration);
            await UniTask.Yield(); // フレームを待機
        }

        audioSourceBGM.volume = 1.0f;
    }

    public async UniTask StopFadeOutBGM(float fadeDuration = 2.0f)
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            audioSourceBGM.volume = Mathf.Lerp(1.0f, 0.0f, elapsedTime / fadeDuration);
            await UniTask.Yield(); // フレームを待機
        }

        audioSourceBGM.volume = 0.0f;
        audioSourceBGM.Stop();
    }

    /// <summary>
    /// SE
    /// </summary>
    public void PlaySE(AudioClip clip,float spatialBlend)
    {
        GameObject audioOBJ = Instantiate(parentObjectSE, parentObjectSE.transform);
        AudioSource audioSourceSe = audioOBJ.AddComponent<AudioSource>();
        audioSourceSe.outputAudioMixerGroup = seGroup;
        audioSourceSe.spatialBlend = spatialBlend;
        audioSourceSe.clip = clip;
        audioSourceSe.Play();

        // 鳴り終わりでDestroy
    }

    public void PauseSE()
    {
        audioSourceBGM.Pause();
    }
}
