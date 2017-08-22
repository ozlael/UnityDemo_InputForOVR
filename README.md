# UnityDemo : InputForOVR

If you want to make VR content, you have to support all of major HMDs.(Oculus and Vive at this moment :p) You may know supporting HMD devices only is very easy. You don't need any additional SDK or assets to track and support HMD deivces.
Problem is supporting and tracking controllers. If you want to support both Oculus Touch and Vive Controller , you may import both SDKs. For Oculus Touch, You have to import Oculus Utilities for Unity rom Oculus Developer Center. And for Vive Controller, you have to import SteamVR Plugin from Unity Store. As a result, you have to use different prefabs and different codes to support both different controller systems. It is very annoying stuff for maintaining.
Actually, you don't have to do it anymore, if your controll input system is simple. Unity provide [VR tracking APIs](https://docs.unity3d.com/ScriptReference/VR.InputTracking.html) to track posion of controllers. To track controllers, you don't have to import additional SDKs from out of Unity. You can do it as using API built inside unity. Plus, You can get input of triggers and buttons from controllers using  basing Input system of Unity.

Codes of trackig are in VRControllerTracking.cs : 

```
transform.localPosition = InputTracking.GetLocalPosition (whichNode);
transform.localRotation = InputTracking.GetLocalRotation (whichNode);
```

To get input of controllers, You may refer official manual : [Input table for OVR controllers](https://docs.unity3d.com/Manual/OpenVRControllers.html), [Input API](https://docs.unity3d.com/ScriptReference/Input.html), [Input Manager](https://docs.unity3d.com/Manual/class-InputManager.html). 
It is the same with general game controllers. Look at the input mapping table. For example, if you want to get LeftHandTrigger, it will say Joystick Button 14 in there.

Check Input Settings and LaserSwordControl.cs :
```
if (blade && Input.GetAxisRaw (inputNameToActiveBlade) > 0.1f) {
```


## Getting Started

Open test1 scene and play. you can see 2 swords sync well with controller devices.
Oculus Touch : Squeez Hand triggers to spawn blades. Squeez Index triggers to charge blades. 
it's the end. Notthing happen anymore :) Because, it is a demo to show how to track controllers and get input.
[![the video](https://j.gifs.com/nZBwBp.gif)](https://www.youtube.com/watch?v=nyIIXg_hNe0)

### Prerequisites

Please note that assets inside this demo is free but only non-commercial use. Ypu can not use assets for commercial contents. For-profit education also.


## Acknowledgments

* The Project is for Unity 2017.1 and more
* If you have questions, ask me via Social Media.
* Facebook : [ozlael.oz](https://www.facebook.com/ozlael.oz)
* Twitter : [@ozlael](https://twitter.com/ozlael)
