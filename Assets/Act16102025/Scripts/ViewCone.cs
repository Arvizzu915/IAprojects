using System.Collections.Generic;
using UnityEngine;

public class ViewCone : MonoBehaviour
{
    [Header("Vision Settings")]
    public float viewRadius = 10f;
    [Range(0, 360)]
    public float viewAngle = 90f;

    [Header("Detection Settings")]
    public LayerMask targetMask;   // Layer(s) to detect (e.g., Player, Enemy)
    public LayerMask obstacleMask; // Layer(s) that block vision

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    private Predator predator;

    private void Start()
    {
        predator = GetComponentInParent<Predator>();
    }

    void Update()
    {
        FindVisibleTargets();

        if (visibleTargets.Count > 0)
        {
            predator.ViewConeDetect(visibleTargets);
        }
    }

    void FindVisibleTargets()
    {
        visibleTargets.Clear();

        // Step 1: Find all targets in radius
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        foreach (Collider targetCollider in targetsInViewRadius)
        {
            Transform target = targetCollider.transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            // Step 2: Angle check
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float distToTarget = Vector3.Distance(transform.position, target.position);

                // Step 3: Obstacle check (LOS)
                if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, obstacleMask))
                {
                    visibleTargets.Add(target);
                }
            }
        }
    }

    // Optional: visual debugging
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        Vector3 leftBoundary = DirFromAngle(-viewAngle / 2);
        Vector3 rightBoundary = DirFromAngle(viewAngle / 2);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary * viewRadius);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary * viewRadius);

        Gizmos.color = Color.green;
        foreach (Transform visible in visibleTargets)
        {
            Gizmos.DrawLine(transform.position, visible.position);
        }
    }

    Vector3 DirFromAngle(float angleInDegrees)
    {
        angleInDegrees += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
