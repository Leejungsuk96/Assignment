using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    PlayerInputController controller;
    [SerializeField] private Animator anim;
    private void Awake()
    {
        controller = GetComponent<PlayerInputController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        controller.OnMoveEvent += AnimState;
    }
    void AnimState(Vector2 direction)
    {
        anim.SetBool("Walk", direction.magnitude > 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
