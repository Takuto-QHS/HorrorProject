using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーカメラから視点の先にレイを飛ばして
/// IPlayerSelectRayReceiveが継承元にあるスクリプトを取ってきて
/// 各タイミングで関数を叩く
/// 
/// ※Physics Raycasterを使いたい所だが、Cursor.lockStateをLockedにすると
/// 　Physics Raycasterが使えなくなる為自作しています。
/// </summary>
public class PlayerSelectRay : MonoBehaviour
{
    public IPlayerSelectRayReceive selectReceiveObj;

    private Camera playerCamera;
    [SerializeField]
    private float distance = 1.0f;

    // Update is called once per frame
    void Update()
    {
        // 準備
        playerCamera = gameObject.GetComponent<Camera>();
        Vector3 rayStartPosition = playerCamera.transform.position;
        Vector3 rayDirection = playerCamera.transform.forward.normalized;
        RaycastHit raycastHit;

        // Rayを飛ばす（out raycastHit でHitしたオブジェクトを取得する）
        bool isHit = Physics.Raycast(rayStartPosition, rayDirection, out raycastHit, distance);
        Debug.DrawRay(rayStartPosition, rayDirection * distance, Color.red);

        // 何かヒットした時
        if (isHit)
        {
            IPlayerSelectRayReceive tempReceive = raycastHit.collider.gameObject.GetComponent<IPlayerSelectRayReceive>();

            // 最初にヒットしたObjに受信側スクリプトがあるか
            if(tempReceive != null)
            {
                if (selectReceiveObj == null)
                {
                    tempReceive.FirstHit();
                    selectReceiveObj = tempReceive;
                }
                else
                {
                    // ヒット中
                    selectReceiveObj.HitNow();
                }
            }
            else
            {
                // 保持中のreceiveObjがある場合
                if (selectReceiveObj)
                {
                    selectReceiveObj.NotHit();
                    selectReceiveObj = null;
                }
            }
        }
        // 何もヒットしなかった時
        else
        {
            // 保持中のreceiveObjがある場合
            if (selectReceiveObj)
            {
                selectReceiveObj.NotHit();
                selectReceiveObj = null;
            }
        }
    }
}
