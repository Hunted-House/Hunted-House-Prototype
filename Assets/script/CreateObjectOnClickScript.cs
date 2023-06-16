using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjectOnClick : MonoBehaviour
{
  public GameObject objectToCreate;

  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      clickPosition.z = 0;

      Instantiate(objectToCreate, clickPosition, Quaternion.identity);
    }
  }
}
