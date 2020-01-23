using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakerEffect : MonoBehaviour {

    public float speed = 24, amount = 0.05f;
    public float shakeDuration = .3f;

    private float shakeTimer;
    private Vector2 startPos;

    void Start()
    {
        Shake();
    }

    public void Shake() {
        shakeTimer = 0;
        startPos = this.transform.position;
    }

    public void Update() {

        if (shakeTimer < shakeDuration) {
            gameObject.transform.position = new Vector2(
            startPos.x + Mathf.Sin(Time.time + .7894f * speed) * amount,
            startPos.y + Mathf.Sin(Time.time * speed) * amount);

            shakeTimer += Time.deltaTime;
        } else {
            transform.position = startPos;
        }
        
    }

}
