using UnityEngine;

// This script allows the player to grapple to a point using the mouse
public class Grapple : MonoBehaviour
{
    // Maximum length of the grapple rope
    [SerializeField] private float grappleLength;

    // Layer(s) that the grapple can attach to
    [SerializeField] private LayerMask grappleLayer;

    // LineRenderer used to visually display the rope
    [SerializeField] private LineRenderer rope;

    // The point in the world where the grapple attaches
    private Vector3 grapplePoint;

    // Physics joint used to simulate the rope connection
    private DistanceJoint2D joint;

    void Start()
    {
        // Get the DistanceJoint2D component attached to the player
        joint = gameObject.GetComponent<DistanceJoint2D>();

        // Disable the joint at the start (not grappling yet)
        joint.enabled = false;

        // Hide the rope at the start
        rope.enabled = false;
    }

    void Update()
    {
        // When left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position into the world
            RaycastHit2D hit = Physics2D.Raycast(
                origin: Camera.main.ScreenToWorldPoint(Input.mousePosition), // Convert mouse to world position
                direction: Vector2.zero, // No direction (acts like a point check)
                distance: Mathf.Infinity, // Infinite range
                layerMask: grappleLayer // Only hit objects on grapple layer
            );

            // If the ray hits something valid
            if (hit.collider != null)
            {
                // Store the grapple point
                grapplePoint = hit.point;
                grapplePoint.z = 0;

                // Set the joint's connection point
                joint.connectedAnchor = grapplePoint;

                // Enable the joint to start pulling the player
                joint.enabled = true;

                // Set the rope length
                joint.distance = grappleLength;

                // Set rope positions
                rope.SetPosition(0, grapplePoint);
                rope.SetPosition(1, transform.position);

                // Show the rope
                rope.enabled = true;
            }
        }

        // When left mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            // Disable the joint (stop grappling)
            joint.enabled = false;

            // Hide the rope
            rope.enabled = false;
        }

        // If the rope is active, keep updating its end position to follow the player
        if (rope.enabled == true)
        {
            rope.SetPosition(1, transform.position);
        }
    }
}