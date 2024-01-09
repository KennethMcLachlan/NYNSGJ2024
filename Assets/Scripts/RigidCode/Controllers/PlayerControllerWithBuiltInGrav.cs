using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerControllerWithBuiltInGrav", menuName = "InputController/PlayerController")]
public class PlayerControllerWithBuiltInGrav : InputController
{
    public override bool RetrieveJumpInput()
    {
        Debug.Log("your Jumping: " + Input.GetButtonDown("Jump"));
        return Input.GetButtonDown("Jump");
    }

    public override float RetrieveMoveInput()
    {
        return Input.GetAxisRaw("Horizontal");
        
    }
}
