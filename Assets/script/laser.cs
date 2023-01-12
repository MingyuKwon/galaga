using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    Rigidbody2D laserRigidBody;
    float speed;
    float lifeTime;
    void Awake() 
    {
        laserRigidBody = GetComponent<Rigidbody2D>();
    }
    void Start() {
        
    }

    public void SetVelocity(float veloc)
    {
        laserRigidBody.velocity = new Vector2(0f, veloc);
    }

    public void SetLifeTime(float time)
    {

    }
}
