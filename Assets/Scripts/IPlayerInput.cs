using UnityEngine;

public interface IPlayerInput
{
    public float getHorizontal();

    public bool jumpclick();

    public bool checkground();
}