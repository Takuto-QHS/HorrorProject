using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�J�������王�_�̐�Ƀ��C���΂���
/// IPlayerSelectRayReceive���p�����ɂ���X�N���v�g������Ă���
/// �e�^�C�~���O�Ŋ֐���@��
/// 
/// ��Physics Raycaster���g�������������ACursor.lockState��Locked�ɂ����
/// �@Physics Raycaster���g���Ȃ��Ȃ�׎��삵�Ă��܂��B
/// </summary>
public class PlayerSelectRay : MonoBehaviour
{
    public List<IPlayerSelectRayReceive> selectReceiveObj = new List<IPlayerSelectRayReceive>();

    private Camera playerCamera;
    [SerializeField]
    private float distance = 1.0f;

    // Update is called once per frame
    void Update()
    {
        // ����
        playerCamera = gameObject.GetComponent<Camera>();
        Vector3 rayStartPosition = playerCamera.transform.position;
        Vector3 rayDirection = playerCamera.transform.forward.normalized;
        RaycastHit raycastHit;

        // Ray���΂��iout raycastHit ��Hit�����I�u�W�F�N�g���擾����j
        bool isHit = Physics.Raycast(rayStartPosition, rayDirection, out raycastHit, distance);
        Debug.DrawRay(rayStartPosition, rayDirection * distance, Color.red);

        // �����q�b�g������
        if (isHit)
        {
            IPlayerSelectRayReceive[] tempReceive = raycastHit.collider.gameObject.GetComponents<IPlayerSelectRayReceive>();

            // �q�b�g����Obj�Ɏ�M���X�N���v�g��1�ȏ゠�邩
            if(tempReceive.Length != 0)
            {
                foreach(IPlayerSelectRayReceive receive in tempReceive)
                {
                    // ���q�b�g��
                    if (selectReceiveObj.Count == 0)
                    {
                        receive.FirstHit();
                        selectReceiveObj.Add(receive);
                    }
                    else
                    {
                        // �q�b�g��
                        receive.HitNow();
                    }
                }
            }
            else
            {
                // �ێ�����receiveObj������ꍇ
                if (selectReceiveObj.Count != 0)
                {
                    foreach (IPlayerSelectRayReceive receive in selectReceiveObj)
                    {
                        receive.NotHit();
                    }
                    selectReceiveObj.Clear();
                }
            }
        }
        // �����q�b�g���Ȃ�������
        else
        {
            // �ێ�����receiveObj������ꍇ
            if (selectReceiveObj.Count != 0)
            {
                foreach (IPlayerSelectRayReceive receive in selectReceiveObj)
                {
                    receive.NotHit();
                }
                selectReceiveObj.Clear();
            }
        }
    }
}
