using UnityEngine;
using UnityEditor;

public class AlignToFloorEditor : EditorWindow
{
    [MenuItem("Tools/Align Object to Floor")]
    public static void AlignToFloor()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            RaycastHit hit;
            if (Physics.Raycast(obj.transform.position, Vector3.down, out hit))
            {
                // Move the object to the hit point
                Vector3 newPosition = obj.transform.position;
                newPosition.y = hit.point.y;
                obj.transform.position = newPosition;

                // Optionally, you could adjust the rotation to match the floor's normal
                // obj.transform.rotation = Quaternion.FromToRotation(obj.transform.up, hit.normal) * obj.transform.rotation;
            }
        }
    }
}
