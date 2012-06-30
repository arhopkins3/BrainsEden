// Copyright (c) 2011 Bob Berkebile
// Please direct any bugs/comments/suggestions to http://www.pixelplacement.com
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using UnityEngine;
using System.Collections.Generic;

[AddComponentMenu("Pixelplacement/SecurityCamera")]
public class SecurityCamera : MonoBehaviour{
	public static Dictionary<string, GameObject> Cameras = new Dictionary<string, GameObject>();
	public static GameObject CurrentCamera;
	static int conflictCount = 0;
	
	void Start(){
		if (Cameras.ContainsKey(name)) {
			Debug.LogWarning("SecurityCamera: Warning! All cameras used with SecurityCamera should have unique names. Conflict has been automatically renamed.");  
			name = name + "_" + ++conflictCount;
		}
		
		if (tag == "MainCamera" && name != "Main Camera") {
			Debug.LogWarning("SecurityCamera: Warning! A camera was found with a tag of 'MainCamera' but wasn't named 'Main Camera' this might be the result duplicating the default Main Camera. This camera's tag has been set to 'Untagged' to ensure proper operation of Unity's Camera.main.");
			tag = "Untagged";
		}
		
		Cameras.Add(name,gameObject);
		if (Camera.main.gameObject != gameObject) {
			gameObject.active = false;
		}else{
			CurrentCamera = Camera.main.gameObject;
		}
	}
	
	public static void ChangeCamera(string newCamera){
		CurrentCamera.active = false;
		Cameras[newCamera].active = true;
		CurrentCamera = Cameras[newCamera];
		CurrentCamera.camera.depth=999999;
	}
}