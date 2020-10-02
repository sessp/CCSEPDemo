# Program Description 
This program is a website that has some other use which is not relevant to the assignment. The functionality that is relevant to the assignment is the logging of incorrect login attempts. When a user completes an invalid login attempt the server logs the inputted username and password. All the usernames and passwords of invalid login attempts are able to be seen by admins when they login. No real world website, or system for that matter, would operate like this. This is simply a proof of concept type of program. In this program when the user enters any password or username other than "admin" it counts as an invalid attempt and thus the attempt is logged. 

# How to run the program
##How to run on windows
* Download the app/clone the repository somewhere locally, preferably in your Visual Studio projects/solutions folder (however it doesnt really matter where).
* Double click CCSEPAssignment.sln and open with the latest version of Visual Studio.
* Press start button and it will run within Visual Studio OR right click on the CCSEPAssignment project, then go to debug and click "Create a new instance".
* It should automatically open a browser when you run it, if not head to the localhost assigned to the solution (view in the properties of the project).
* Have fun hacking, or trying to :D

##How to run on Linux
.NET framework is theoretically supported on Linux and Visual Studio is also available on linux, however I would strongly recommend not using linux to demo this program as none of us have tested it on linux machines and Windows is the best platform to run any of these demos on. If you do decide to run them on Linux we assume the process would be somewhat similar to Mac and Windows, just clone/copy the repository and open/double click the CCSEPAssignment.sln in the main folder. From there just run it in Visual Studio code via the run button or right click on the project CCSEPAssignment and then go to debug and click create a new instance (or equivalent). Again, I would highly recommend you run this demo on **Windows** because I know for a fact all branches work on Windows 100%.

##How to run on Mac
* Download the app.
* Afterwards, Open Visual Studio
* Then, File>Open click the folder and click the .sln
* Press start button and it will run within Visual Studio
* Open a new browser window and go to http://127.0.0.1:8080

# Detecting, exploiting and patching the bug
detecting...
exploiting...
patching...

# Group 7 - CCSEP Demo

![CCSEP - Demo](demo/login.png)

## About 

Cross-site scripting is a widespread breed of web vulnerabilities which allows hackers to inject malicious code from their untrusted websites into the webpages that are are being viewed by unknowing victims. Second Order cross side scripting is a specific type of XSS attack where the payload is consumed by some inner functionality in the program and affects multiple users when the inner functionality or some other functionality in the program reflects the payload to a number of users. Second Order XSS is not instaneous and it can take a significant amount of time before the program uses the inner functionality and reflects the payload back at unsuspecting users. 

## Google slides

* https://docs.google.com/presentation/d/1B_Zfi9v9PkJHw7hkjxCTDZ8ytnqP8fqlb0EMikIOrVw/edit?usp=sharing

## Credits

* Rares Popa - 19159700
* Peter Sessarego - 19127639
* Sebastian Ng - 19092986

## Prerequisites 

* Visual Studio
* Theoretically any OS will do however I highly recommend using **Windows** (since it is the .NET Framework)

## Problems
If you're having difficulties running the programs or want Peter to do an assignment demostration of any of the branches/programs then don't hesitate to contact him 19127639@student.curtin.edu.au
If you're having any problems feel free to contact me! 19159700@student.curtin.edu.au
