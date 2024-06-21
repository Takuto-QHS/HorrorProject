using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectGroup : MonoBehaviour
{
    /// <summary>
    /// Buttonグループ
    /// </summary>
    [SerializeField]
    private Button btnStart;
    [SerializeField]
    private Button btnOption;
    [SerializeField]
    private Button btnCredit;
    [SerializeField]
    private Button btnEnd;
    [Space(10)]

    /// <summary>
    /// StartButton
    /// </summary>
    [SerializeField]
    private Fungus.Flowchart flowchart = null;
    [SerializeField]
    private string strMessage = null;
    [Space(10)]

    /// <summary>
    /// OptionButton
    /// </summary>
    [SerializeField]
    private GameObject dialogOption;

    void Start()
    {
        btnStart.onClick.AddListener(OnStart);
        btnOption.onClick.AddListener(OnActiveOption);
        btnCredit.onClick.AddListener(OnCredit);
        btnEnd.onClick.AddListener(OnEnd);
    }

    void OnStart()
    {
        // Fungusの機能を使用してフェード＆シーン遷移
        flowchart.SendFungusMessage(strMessage);
    }
    void OnActiveOption()
    {
        dialogOption.SetActive(true);
    }
    void OnCredit()
    {

    }
    void OnEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }
}
