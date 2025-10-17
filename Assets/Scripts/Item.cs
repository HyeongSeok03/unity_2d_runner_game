using UnityEngine;

public class Item : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.life++;
            gameObject.SetActive(false);
            GameManager.Instance.UpdateLifeUI();
        }
    }
}
