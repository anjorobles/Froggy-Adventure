using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orange : MonoBehaviour
{
    private bool isCollected = false;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            anim.SetBool("isCollected", true);  
            DestroyOrange();
            GetComponent<Collider2D>().enabled = false;
        }
    }
    private void DestroyOrange()
    {
        Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
    }

}
