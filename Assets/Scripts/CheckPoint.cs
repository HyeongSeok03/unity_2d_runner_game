using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    Animator anim;
    bool isChecked;
    void Awake()
    {
        anim = GetComponent<Animator>();
        isChecked = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isChecked)
        {
            isChecked = true;
            anim.SetTrigger("Flaging");
            GameManager.Instance.recentCheckPointPos = transform.position;
        }
    }
}
