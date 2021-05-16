using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{

     public GameObject ball;

    public GameObject arCamera;

       public void shootButton()
            {
                RaycastHit hit;
                if(Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
                {
                    GameObject newBall = Instantiate(ball,hit.point,Quaternion.LookRotation(hit.normal));
                    Rigidbody rb= newBall.GetComponent<Rigidbody>();
                    rb.AddForce(5000*arCamera.transform.forward);
                }
            }

}
/* public void ShootBall()
{
  GameObject newBall = Instantiate<GameObject>(ballPrefab);
  theball.transform.position = Camera.main.transform.position;
  RigidBody rb = newBall.GetComponent<RigidBody>();
  rb.AddForce(5000 * Camera.main.transform.forward);
} */