using System;
using System.Collections;
using System.Collections.Generic;
using Input;
using Reflex;
using Reflex.Scripts.Attributes;
using UnityEngine;

public class InputTester : MonoBehaviour
{
    [Inject]
    private void Inject(IPlayerChargeInput dependencyOne)
    {
        dependencyOne.OnPlayerChargeBegin += () => Debug.Log("AA");
    }

}
