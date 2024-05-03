using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using Cinemachine;
using UnityEngine.InputSystem;

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
        playerInput.moveInputForMovement = false;
        playerInput.cursorInputForLook = false;
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
}
