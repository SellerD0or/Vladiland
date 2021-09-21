using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Railroad : MonoBehaviour
{
    [SerializeField] private PlatformEffector2D _platform;

    public PlatformEffector2D Platform { get => _platform; set => _platform = value; }
}
