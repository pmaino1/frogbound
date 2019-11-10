using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMotion : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 4;

    [SerializeField]
    private float shakeModifier = 1;

    [SerializeField]
    private float shakeIncrease = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame. FixedUpdate is used for Physics stuff.
    void FixedUpdate()
    {
        //Adds a bit of random shake to the object.
        float randShakeX = Random.Range(shakeModifier * -1f, shakeModifier * 1f);
        float randShakeY = Random.Range(shakeModifier * -1f, shakeModifier * 1f);
        gameObject.transform.Translate(randShakeX * Time.deltaTime, randShakeY * Time.deltaTime, 0);

        shakeModifier += shakeIncrease * Time.deltaTime;
        manageInput();

    }


    void manageInput()
    {
        float move = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(Vector2.right * move);
    }
}
