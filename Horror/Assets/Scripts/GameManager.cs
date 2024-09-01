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

    public GameObject playerCupsule;                        // �v���C���[�{��

    [SerializeField]
    private CinemachineBrain cinemachineBrain;              // �J�����ړ����̃A�N�Z�X�p

    private StarterAssetsInputs playerInput;                // �v���C���[�̑���擾�p
    private FirstPersonController firstPersonCtr;           // �v���C���[�̊p�x�擾�p

    [SerializeField]
    private FloorStateManagerTemplate floorStateManager;    // �i�s�x�Ǘ��p

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
    /// �v���C���[�̑�������b�N(�󂯕t���Ȃ�)
    /// </summary>
    public void LockPlayer()
    {
        if (!playerInput) return;
        playerInput.moveInputForMovement = false;   // �C���v�b�g������
        playerInput.cursorInputForLook = false;     // �C���v�b�g������
        firstPersonCtr.ResetMoveLookValue();        // Update�֐��ŏ���ɓ����Ȃ��悤�ɂ���
    }

    /// <summary>
    /// �v���C���[�̑�����A�����b�N(�󂯕t����)
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
    /// �i�s�x��1�i�߂�
    /// </summary>
    public void OneStepProgressing()
    {
        floorStateManager.OneStepProgressing();
    }

    /// <summary>
    /// FlowChart�p�Ăяo���V�[���J�ڊ֐�
    /// </summary>
    public void ChangeScene(string sceneName)
    {
        ChangeSceneAsync(sceneName);
    }

    /// <summary>
    /// UniTask�ŃV�[���J�ځ��J�ڌ�Ƀ��O�\��
    /// </summary>
    static public async void ChangeSceneAsync(string sceneName)
    {
        await SceneManager.LoadSceneAsync(sceneName);       // �V�[���𗠂Ń��[�h���A����������J��
        Debug.Log("Scene�ύX�F" + sceneName);               // �J�ڌ�Ƀ��O�\��
    }

    /// <summary>
    /// �J�[�\���̃I���I�t
    /// </summary>
    static public void ShowCursol(bool isCursol)
    {
        Cursor.lockState = (isCursol) ? CursorLockMode.None : Cursor.lockState = CursorLockMode.Locked;
    }
}
