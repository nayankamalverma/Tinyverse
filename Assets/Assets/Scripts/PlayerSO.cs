using Assets.Scripts.Player;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "ScriptableObjects/PlayerSO")]
public class PlayerSO : ScriptableObject
{
    public PlayerView playerPrefab;
    public float initialHealth = 3;
    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;
    public float groundDistance = 0.4f;
    public float turnSmoothTime = 0.1f;
    public float fireCoolDownTime = 2f;
}
