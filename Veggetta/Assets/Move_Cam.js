 var target : Transform;
 var distance = 2.0;
 
 var xSpeed = 180.0;
 var ySpeed = 90.0;
 
 var yMinLimit = 0.0;
 var yMaxLimit = 80;
 
 var speed : float = 0.14;
 
 private var x = 0.0;
 private var y = 0.0;

  
 
 @script AddComponentMenu("Camera-Control/Mouse Orbit")
 
 function Start () {
     var angles = transform.eulerAngles;
     x = angles.y;
     y = angles.x;
     
 
     
 }
 
 function LateUpdate () {
 
     if (target && Input.GetMouseButton(1)) {
         x += Input.GetAxis("Mouse X") * xSpeed * 0.02;
         y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02;
          
          y = ClampAngle(y, yMinLimit, yMaxLimit);
                 
         var rotation = Quaternion.Euler(y, x, 0);
         var position = rotation * Vector3(0.0, 0.0, -distance) + target.position;
         
         transform.rotation = rotation;
         transform.position = position;
     }
     
     
     
 }
 
 static function ClampAngle (angle : float, min : float, max : float) {
     if (angle < -360)
         angle += 360;
     if (angle > 360)
         angle -= 360;
     return Mathf.Clamp (angle, min, max);
 }
 
 function Update () {
  
// transform.LookAt(target);
  
 transform.position -= transform.right * speed * Time.deltaTime;
 
 if (Input.GetMouseButton(0)) {
// transform.LookAt(target);
 transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X")*speed);
 }
     // Calculate the desired distance 

  
 }
