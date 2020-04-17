# CardGamesProject
aka: Quarantine Survival Card Kit.  
  
  
Description: Desktop simulator for card games. Private project for private use only. 
  
Dev Info:  
Unity version: 2019.3.7f1 Personal  
Visual Studio: 2019 Community

# Installation guide
Download and install Unity hub from here: https://unity3d.com/get-unity/download  

1, After installation open Unity Hub, and go to "Installs"  
2, Click on the huge blue Add" button, to add new version of Unity.  
3, Select "Unity 2019.3.7f1", and go to step 6 or...  
4, If the version cannot be seen here, then click on the "download archive" link in the text above the versions.  
5, On the unity archive click on the corresponding versions green "Unity hub" button.  
6, While installing there will be a modules view where you can add or remove modules and features. 
Here you have to tick the options below:
  - Dev Tools for Microfost Visual Studio.  
  - Documentation (good to have).  
  
And whatever else you want to. Although... it can be changed any time..

After the installation finished you have to configure Visual studio to work with unity. To do this follow the steps below:  

1, open Visual Studio Installer - or - Open visual studio and go to Tools/Get tools and features...  
2, Install modules shown below:
  - Desktop development with c++ (used for meking plugins if needed not very important)  
  - .NET desktop development (.NET Core, Framework)  
  - Universal Windows Platform development (graphics debugger and GPU profiler for directX)  
  - Game development with Unity (Dont need the Editor cause we already have one, just the VS tools for unity, and the C# and VB stuff)  
  
3, After installation finished close both VS, Unity and Unity Hub  

Settings for unity:  
The only settings needed to changed are the Script editing IDE. To do this follow steps below:  
1, Check out the repo, create a new branch under your name based on the master branch  
2, Start Unity Hub.  
3, Go to "Projects" menu  
4, Click on the huge white "Add" button  
5, Select the <CheckOutDir>/CardGamesProject folder and hit Select Folder  
6, The Project should now be shown in the list with its info: Name: CardGamesProject, Unity version: 2019.3.7f1 etc..  
7, Click on the project to open it.  
8, After Unity started go to Edit/preferences.../External Tools  
9, Set the "External Script Editor" to "Visual Studio 2019 (Community)", Tick "Generate all .csproj files" and "Editor Attaching"  
10. DONE  
  
If you reached this point or encountered any problems ask me for a quick brief consultation to get started.
  -  
 
  
  
