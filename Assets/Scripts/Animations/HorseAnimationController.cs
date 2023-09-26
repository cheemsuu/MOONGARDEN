using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HorseAnimationController : MonoBehaviour
{
    
    Animator anim;

    // transition variables
    Transform horsePos;
    float startingPos;
    float xPos;

    // timer variables
    float timer = 0.0f;
    float timerDelay = 4.0f;
    float timeScale = 1.0f;

    
    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        horsePos = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        xPos = horsePos.transform.position.x;
        anim.SetFloat("xPos", xPos);

        timer += Time.deltaTime;
        
        if (timer > timerDelay)
        {
            anim.SetBool("canMove", true);
            timer = timer - timerDelay;
            Time.timeScale = timeScale;
        }
    }

    public void ResetHorseMovement()
    {
        anim.SetBool("canMove", false);
        timer = 0.0f;
    }

    void RunLeft()
    {
        float step = 1.0f * Time.deltaTime;
        if (horsePos.position.x > 24) // fix bc hardcoded
        {
            Vector3.MoveTowards(transform.position, new Vector3(22.0f, 25.0f, 0.0f), step);
        }
    }

}
