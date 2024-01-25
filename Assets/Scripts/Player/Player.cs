using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;



    [Header("Speed setup")]
    public Vector2 friction = new Vector2(-.1f, 0);
    public float speed;
    public float speedRun;
    public float forceJump = 2;



    [Header("Animation setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;
    public float animationDuration = .3f;
    public float squashScaleY = 0.5f; 
    public float squashScaleX = 1.5f; 
    public float squashDuration = 0.2f;
    public Ease ease = Ease.OutBack;


    [Header("Animation player")]
    public string boolRun = "Run";
    public Animator animator; 








    private float _currentSpeed;

    private void Update()
    {
        HandleJump();
        HandleMovements();
    }

    private void HandleMovements()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = speedRun;
        }
        else
        {
            _currentSpeed = speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
            myRigidbody.transform.localScale = new Vector3(-1,1,1);
            animator.SetBool(boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
            myRigidbody.transform.localScale = new Vector3(1,1,1);
            animator.SetBool(boolRun, true);
        }

        else{
            animator.SetBool(boolRun, false);
        }




        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity += friction;
        }
        else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity -= friction;
        }
    }

    private void HandleJump()
{
    if (Input.GetKeyDown(KeyCode.Space))
    {
        myRigidbody.velocity = Vector2.up * forceJump;
        myRigidbody.transform.localScale = Vector2.one;

        DOTween.Kill(myRigidbody.transform);

        
        //HandleScaleJump() 
       
}

// private void HandleScaleJump(System.Action onCompleteCallback)
// {
//     myRigidbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
//     myRigidbody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease)
//         .OnComplete(() =>
//         {
//             onCompleteCallback?.Invoke();
//         });
// }


}
}
