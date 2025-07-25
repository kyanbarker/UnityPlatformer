using UnityEngine;
using UnityEditor;

/// <summary>
/// A script that creates a custom inspector in which there exists a button which when clicked sets the player's spawn point to the selected checkpoint.
/// </summary>
[CustomEditor(typeof(Checkpoint))]
public class CheckpointInspector : Editor
{
    /// <summary>
    /// Creates a button in the inspector that when clicked sets the player's respawn point to the selected checkpoint.
    /// </summary>
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Checkpoint checkpoint = (Checkpoint)target;
        if (GUILayout.Button("Set player's spawnpoint to this checkpoint"))
        {
            checkpoint.SetRespawnPoint();
        }
    }
}
