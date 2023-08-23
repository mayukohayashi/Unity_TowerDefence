using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;

        waypoint = GetComponentInParent<Waypoint>();

        DisplayCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectTitle();
        }

        ColorCoordinates();
        ToggleLabels();
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(
            transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x
        );
        coordinates.y = Mathf.RoundToInt(
            transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z
        );

        // Show current coordinates on cube
        label.text = coordinates.x + ", " + coordinates.y;
    }

    void UpdateObjectTitle()
    {
        transform.parent.name = coordinates.ToString();
    }

    void ColorCoordinates()
    {
        //
        if (waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }

    void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }
}
