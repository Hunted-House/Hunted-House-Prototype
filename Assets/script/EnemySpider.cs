using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpider : MonoBehaviour
{
  private Animator anim;
  private SpriteRenderer spriteRenderer;
  private float alpha = 0f;
  private float alphaFadeTimer = 0;
  private bool isAppearing = false;
  private bool dieWhenFullyAppeared = false;

  // Start is called before the first frame update
  void Start()
  {
    anim = GetComponent<Animator>();
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

  void Update()
  {
    if (alphaFadeTimer < 0.03f)
    {
      alphaFadeTimer += Time.deltaTime;
    }
    else
    {
      alphaFadeTimer = 0;

      if (isAppearing)
      {
        if (alpha < 1f)
        {

          alpha += 0.2f;
        }
        else
        {
          alpha = 1f;
          isAppearing = false;
        }
      }
      else if (!dieWhenFullyAppeared)
      {
        if (alpha > 0f)
        {

          alpha -= 0.05f;
        }
        else
        {
          alpha = 0f;
        }
      }
    }

    if (spriteRenderer.color.a != alpha)
    {
      spriteRenderer.color = new Color(1f, 1f, 1f, alpha);
    }

    if (dieWhenFullyAppeared && alpha == 1f)
    {
        anim.Play("die");
        Destroy(gameObject, 0.5f);
    }
  }

  // on mouse down, play the animation and destroy the object after fully fading in
  void OnMouseDown()
  {
    isAppearing = true;
    dieWhenFullyAppeared = true;
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Echo"))
    {
      isAppearing = true;
    }
  }
}
