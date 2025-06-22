using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    public Transform pointA, pointB;
    public int Speed;
    private Vector3 currentTarget;
    private SpriteRenderer sr;


    void Start() {
        sr=GetComponent<SpriteRenderer>();
    }
    void Update() {
        if (transform.position == pointA.position) {
            currentTarget=pointB.position;
            sr.flipX = false;
        }
        else if (transform.position == pointB.position) {
            currentTarget=pointA.position;
            sr.flipX = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, Speed*Time.deltaTime);
    }
}