using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSegment : MonoBehaviour
{
    public bool IsNewSegment = true;

    void Start()
    {
        StartCoroutine(ResetNewSegmentFlag());
    }

    IEnumerator ResetNewSegmentFlag()
    {
        yield return new WaitForSeconds(0.5f);
        IsNewSegment = false;
    }
}
