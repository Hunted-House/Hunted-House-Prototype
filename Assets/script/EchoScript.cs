using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoScript : MonoBehaviour
{
  public LineRenderer circleRenderer;
  public CircleCollider2D circleCollider;
  public Vector2 direction;
  public float moveSpeed = 1;
  public float scaleSpeed = 1;
  public float fadeSpeed = 0;
  public float alpha = 1;

  public float radius = 0;
  void Start()
  {
    DrawCircle(100, radius);
  }

  void Update()
  {
    radius += scaleSpeed * Time.deltaTime;
    DrawCircle(100, radius);
    this.circleCollider.radius = radius;

    transform.position += new Vector3(direction.x, direction.y, 0) * moveSpeed * Time.deltaTime;

    alpha -= fadeSpeed * Time.deltaTime;
    Color color = circleRenderer.startColor;
    Color newColor = new Color(color.r, color.g, color.b, alpha);
    circleRenderer.startColor = newColor;
    circleRenderer.endColor = newColor;

    if (alpha <= 0)
    {
      Destroy(gameObject);
    }
  }

  void DrawCircle(int steps, float radius)
  {
    circleRenderer.positionCount = steps;
    for (int currentStep = 0; currentStep < steps; currentStep++)
    {
      float circumferenceProgress = (float)currentStep / (steps - 1);
      float currentRadian = circumferenceProgress * 2 * Mathf.PI;
      float xScaled = Mathf.Cos(currentRadian);
      float yScaled = Mathf.Sin(currentRadian);
      float x = xScaled * radius;
      float y = yScaled * radius;
      Vector3 currentPosition = new Vector3(x, y, 0);
      circleRenderer.SetPosition(currentStep, currentPosition);
    }
  }
}
