
# HoloTouch

   
**HoloTouch**  Unity package/project creates custom augmented visualizations over 3D printed models using tracking markers using Vuforia and Microsoft HoloLens.

* [Features](#features)
* [System Requirements](#system-requirements)
* [Installation](#installation)
* [Vuforia Setup](#vuforia-setup)
	* [Vuforia License Key](#vuforia-license-key)
	* [Vuforia Image Target Database](#vuforia-image-target-database)
* [Configuring project](#configuring-project)
* [Documentation](#documentation)
* [License](#license)

## Features

* Vuforia
* Hololens
* Augmented visual on top of 3D printed model using the Hololens.  Tracking of the model handled by Vuforia, which tracks 4 image trackers located on the corners of the 3D model.  

## System Requirements
The [HoloLens website](https://docs.microsoft.com/en-us/windows/mixed-reality/install-the-tools) includes a checklist of recommended installed for HoloLens Development.  This project uses Unity 2017.2.1p2 as it is recommended version for developing with Vuforia at the moment.  This project repository will include Vuforia, so downloading it will be unnecessary.
* [Unity 2017.2.1p2](https://unity3d.com/unity/qa/patch-releases/2017.2.1p2)
* Vuforia 6.5.25 
* Visual Studio 2017
* Windows 10 Fall Creators Update

## Account Registration
Create free accounts with Unity and Vuforia.  Unity Personal Version is a free beginner friendly development platform for 2D, 3D, VR and AR applications.
* [Unity ID Registration](https://id.unity.com/)
* [Vuforia Account Registration](https://developer.vuforia.com/user/register)


## Vuforia Setup

### Vuforia License Key
The first step is to log into the [Vuforia License Manager](https://developer.vuforia.com/license-manager) page  with the [Vuforia Account](https://developer.vuforia.com/user/register) you created.  
1. Click on Add License Key to create a free key enabling your Unity application to use Vuforia's image recognition services up to a specified limit.
![Vuforia License Key](https://github.com/jkredzvr/HoloTouch/blob/master/Documentation/Images/5_TargetManager.png)

2. Select Project Type: Development, create a name for your application, and click next to continue.
![Vuforia License Key 2](https://github.com/jkredzvr/HoloTouch/blob/master/Documentation/Images/vuforia_licensekey.png)

3. Clicking on your Application Name in the License Manager will show the Vuforia license key, which will be later copied and pasted into Unity Editor. 
![Vuforia License Key 3](https://github.com/jkredzvr/HoloTouch/blob/master/Documentation/Images/vuforia_licensekey3.png)

### Vuforia Target Image Database
1. Go back to Vuforia License Manager page, click on Target Manager link
2. Click on Add Database button to set up a set of images your HoloLens application will recognize.  Provide a name for the database of images that will be recognized by the app and make sure Type:Devices is selected.
![Vuforia Target Images2](https://github.com/jkredzvr/HoloTouch/blob/master/Documentation/Images/5_TargetManager_1.PNG)

3. When the database is created, click on the database link and click on Add Target Button to start adding the images to be recognized.  
![Vuforia Target Images2](https://github.com/jkredzvr/HoloTouch/blob/master/Documentation/Images/5_TargetManager_2.png)

4. Vuforia can recognize different types of targets ranging from 2D images, 3D objects, and shapes.  Further information and suggestions for improving image recognition and tracking stability can be found [here](https://library.vuforia.com/articles/Solution/Optimizing-Target-Detection-and-Tracking-Stability).
- Included in this [repository is a sample set of 4 fiduciary markers](https://github.com/jkredzvr/HoloTouch/tree/master/ImageTargets)  (each being 2"x2" and 3"x3" in size) that can be uploaded for image tracking.  

5. When uploading the image target, the width must be entered meters.  Lastly give the image target a unique name that will be saved in the database, before clicking on the Add Button
![Vuforia Target Images 3](https://github.com/jkredzvr/HoloTouch/blob/master/Documentation/Images/5_TargetManager_3.png)

6. Back on the Target Manager page, the uploaded image target will appear with a star rating indicating whether the target image will be reliably recognized and tracked by the Vuforia software.  Continue uploading all of the image targets with at least 4-5 star ratings which will be used for tracking the 3D Model.
![Vuforia Target Images 6](https://github.com/jkredzvr/Unity-Vuforia-Tutorial/blob/master/Screenshots/5_TargetManager_6.png)

7. After uploading your image targets, click on the Download Database(All) button and select Unity Editor to download the image database files into a Unity package. 

## 3D Model Preparation
1. Find a 3D Model you would like to print and be augmented using the HoloTouch toolkit, or create your own using websites like https://craftml.io/ or https://www.tinkercad.com.  

- For the time being, it is recommended to use a model that are rectangular or square dimensions (Equal widths and equal length dimensions).  

2. Unity can import .obj file formats, but if your model is a .stl format, you can convert it using http://www.greentoken.de/onlineconv/ or open it with [Microsoft's 3D Builder](https://www.microsoft.com/en-us/store/p/3d-builder/9wzdncrfj3t6) and save it an .obj file.
- To improve the performance of the application, it is recommended to minimize and reduce the number of meshes of the model as much as possible.
- It is also recommended that the 3D Model has a flat base allowing it to be easier affixed to a board or flat surface with the image tracking markers.
- **NOTE:**  Keep in mind the measurement scale of the selected 3D model and the axis the model is oriented in.  Typical 3D modelling tools align the z-axis to be "UP", however Unity's coordinate system treats y-axis to be UP.  If possible, in a 3D modelling software program
	- orient the model's o if the imported 3D model is rotated, then coordinates were different.  
	- position the origin of the coordinate system to be located to the model's lower corner.  
![Vuforia Target Images2](https://github.com/jkredzvr/HoloTouch/blob/master/Documentation/Images/ModellingCoordinates.PNG)

## Configuring Project
1. Download the HoloTouch Toolkit from this github repo 
2. Open the HoloTouch project with Unity 2017.2.1p2 editor
3. In the Project folder tab, navigate to Assets/HoloTouch/Scenes/ folder and select on the Template.scene file.
![Vuforia Template Scene](https://github.com/jkredzvr/HoloTouch/blob/master/Documentation/Images/TemplateSceneSelected.png)

5. With the template scene selected, press Ctrl+D to make a copy of the scene and rename to what you desire.
6. Double click to open the scene that you will build your HoloLens application.

### Configure Project Settings
1. Select  **File/ Build Settings /** and underneath Platform, if Universal Windows Platform is not selected, select it and click on Switch Platform to build for the HoloLens. 
![Vuforia Build Settings](https://github.com/jkredzvr/HoloTouch/blob/master/Documentation/Images/buildsettings2.PNG)
2. Click on Add Open Scene, which should include your current scene with a checked box when you are building your application to the HoloLens.
3. Next click on Players Settings, next to the Switch Platform button
4. The right side in the inspector panel of the Players Settings.  Click to drop down the XR Settings tab.  Check box the Virtual Reality Supported and Vuforia Augmented Reality options.
![Vuforia XR Settings](https://github.com/jkredzvr/HoloTouch/blob/master/Documentation/Images/XRSettings.png)
5. At the top of the Players Settings is a text field for Product Name, which you can change to reflect the name of your application in the HoloLens.  

### Configuring Vuforia Target Database
The template scene will start with an AR Camera, Target-Placement-Manager, and Background Instruction Plane, shown in the Scene tab and Hierarchy Tab.  The Target-Placement-Manager contains the ImgTarget1,2,3,4, which will be tracked by Vuforia.

1.  Import the Vuforia Image Database file that was downloaded from Vuforia website by navigating to **Assets/Import Packages/Custom Packages** and open the downloaded Image Database Unity Package.

![Vuforia Target Images 7](https://github.com/jkredzvr/Unity-Vuforia-Tutorial/raw/master/Screenshots/5_TargetManager_7.png)
3. After importing all the database image Unity package, navigate to **Windows/Vuforia Configuration** to show the Vuforia Configuration settings in the Inspector window.
4.  In the Vuforia Configuration, paste your Vuforia App License key from your Vuforia  Account into the App License Key text input field.
![Vuforia Config App Key](https://github.com/jkredzvr/HoloTouch/blob/master/Documentation/Images/VuforiaConfigAppKey.PNG)
6.  Underneath the Digital Eyewear header, select **Optical See-Through** for Eyewear Type and **HoloLens** for See Through Config
7. Underneath Databases header the name of your image database should show up.  (In my case I named my database DataViz)  Select the check boxes to load and activate your databases and enable tracking with Vuforia
![Vuforia Config App Key](https://github.com/jkredzvr/HoloTouch/blob/master/Documentation/Images/VuforiaConfigDatabases.png)

### Setting up Target Images in Unity
With the Vuforia Configurations loaded with the image database set in your Vuforia account, we'll set up a virtual scene for our objects to appear when an images are recognized.

1. For each imgTarget1,2,3,4 set each associated image target.  ImgTargets will be located sequentially left to right at each corner of the 3D model.  (By default the image targets will be overlapping since an image has not been specified.  The positioning and ordering of the targets will be apparent when we define the image targets)  
- imgTarget1 top left corner
- imgTarget2 top right corner
- imgTarget3 bottom left corner
- imgTarget4 bottom right corner
2. Select an imgTarget in the hierarchy tab
![Selected Image Target](https://github.com/jkredzvr/HoloTouch/blob/master/Documentation/Images/SelectedImgTarget.PNG)
3. In the inspector, the Image Target Behaviour component handles the image target settings
4. In the Database drop down field (currently labelled as ---EMPTY--- select your image database for the project
5. Next in the Image Target drop down field, select the appropriate image target file name associated to the image you will place in the corners of your actual 3D printed model. (In my case my database was named DataVis, and I will use the 2x2" img target)

![Selected Image Target](https://github.com/jkredzvr/HoloTouch/blob/master/Documentation/Images/SettingImgTargets.gif)

6. After selecting the Image Target, the imgTarget gameobject will be re-scaled in the Scene tab to the actual size in meters of your uploaded image targets.  Continue setting the image targets for the remaining imgTarget gameobjects.
![All Images Set](https://github.com/jkredzvr/HoloTouch/blob/master/Documentation/Images/AllImagesSet.png)

### Import 3D Model
Next import your 3D obj model into Unity.
1. Go to **Assets/Import New Asset** and select the .obj file that was downloaded into **Assets/HoloTouch/Models**  folder
2. In the Project tab, navigate to **Assets/HoloTouch/Models** folder and select on the .obj model file.
3. The Inspector tab will show the Import Settings, which includes a field for Scale Factor.  Unity's base units are in meters, so if the model was created in mm scaling, then scale down the model by .001.
4. Drag the model in to the scene to check whether the import scaling is correct.
5. As mentioned earlier, another caveat about Unity is that the Y-Axis is in the "UP" direction.  So if the imported 3D model is rotated, then coordinates were different.  Fix this by dragging the .obj file into the scene and reorient the rotation of the model changing the model's GameObject's transform rotations in the Inspector.  Once the GameObject's is oriented properly, drag the model GameObject's from the hierarchy into **Asset/HoloTouch/Models** folder to save it as a new Prefab. Rename the new prefab as "model-reoriented" and delete the model GameObject from the Hierarchy.
![All Images Set](https://github.com/jkredzvr/HoloTouch/blob/master/Documentation/Images/RotatingModel.gif)


## Configuration HoloTouch Editor
The next step is to orient and position the image targets and 3D model in the scene using the HoloToch Editor.
1.  Navigate to **HoloTouch/Settings** in the toolbar, which will open the HoloTouch Editor window.  This window can be expanded larger or attached into the Unity Editor like any other window.![Holotouch Settings](https://github.com/jkredzvr/HoloTouch/blob/master/Documentation/Images/holotouchsettings.png)
2. From the **Assets/HoloTouch/Models** folder in the Project tab, drag the "model-reoriented" prefab into the HoloTouch Editor's 3D model field.  This sets the viewed model that will be displayed when Vuforia tracks the markers.

![Set Model](https://github.com/jkredzvr/HoloTouch/blob/master/Documentation/Images/settingModel.gif)
3. Next enter the 3D model's width and length (in meters) into the HoloTouch Editor.
4. Drag the Target-Placement-Manager GameObject from the hiearchy into the HoloTouch Editor's Target Manager field.
![Set Target Manager](https://github.com/jkredzvr/HoloTouch/blob/master/Documentation/Images/setTargetManager.gif)
5. Under the Image Target Info header, if the Image Target 1,2,3,4 inputs show up as None (Game Object) , drag each imgTarget1 gameobject from the Hierarchy tab into each appropriate field.
![Setting Image Targets](https://github.com/jkredzvr/HoloTouch/blob/master/Documentation/Images/setImageTargets.gif)
6. Next enter the image targets width and length (in meters) into the HoloTouch Editor.
7. With all of the fields filled out in the HoloTouch Editor, press the Apply Settings button.  This should automatically orient the 3D model in center, with imgTarget1,2,3,4 placed in the appropriate corners.  If the scaling of the model and image target dimensions set correctly in the HoloTouch Editor, then the corners of the image targets should only touch the corner of the 3D model.  Click and inspect the Target-Placement-Manager GameObject to make sure that the TargetModelManager script is referencing the created 3D model in the scene.
![Applying HoloTouchEditor settings ](https://github.com/jkredzvr/HoloTouch/blob/master/Documentation/Images/applyHoloEditorSettings.gif)

### Building Project for Visual Studio
Once the image targets and model are placed in the scene, its time to build the Unity project to the Hololens.
1. Navigate to **File/Build Settings** and make sure that the current scene is checked, and Universal Windows Platform is already selected under Platform.
2. Click Build, which will ask to save the build in a new folder.  Try saving this new folder outside of your Unity project folder.
3. After Unity finishes saving the build, navigate to this folder and locate the Visual Studio Solution file (.sln) , which should be the same name as the one set in the Players Setting step.
![Building Project](https://github.com/jkredzvr/HoloTouch/blob/master/Documentation/Images/buildingProject.gif)


### Preparing the Hololens
Instructions from https://docs.microsoft.com/en-us/windows/mixed-reality/using-visual-studio

Start by enabling  **Developer Mode**  on your device so Visual Studio can connect to it.
1.  Turn on your HoloLens and put on the device.
2.  Perform the  [bloom](https://docs.microsoft.com/en-us/windows/mixed-reality/gestures#bloom)  gesture to launch the main menu.
3.  Gaze at the  **Settings**  tile and perform the  [air-tap](https://docs.microsoft.com/en-us/windows/mixed-reality/gestures#air-tap)  gesture. Perform a second air tap to place the app in your environment. The Settings app will launch after you place it.
4.  Select the  **Update**  menu item.
5.  Select the  **For developers**  menu item.
6.  Enable  **Developer Mode**. This will allow you to  [deploy apps from Visual Studio](https://docs.microsoft.com/en-us/windows/mixed-reality/using-visual-studio)  to your HoloLens.

### Deploying in Visual Studio 
1. In the folder that the Unity project was built and saved into, double click on the .sln file, which will open up Visual Studio 2017.
2. Connect your HoloLens to your laptop/computer with a microUSB cable, and make sure the HoloLens is on.
3. Select  **Release** and **x86**  build configuration for your app  
6.  Select  **Device**  in the deployment target drop-down menu![Visual Studio Settings](https://github.com/jkredzvr/HoloTouch/blob/master/Documentation/Images/VisualStudioSettings.PNG)
7.  Select  green arrow icon next to **Device**  to deploy your app
8.  The first time you deploy an app to your HoloLens from your PC, you will be prompted for a PIN. Follow the  **Pairing your device**  instructions in https://docs.microsoft.com/en-us/windows/mixed-reality/using-visual-studio.
9.  Once Visual Studio finishes deploying the application, you can unplug your HoloLens from your laptop and find your application in your Applications folder.

## Physical 3D Model Print Preparation
- Affix the 3D printed model in the center of a flat surface
- Print and cut out the 4 image targets, making sure that the dimensions and scaling are as specified when uploading to the Vuforia image database as Vuforia will scale the augmented projections based on the size of the printed image targets
- Affix the 4 image targets on the corners of the 3D printed model, ensuring that the orientation and placement are exactly reflect the placement in the Unity editor.

## Documentation
## License
