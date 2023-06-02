using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 10f;
    Rigidbody2D r2bd;
    void Start()
    {
        r2bd = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)){
            r2bd.AddTorque(torqueAmount);
        } 
        else if(Input.GetKey(KeyCode.RightArrow)){
            r2bd.AddTorque(-torqueAmount);
        }
    }
}
