using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Fungus;

public class GameOver : MonoBehaviour
{
    /// <summary>
    /// 1.�Q�[���I�[�o�[�V�[���Ɉړ�����O��buckSceneName�ϐ��ɃV�[�������Z�b�g
    ///     ��GameOver.buckSceneName = SceneManager.GetActiveScene().name;
    /// 2.�Q�[���I�[�o�[�V�[���Ɉړ�
    /// 3.Start�֐���SE��I��莞��UI���o��
    /// 4.�ǂ��炩�̃{�^�����������ŃV�[�����ړ�
    /// </summary> 

    const string titleSceneName = "00.Title";   // �^�C�g���V�[����
    static public string buckSceneName;                // �߂�ۂ̃V�[����

    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    Canvas gameOverCanvas; 

    async void Start()
    {
        Init();

        audioSource.Play();
        await UniTask.WaitWhile(() => audioSource.isPlaying);   // SE��I��莞�ɔ�����
        GameManager.ShowCursol(true);
        gameOverCanvas.gameObject.SetActive(true);              // �Q�[���I�[�o�[UI���o��
    }

    /// <summary>
    /// ������
    /// </summary>
    void Init()
    {
        gameOverCanvas.gameObject.SetActive(false);
    }

    /// <summary>
    /// �{�^���p�֐�
    /// </summary>
    public void ChangeReChallengeScene()
    {
        ReChallengeScene();
    }

    public async UniTaskVoid ReChallengeScene()
    {
        FungusManager.Instance.CameraManager.Fade(1.0f, 2.0f, null);            // Fungus�̃t�F�[�h���Ă�
        await UniTask.Delay(2000, delayTiming: PlayerLoopTiming.FixedUpdate);   // ���̊ԑ҂�
        GameManager.ChangeSceneAsync(buckSceneName);                                 // �V�[���`�F���W
        Debug.Log(buckSceneName + "�ɍă`�������W");
    }

    /// <summary>
    /// �{�^���p�֐�
    /// </summary>
    public void ChangeBackTitleScene()
    {
        GameManager.ChangeSceneAsync(titleSceneName);
        Debug.Log(titleSceneName + "�ɖ߂�");
    }
}
