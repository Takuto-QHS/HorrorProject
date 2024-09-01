using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Fungus;

public class GameOver : MonoBehaviour
{
    /// <summary>
    /// 1.ゲームオーバーシーンに移動する前にbuckSceneName変数にシーン名をセット
    ///     ※GameOver.buckSceneName = SceneManager.GetActiveScene().name;
    /// 2.ゲームオーバーシーンに移動
    /// 3.Start関数でSE鳴り終わり時にUIを出す
    /// 4.どちらかのボタンを押す事でシーンを移動
    /// </summary> 

    const string titleSceneName = "00.Title";   // タイトルシーン名
    static public string buckSceneName;                // 戻る際のシーン名

    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    Canvas gameOverCanvas; 

    async void Start()
    {
        Init();

        audioSource.Play();
        await UniTask.WaitWhile(() => audioSource.isPlaying);   // SE鳴り終わり時に抜ける
        GameManager.ShowCursol(true);
        gameOverCanvas.gameObject.SetActive(true);              // ゲームオーバーUIを出す
    }

    /// <summary>
    /// 初期化
    /// </summary>
    void Init()
    {
        gameOverCanvas.gameObject.SetActive(false);
    }

    /// <summary>
    /// ボタン用関数
    /// </summary>
    public void ChangeReChallengeScene()
    {
        ReChallengeScene();
    }

    public async UniTaskVoid ReChallengeScene()
    {
        FungusManager.Instance.CameraManager.Fade(1.0f, 2.0f, null);            // Fungusのフェードを呼ぶ
        await UniTask.Delay(2000, delayTiming: PlayerLoopTiming.FixedUpdate);   // その間待つ
        GameManager.ChangeSceneAsync(buckSceneName);                                 // シーンチェンジ
        Debug.Log(buckSceneName + "に再チャレンジ");
    }

    /// <summary>
    /// ボタン用関数
    /// </summary>
    public void ChangeBackTitleScene()
    {
        GameManager.ChangeSceneAsync(titleSceneName);
        Debug.Log(titleSceneName + "に戻る");
    }
}
