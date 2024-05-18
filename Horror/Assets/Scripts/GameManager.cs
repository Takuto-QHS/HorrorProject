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
    private FirstPersonController firstPersonCtr;           // プレイヤーの角度取得用

    [SerializeField]
    private FloorStateManagerTemplate floorStateManager;    // 進行度管理用

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
    }

    /// <summary>
    /// プレイヤーの操作をロック(受け付けない)
    /// </summary>
    public void LockPlayer()
    {
        if (!playerInput) return;
        playerInput.moveInputForMovement = false;
        playerInput.cursorInputForLook = false;
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
    /// UniTaskでシーン遷移＆遷移後にログ表示
    /// </summary>
    public async void ChangeScene(string sceneName)
    {
        await SceneManager.LoadSceneAsync(sceneName);       // シーンを裏でロードし、完了したら遷移
        Debug.Log("Scene変更：" + sceneName);               // 遷移後にログ表示
    }
}
