Project Titan # Project Titan #
Network FPS using Unity rendering engine.
- - - -
## List of elements ##
1. Intro:
    Separate audio and video playback synchronized with each other
Menu:
    Fully programmed menu without external function support
    Programmed setting options for the Unity engine
    3. overload protection
Single player mode:
    1. use of Nvidia HBAO+
    Support for Nvidia Ansel
    3. wind simulation
    4. frame rate monitor
    5. support for the LOD
    6. tessellation
Multiplayer mode:
   1. ability to create a server, being a client in one application
   2. playing in the local network
    3. the random place of the form's rebirth (within the boundaries of the map)
    4 Life or ammunition bonuses or ammunition
    5. updating the number of murders, deaths and experience points
5. payroll
    1. full programming of animation of transitions
    2. the algorithm checks whether the animation has ended, if so, it returns to the menu
6. functions
    Creating a configuration file
    Checking the user ID
    3. an algorithm that allows the user to change the language of the user
    Hash data for the API
7. simple database and button map
8. a program generating a unique user ID
    1. download the serial number of the CPU and motherboard
    2. communication thanks to the socket between the game and the identification program
9. web-based APIs
    1. communication protected by means of hashing
    Using PHP with MySQLi extension
    3. ability to read from the database the number of murders, deaths and the number of experience points
    4. ability to add to the database the number of murders, deaths and experience points
- - - -
## Manner of compilation of the project ##
Please install the Visual Studio package
2. install the Unity rendering engine
After importing the project, it belongs to the **Plugins** folder of the **Ansel** and **JsonNet** libraries.
After a successful compilation, copy the **Assets** folder **LanguageDataBase** and transfer it to **ProjectTitan_Data**.
- - - -
## Possible problems ##
1. no interface after compilation
    The language file has not been copied
Nivida Ansel does not work
    In the driver folder find NvCameraEnable.exe to create a shortcut and add `whitelisting-everything` to it.
- - - -
Example of Nvidia technology:
 ![picture alt](http://i.imgur.com/Dh1kqXo.png 'Nvida <3')
- - - -
