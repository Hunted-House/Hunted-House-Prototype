using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjectOnClick : MonoBehaviour
{
  public GameObject objectToCreate;

  void Update()
  {
    // check if the left mouse button is pressed and its not in an enemy spider collider
    if (Input.GetMouseButtonDown(0) && !Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
    {
      // get the mouse position
      Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      clickPosition.z = 0;

      // create the object
      Instantiate(objectToCreate, clickPosition, Quaternion.identity);
    }

    // if (Input.GetMouseButtonDown(0))
    // {
    //   Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //   clickPosition.z = 0;

    //   Instantiate(objectToCreate, clickPosition, Quaternion.identity);
    // }
  }
}
