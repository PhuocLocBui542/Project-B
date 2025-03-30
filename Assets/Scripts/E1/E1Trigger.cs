using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1Trigger : MonoBehaviour
{
    private E1 e1 => GetComponent<E1>();

    private void AnimationTrigger()
    {
        e1.AnimationFinishTrigger();
    }
}
