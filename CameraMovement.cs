using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset; //a set of values we can set for camera rotation * distance. If we declare any values in the inspector, camera won't calculate an automatic offset based on the target's position from the camera's position
    bool useOffsetValues;
    public float rotateSpeed;
    public Transform pivot;
    public float maxViewAngle;
    public float minViewAngle;
    public bool invertY; 
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //locks cursor in the center and hides it on runtime. esc to unhide, click to rehide

        if(!useOffsetValues)
        {
            offset = target.position - transform.position; //dist betw cam & player
        }

        pivot.transform.position = target.transform.position; // pivot position is equal target position to prevent player mesh itself from rotating with mouse.

        pivot.transform.parent = target.transform; //on runtime childs pivot position to player position so that it can mimic following the player without affecting it.
    }
    void LateUpdate() //late update catches up with player input and prevents camera from jerking 
    {
        //get X  position of mouse & rotate target player
        float horizontal = Input.GetAxis("Mouse X");
        target.Rotate(0, horizontal, 0);

        //get Y position of mouse & rotate the pivot
        float vertical = Input.GetAxis("Mouse Y");

        if(invertY)
        { pivot.Rotate(vertical, 0, 0); } else { pivot.Rotate(-vertical, 0, 0); } 

        //limit up/down camera rotation to prevent camera flip & going wrong directions.
        if(pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
        //quaternions are weird.. we logically assume we're working with a 360degree rotation posibility, so we have to specify to unity that we want a limit of 180 degree on pivot x axis rotation so that it doesnt automatically continue from 180 to 0 to -180 (aka take a full 360 degree rotation) and instantly snap us back to ground view. 
        {
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
        }
        
        //same shit but for down. we're saying that if euler x is anywhere between 180 and 360 - (limit set in inspector), we want the rotation to limit to a certain close range to the player from ground view.
        if(pivot.rotation.eulerAngles.x > 180 && pivot.rotation.eulerAngles.x < 360f + minViewAngle)
        {
            pivot.rotation = Quaternion.Euler(360f + minViewAngle, 0, 0);
        }

        //move camera based on the current rotation of the target player & the original offset
        float desiredYangle = target.eulerAngles.y;
        float desiredXangle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXangle, desiredYangle, 0);
        transform.position = target.position - (rotation * offset);

        if(transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y - .5f, transform.position.z); //prevents the camera from going underground with respect to the player's vertical position, 0.5f is subtracted from the camera's vertical pos to give the effect of zooming into the player when the statement is true.
        }
        transform.LookAt(target);
    }
}
