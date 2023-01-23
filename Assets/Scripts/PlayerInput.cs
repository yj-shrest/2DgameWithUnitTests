using UnityEngine;

public class PlayerInput : IPlayerInput
{
    public float getHorizontal()
    {
        return Input.GetAxis("Horizontal");
    }
    public bool jumpclick()
    {
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow)))
            return true;
        else
            return false;
    }
    public bool checkground()
    {
        return Physics2D.Raycast(Player.position, Vector2.down, .4f, LayerMask.GetMask("Ground"));
    }
}
