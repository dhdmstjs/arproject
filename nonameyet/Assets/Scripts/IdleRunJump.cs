/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using System.Collections;

public class IdleRunJump : MonoBehaviour {


	protected Animator animator;
	public float DirectionDampTime = .25f;
	public bool ApplyGravity = true; 

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();
		
		if(animator.layerCount >= 2)
			animator.SetLayerWeight(1, 1);
	}
		
	// Update is called once per frame
	void Update () 
	{

		if (animator)
		{
			AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);			

			if (stateInfo.IsName("Base Layer.Run"))
			{
				if (Input.GetButton("Fire1")) animator.SetBool("Jump", true);                
            }
			else
			{
				animator.SetBool("Jump", false);                
            }

			if(Input.GetButtonDown("Fire2") && animator.layerCount >= 2)
			{
				animator.SetBool("Hi", !animator.GetBool("Hi"));
			}
			
		
      		float h = Input.GetAxis("Horizontal");
        	float v = Input.GetAxis("Vertical");
			
			animator.SetFloat("Speed", h*h+v*v);
            animator.SetFloat("Direction", h, DirectionDampTime, Time.deltaTime);	
		}   		  
	}
}
