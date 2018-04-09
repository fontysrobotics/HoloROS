# HoloROS

This project will be used to add ROS functionality to the hololens.

To use the project clone the repository. After this unzip the Holotoolkit zip file, found in HoloROS/Assets, into the directory. After this import the project into unity. The project was started in unity 2017.3.1f1 (64bit). 
After importing it into unity go to the "Mixed Reality Toolkit" option in the menu bar, hover over configure, and select Apply Mixed Reality Toolkit Settings. This will set up the project properly. 

After this you can either connect to the hololens via unity or visual studio. 

For unity: 

* Press window in the menu -> Holographic emulation
* Set emulation mode to Remote to device. 
* Start the holographic remoting app on the hololens. 
* Press connect on unity and you should be able to play your programs on the hololens by pressing the play button. 

For visual studio:

* Build the project via unity. (File -> Build settings -> build.)
* Select where to build it. 
* Wait for it to build, then go to the build folder and open the .sln file. 
* Select which processor to use X86
* Then select remote to machine in how to play. Enter the ip address. 
* Wait for it to deploy and the program should start automatically on the hololens. 
