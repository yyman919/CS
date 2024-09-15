using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab;
    public GameObject branchPrefab;  // Add this line
    public float speed = 15f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirections = 0.05f;
    public float secondsBetweenAppleDrops = 1f;
    public float branchDropChance = 0.3f;  // 30% chance to drop a branch
    void Start()
    {
        Invoke("DropApple", 2f);
    }
    void Update()
    {

        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime * 10;
        transform.position = pos;


        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
        else if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }

    void DropApple()
    {
        GameObject dropObject;

        // Determine whether to drop an apple or a branch
        if (Random.value < branchDropChance)
        {
            dropObject = Instantiate<GameObject>(branchPrefab);
        }
        else
        {
            dropObject = Instantiate<GameObject>(applePrefab);
        }

        dropObject.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    //void FixedUpdate()
    //{
    //    if (Random.value < chanceToChangeDirections)
    //    {
    //        speed *= -1;
    //    }
    //}
}
