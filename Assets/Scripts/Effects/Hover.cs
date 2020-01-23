using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public float offset = 15;
    public float frequency = 1;
    private float startY, startZ = 0;
    private float totalTime = 0;
    
    void Start()
    {
        startY = this.transform.position.y;
        startZ = this.transform.position.z;
    }
    
    void Update() {
        totalTime += Time.deltaTime * frequency;
        float y = startY  + offset * Mathf.Sin(totalTime) ;
        this.transform.position = new Vector3(this.transform.position.x, y, this.transform.position.z);
    }
}
