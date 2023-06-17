using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpider : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // on mouse down, play the animation and destroy the object
    void OnMouseDown()
    {
        anim.Play("die");
        Destroy(gameObject, 0.5f);
    }
}
