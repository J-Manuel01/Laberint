using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocoMotionSMB : StateMachineBehaviour
{
    float m_Damping = 0;
    int m_HashHorizontalParam = Animator.StringToHash("Horizontal");
    int m_HashVerticalParam = Animator.StringToHash("Vertical");
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 heroeAnimation = new Vector3(moveHorizontal, moveVertical).normalized;
        animator.SetFloat(m_HashHorizontalParam, heroeAnimation.x, m_Damping, Time.deltaTime);
        animator.SetFloat(m_HashVerticalParam, heroeAnimation.y, m_Damping, Time.deltaTime);

    }


}
