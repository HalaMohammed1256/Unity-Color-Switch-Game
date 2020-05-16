using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalBar : MonoBehaviour
{
    public float rangeMax = 15;
    public float direction = -1;
    public float initialPositionX;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        initialPositionX = this.transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector2(this.transform.position.x + (direction * Time.deltaTime * speed), this.transform.position.y);
        if (this.transform.position.x > initialPositionX + rangeMax)
        {
            direction = -1;
        }
            if(this.transform.position.x < initialPositionX- rangeMax){
                direction = 1;
            }
    }
}
