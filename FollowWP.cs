using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    public GameObject[] waypoints;
    int currentWP = 0;
    public int speed = 10;
    public int rotSpeed = 3;
    public GameObject tracker;

    // Start is called before the first frame update
    void Start()
    {
        tracker = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        DestroyImmediate(tracker.GetComponent<Collider>());
        tracker.transform.position = this.transform.position;
        tracker.transform.rotation = this.transform.rotation;
        tracker.GetComponent<MeshRenderer>().enabled = false;
    }

    void ProgressTracker()
    {
        if (Vector3.Distance(tracker.transform.position, this.transform.position) > 10) return;
            if (Vector3.Distance(waypoints[currentWP].transform.position, tracker.transform.position) < 3)
            currentWP++;
        if (currentWP >= waypoints.Length)
            currentWP = 0;
        tracker.transform.Translate(0, 0, (speed+3) * Time.deltaTime);
        tracker.transform.LookAt(waypoints[currentWP].transform);
    }

    // Update is called once per frame
    void Update()
    {
        ProgressTracker();
        Quaternion lookAt = Quaternion.LookRotation(tracker.transform.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(transform.rotation, lookAt, rotSpeed * Time.deltaTime);
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
