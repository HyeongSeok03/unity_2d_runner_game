using UnityEngine;

public class WallCheck : MonoBehaviour
{
    public bool isWall { get; private set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Terrain"))
            isWall = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Terrain"))
            isWall = false;
    }
}
