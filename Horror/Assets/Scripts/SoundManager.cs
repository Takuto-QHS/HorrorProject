using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    static public SoundManager soundManager;

    [SerializeField]
    AudioMixer audioMixer;

    /// <summary>
    /// BGMïœêî
    /// </summary>
    static string _strBGMName = "BGM Object";
    [SerializeField]
    AudioMixerGroup bgmGroup;
    GameObject parentObjectBGM;
    AudioSource audioSourceBGM;

    /// <summary>
    /// SEïœêî
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
        // BGMèÄîı
        parentObjectBGM = new GameObject();
        parentObjectBGM.name = _strBGMName;
        parentObjectBGM.transform.SetParent(this.gameObject.transform);
        
        // BGMAudioSource
        audioSourceBGM = parentObjectBGM.AddComponent<AudioSource>();
        audioSourceBGM.outputAudioMixerGroup = bgmGroup;
        audioSourceBGM.loop = true;
        audioSourceBGM.spatialBlend = 0;

        // SEèÄîı
        parentObjectSE = new GameObject();
        parentObjectSE.name = _strSEName;
        parentObjectSE.transform.SetParent(this.gameObject.transform);
    }

    public AudioMixer GetAudioMixer() { return audioMixer; }

    void BGM()
    {

    }

    void SE()
    {

    }
}
