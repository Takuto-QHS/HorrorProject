using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using Cinemachine;
using UnityEngine.InputSystem;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameManager gameManager;

    public GameObject playerCupsule;                        // プレイヤー本体

    [SerializeField]
    private CinemachineBrain cinemachineBrain;              // カメラ移動等のアクセス用

    private StarterAssetsInputs playerInput;                // プレイヤーの操作取得用
    private FirstPersonController firstPersonCtr;           // プレイヤーの角度&インプット取得用

    [SerializeField]
    private FloorStateManagerTemplate floorStateManager;    // 進行度管理用

    [SerializeField]
    private GameObject prefabPauseManager;
    [SerializeField]
    private PauseManager pauseManager = null;                      // ポーズ画面用

    private void Awake()
    {
        if(GameManager.gameManager != null)
        {
            Destroy(this);
            return;
        }
        gameManager = this;

        if(playerCupsule)
        {
            playerInput = playerCupsule.GetComponent<StarterAssetsInputs>();
            firstPersonCtr = playerInput.GetComponent<FirstPersonController>();
        }

        if(!pauseManager)
        {
            if (!prefabPauseManager) return;
            pauseManager = Instantiate(prefabPauseManager,this.gameObject.transform).GetComponent<PauseManager>();
        }
    }

    /// <summary>
    /// プレイヤーの操作をロック(受け付けない)
    /// </summary>
    public void LockPlayer()
    {
        if (!playerInput) return;
        playerInput.moveInputForMovement = false;   // インプット無効化
        playerInput.cursorInputForLook = false;     // インプット無効化
        firstPersonCtr.ResetMoveLookValue();        // Update関数で勝手に動かないようにする
    }

    /// <summary>
    /// プレイヤーの操作をアンロック(受け付ける)
    /// </summary>
    public void UnLockPlayer()
    {
        if (!playerInput) return;
        playerInput.moveInputForMovement = true;
        playerInput.cursorInputForLook = true;
    }

    public CinemachineBrain GetCinemachineBrain()
    {
        return cinemachineBrain;
    }

    public FirstPersonController GetFirstPersonCtr()
    {
        return firstPersonCtr;
    }

    /// <summary>
    /// 進行度を1つ進める
    /// </summary>
    public void OneStepProgressing()
    {
        floorStateManager.OneStepProgressing();
    }

    /// <summary>
    /// FlowChart用呼び出しシーン遷移関数
    /// </summary>
    public void ChangeScene(string sceneName)
    {
        ChangeSceneAsync(sceneName);
    }

    /// <summary>
    /// UniTaskでシーン遷移＆遷移後にログ表示
    /// </summary>
    static public async void ChangeSceneAsync(string sceneName)
    {
        await SceneManager.LoadSceneAsync(sceneName);       // シーンを裏でロードし、完了したら遷移
        Debug.Log("Scene変更：" + sceneName);               // 遷移後にログ表示
    }

    /// <summary>
    /// カーソルのオンオフ
    /// </summary>
    static public void ShowCursol(bool isCursol)
    {
        Cursor.lockState = (isCursol) ? CursorLockMode.None : Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// ゲーム終了
    /// </summary>
    static public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }

    /// <summary>
    /// ポーズ画面起動
    /// </summary>
    public void BootPause()
    {
        pauseManager.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        firstPersonCtr.ResumeGame();
    }
}
