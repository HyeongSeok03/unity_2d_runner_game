using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Player player;

    void Update()
    {
        if (!GameManager.Instance.isGameOver)
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1f, transform.position.z);
    }
}
