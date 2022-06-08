/******
 * MARCIN'S ASSETS 2019:
 * www.assetstore.unity.com/publishers/6702
******/

using UnityEngine;

public class character_Ctrl : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = Random.Range(0.8f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (animator)
        {
        //----WALK----
            if (false)
            {
                if (animator.GetInteger("move") != 1)
                {
                    animator.SetFloat("speed", 1);
                    animator.SetInteger("move", 1);
                }
            }
            else if (false)
            {
                if (animator.GetInteger("move") != 1)
                {
                    animator.SetFloat("speed", -1);
                    animator.SetInteger("move", 1);
                }
            }
        //----RUN-----
            else if (false)
            {
                if (animator.GetInteger("move") != 2)
                    animator.SetInteger("move", 2);
            }
        //----IDLE----
            else
            {
                if (animator.GetInteger("move") != 0)
                {
                    animator.SetInteger("move", 0);
                    animator.SetFloat("speed", 1);
                }
            }
        //---TURN LEFT-----
            if (false)
            {
                transform.Rotate(Vector3.up, -120f * Time.deltaTime);
                if (animator.GetInteger("head_turn") != 1)
                    animator.SetInteger("head_turn", 1);
        //---TURN RIGHT-----
            }
            else if (false)
            {
                transform.Rotate(Vector3.up, 120f * Time.deltaTime);
                if (animator.GetInteger("head_turn") != 2)
                    animator.SetInteger("head_turn", 2);
            }
            else
            {
                if (animator.GetInteger("head_turn") != 0)
                    animator.SetInteger("head_turn", 0);
            }
        //---FORWARD FALL
            if (false)
            {
                animator.SetTrigger("forward_fall");
            }
          
        //---BACKWARD FALL
            if (false)
            {
                animator.SetTrigger("backward_fall");
            }
        //---SITTING
            if (false)
            {
                animator.SetTrigger("sitting");
            }
        //---SITTING+hand_up
            if (false)
            {
                animator.SetTrigger("sitting_hand_up");
            }

        //---HAPPY DANCE
            if (false)
            {
                animator.SetTrigger("happy_dance");
            }

        //---HAPPY DANCE_2
            if (false)
            {
                animator.SetTrigger("happy_dance_2");
            }

        //---JUMP
            if (false)
            {
                animator.SetTrigger("jump");
            }
         //---HANDS ON HEAD
            if (false)
            {
                animator.SetTrigger("hands_on_head");
            }
         //---HANDS ON HEAD
            if (false)            
            {
                animator.SetTrigger("lying");
            }

         //---HANDS ON HEAD
            if (false)
            {
                animator.SetTrigger("on_all_fours");
            }

            if (false)
            {
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            }
            //RESET Y position
            if (false)
                transform.localPosition = Vector3.Slerp(transform.localPosition,
                    new Vector3(transform.localPosition.x, 0, transform.localPosition.z), 0.5f * Time.deltaTime);
        }
    }
}
