using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectGroup : MonoBehaviour
{
    /// <summary>
    /// Button�O���[�v
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
        // Fungus�̋@�\���g�p���ăt�F�[�h���V�[���J��
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
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
    }
}
