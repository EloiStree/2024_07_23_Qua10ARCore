using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGroundBasedOnOriginXrMono : MonoBehaviour
{
    public float m_timeBetweenChecks = 2f;
    public Transform m_originAnchorPoint;
    public Transform m_cameraAnchorPoint;
    public Transform m_groundToMove;

    [Range(-1f,1f)]
    public float m_adjustedHeightPercent = 0;
    public float m_adjustedHeightRange = 2;

    void Start()
    {
        
        InvokeRepeating("CheckGroundUnderCamera", m_timeBetweenChecks, m_timeBetweenChecks);  
    }

    public void SetPercentAdjustment(float percent11) { 
        m_adjustedHeightPercent = percent11;
        m_groundToMove.position =
           new Vector3(
               m_groundToMove.position.x,
               m_originAnchorPoint.position.y +
               m_adjustedHeightPercent * m_adjustedHeightRange,
               m_groundToMove.position.z
               );
    }


    [ContextMenu("Reset")]
    public void ResetGroundUnderCamera()
    {

        m_groundToMove.position =
            new Vector3(
                m_cameraAnchorPoint.position.x,
                m_originAnchorPoint.position.y +
                m_adjustedHeightPercent * m_adjustedHeightRange,
                m_cameraAnchorPoint.position.z
                );
    }
}
