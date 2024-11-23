using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class Firezone : MonoBehaviour
{
    private Vector3 _firezonePosition;
    private Vector3 FirezonePosition
    {
        get => _firezonePosition;
        set => _firezonePosition = value;
    }
    
}
