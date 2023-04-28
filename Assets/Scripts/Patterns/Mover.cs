using UnityEngine;

public class Mover : MonoBehaviour
{
    public Vector3 target;
    public float speed = 2f;

    // Update is called once per frame
    private void Update()
    {
        float time = Time.deltaTime * speed;

        //check distance between target and me
        float distance = Vector3.Distance(transform.position, target);
        Debug.Log("distance "+distance);
        //check if distance is greater than 1
        if (distance > 1)
        {
            Vector3 dir = target - transform.position;
            

            transform.position += dir * time;
        }
    }
} 