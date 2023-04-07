using UnityEngine;
using System.Collections;

// A very simplistic car driving on the x-z plane.

public class Drive : MonoBehaviour
{

    Vector2 right = new Vector2(1, 0);
    Vector2 up = new Vector2(0, 1);
    Vector3 posi = new Vector3();

     public float speed = 0.1f;


    private void Start()
    {
        posi = this.transform.position;
    }


    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            Move(up);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Move(-up);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Move(-right);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Move(right);
        }


        this.transform.position = posi;


    }


  public void Move(Vector2 s)
    {
        posi.x += s.x * speed;
        posi.y += s.y * speed;
    }
  
}