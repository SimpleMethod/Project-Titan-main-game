# Project Titan #
Network FPS using Unity rendering engine.
- - - -
## List of elements ##
1. Intro:
    1. Separate audio and video playback synchronized with each other
2. Menu:
    1. Fully programmed menu without external function support
    2. Programmed setting options for the Unity engine
    3. Overload protection
3. Single player mode:
    1. Use of Nvidia HBAO+
    2. Support for Nvidia Ansel
    3. Wind simulation
    4. Frame rate monitor
    5. Support for the LOD
    6. Tessellation
4. Multiplayer mode:
    1. Ability to create a server, being a client in one application
    2. Playing in the local network
    3. The random place of the form's rebirth (within the boundaries of the map)
    4  Life or ammunition bonuses or ammunition
    5. Updating the number of murders, deaths and experience points
5. payroll
    1. Full programming of animation of transitions
    2. The algorithm checks whether the animation has ended, if so, it returns to the menu
6. functions
    1. Creating a configuration file
    2. Checking the user ID
    3. Algorithm that allows the user to change the language of the user
    4. Hash data for the API
7. Simple database and button map
8. Program generating a unique user ID
    1. download the serial number of the CPU and motherboard
    2. communication thanks to the socket between the game and the identification program
9. Web-based APIs
    1. Communication protected by means of hashing
    2. Using PHP with MySQLi extension
    3. Ability to read from the database the number of murders, deaths and the number of experience points
    4. Ability to add to the database the number of murders, deaths and experience points
- - - -
## Manner of compilation of the project ##
1. Please install the Visual Studio package
2. Install the Unity rendering engine
3. After importing the project, it belongs to the **Plugins** folder of the **Ansel** and **JsonNet** libraries.
4. After a successful compilation, copy the **Assets** folder **LanguageDataBase** and transfer it to **ProjectTitan_Data**.
- - - -
## Possible problems ##
1. No interface after compilation
    1. The language file has not been copied
2. Nivida Ansel does not work
    1. In the driver folder find NvCameraEnable.exe to create a shortcut and add `whitelisting-everything` to it.
- - - -
Example of Nvidia technology:
 ![picture alt](http://i.imgur.com/Dh1kqXo.png 'Nvida <3')
- - - -
