using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class GameManager : MonoBehaviour
{
    static public GameManager gameManager;

    [SerializeField]
    private FirstPersonController playerCtr;

    private void Awake()
    {
        if(GameManager.gameManager != null)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
    }

    public void LockPlayer()
    {
        if (!playerCtr) return;
        playerCtr.enabled = false;
    }

    public void UnLockPlayer()
    {
        if (!playerCtr) return;
        playerCtr.enabled = true;
    }

    public void ShowCursol(bool isCursol)
    {
        Cursor.lockState = (isCursol) ? CursorLockMode.None : Cursor.lockState = CursorLockMode.Locked;
    }
}
