using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraController : MonoBehaviour
{
    #region Settings

    #region LookSettings

    private bool a = false;
    private bool locked = false;
    private float NormalSpeed = 50.0f; //regular speed
    private float shiftAdd = 250.0f; //multiplied by how long shift is held.  Basically running
    private float SprintSpeed = 100.0f; //Maximum speed when holdin gshift
    public float MouseSensitivity = 0.25f; //How sensitive it with mouse
    Vector3 lastMouse = new Vector3(); //kind of in the middle of the screen, rather than at the top (play)
    private float totalRun= 1.0f;

    #endregion
    #region ZoomSettings

    private float minFov = 15f;
    private float maxFov = 90f;
    public float ZoomSensitivity = 10f;
    private float fov = 60f;

#endregion

    #endregion
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    
    void Update () {

        fov = Camera.main.fieldOfView;
        fov -= Input.GetAxis("Mouse ScrollWheel") * ZoomSensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;

        var x = CrossPlatformInputManager.GetAxis("Mouse X");
        var y = CrossPlatformInputManager.GetAxis("Mouse Y");
        
        if (Input.GetMouseButton(1))
        {
            a = true;
        }
        else
        {
            a = false;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
            locked = !locked;
        if(locked)
            Cursor.lockState = CursorLockMode.Locked; 
        if(!locked)
            Cursor.lockState = CursorLockMode.None;

        if (locked || a)
        {
            lastMouse = Input.mousePosition - lastMouse;
            lastMouse = new Vector3(-x * MouseSensitivity, y * MouseSensitivity, 0);
            lastMouse = new Vector3(transform.eulerAngles.x - y, transform.eulerAngles.y + x, 0);
            transform.eulerAngles = lastMouse;
        }
        
        Vector3 p = GetBaseInput();
        if (Input.GetKey (KeyCode.LeftShift)){
            totalRun += Time.deltaTime;
            p  = p * totalRun * shiftAdd;
            p.x = Mathf.Clamp(p.x, -SprintSpeed, SprintSpeed);
            p.y = Mathf.Clamp(p.y, -SprintSpeed, SprintSpeed);
            p.z = Mathf.Clamp(p.z, -SprintSpeed, SprintSpeed);
        }
        else{
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            p = p * NormalSpeed;
        }
       
        p = p * Time.deltaTime;
        Vector3 newPosition = transform.position;
        if (Input.GetKey(KeyCode.Space)){ //If player wants to move on X and Z axis only
            transform.Translate(p);
            newPosition.x = transform.position.x;
            newPosition.z = transform.position.z;
            transform.position = newPosition;
        }
        else{
            transform.Translate(p);
        }
        
    }   
    
    private Vector3 GetBaseInput() {
        
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey (KeyCode.W)){
            p_Velocity += new Vector3(0, 0 , 1);
        }
        if (Input.GetKey (KeyCode.S)){
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey (KeyCode.A)){
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey (KeyCode.D)){
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }
    
}
