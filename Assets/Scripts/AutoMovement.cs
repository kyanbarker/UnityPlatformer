using System.Collections;
using UnityEngine;

/// <summary>
/// The platform that this script is attatched to will move between the a series of positions.
/// </summary>
public class AutoMovement : MonoBehaviour
{
    /// <summary>
    /// The current world space position to move towards.
    /// </summary>
    private Vector3 target;

    /// <summary>
    /// The index of the current target as a child of targetsParent.
    /// </summary>
    private int targetIndex = 0;

    /// <summary>
    /// The GameObject parenting all targets to move between.
    /// </summary>
    public Transform targetsParent;

    /// <summary>
    /// The speed at which this platform should move between the targets.
    /// </summary>
    public float speed = 0.1f;

    /// <summary>
    /// The time for which this platform should rest after reaching a target.
    /// </summary>
    public float recessTime = 0;

    /// <summary>
    /// Sets an initial target and begins movement towards that target.
    /// </summary>
    private void Start()
    {
        target = GetTarget(0);
        StartCoroutine(Move());
    }

    /// <summary>
    /// Draws an outline connecting all targets with lines.
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        for (int i = 0; i < targetsParent.childCount - 1; i++)
        {
            Gizmos.DrawLine(GetTarget(i), GetTarget(i + 1));
        }
        Gizmos.DrawLine(GetTarget(0), GetTarget(targetsParent.childCount - 1));
    }

    /// <summary>
    /// Moves this platform towards the current target.
    /// </summary>
    private IEnumerator Move()
    {
        while (true)
        {
            while (transform.position != target)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, speed);
                yield return new WaitForFixedUpdate();
            }
            UpdateTarget();
            yield return new WaitForSeconds(recessTime);
        }
    }

    /// <summary>
    /// Sets target equal to the next element in targets.
    /// If the current target is the last element, the next element will be the first element in the targets array.
    /// </summary>
    private void UpdateTarget()
    {
        targetIndex = targetIndex < targetsParent.childCount - 1 ? targetIndex + 1 : 0;
        target = GetTarget(targetIndex);
    }

    /// <param name="index">The index of targetParent's children to retrieve the position of.</param>
    /// <returns>The position of the targetsParent's child at the argued index.</returns>
    public Vector3 GetTarget(int index)
    {
        return targetsParent.GetChild(index).position;
    }
}
