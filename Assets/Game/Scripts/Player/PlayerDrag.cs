using UnityEngine;

public class PlayerDrag : MonoBehaviour
{
    [SerializeField] private float fixedYPosition = 1f;
    private float objectHalfWidth;

    private Vector3 mOffset;
    private float mZCoord;

    void Start()
    {
        // Get half the width of the object
        objectHalfWidth = transform.localScale.x * 0.5f;
    }

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(
            gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        Vector3 newPosition = GetMouseWorldPos() + mOffset;
        newPosition.y = fixedYPosition;

        // Constrain the X position within the screen resolution
        float minX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, mZCoord)).x + objectHalfWidth;
        float maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, mZCoord)).x - objectHalfWidth;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        transform.position = newPosition;
    }
}
