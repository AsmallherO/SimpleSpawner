using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public bool isGo;
    public float speed;
    public float distance;
    private void Update()
    {
        if (isGo)
        {
            Move(speed);
            if (transform.position.z >= distance)
            {
                isGo = false;
                this.gameObject.SetActive(false);
            }
        }
    }
    public void Move(float speed)
    {
        Vector3 temp = transform.position;
        temp.z += speed * Time.deltaTime;
        transform.position = temp;
    }
}
