using System.Collections;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
#if UNITY_IOS || UNITY_ANDROID
    private PlayerMoovement pm;
    
    void Start()
    {
        pm = GameManager.GM.activePlayer.GetComponent<PlayerMoovement>();
    }

    public void MooveRight()
    {
        if (!pm.ISRight) pm.FlipCharacter();

        pm.horizontalMoove = pm.runSpeed;
    }

    public void MooveLeft()
    {
        if (pm.ISRight) pm.FlipCharacter();

        pm.horizontalMoove = -pm.runSpeed;
    }

    public void StopCharacter()
    {
        pm.horizontalMoove = 0f;
    }

    public void MakeJump()
    {
        pm.isJump = true;
    }
    public void StopJump()
    {
        pm.isJump = false;
    }
#endif
}
