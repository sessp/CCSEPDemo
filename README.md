# Program Description 
This program is a website that has some other use which is not relevant to the assignment. The functionality that is relevant to the assignment is the logging of incorrect login attempts. When a user completes an invalid login attempt the server logs the inputted username and password. All the usernames and passwords of invalid login attempts are able to be seen by admins when they login. No real world website, or system for that matter, would operate like this. This is simply a proof of concept type of program. In this program when the user enters any password or username other than "admin" it counts as an invalid attempt and thus the attempt is logged. 

# How to run the program
## How to run on windows
* Download the app/clone the repository somewhere locally, preferably in your Visual Studio projects/solutions folder (however it doesnt really matter where).
* Double click CCSEPAssignment.sln and open with the latest version of Visual Studio.
* Press start button and it will run within Visual Studio OR right click on the CCSEPAssignment project, then go to debug and click "Create a new instance".
* It should automatically open a browser when you run it, if not head to the localhost assigned to the solution (view in the properties of the project).
* Have fun hacking, or trying to :D

## How to run on Linux
.NET framework is theoretically supported on Linux and Visual Studio is also available on linux, however I would strongly recommend not using linux to demo this program as none of us have tested it on linux machines and Windows is the best platform to run any of these demos on. If you do decide to run them on Linux we assume the process would be somewhat similar to Mac and Windows, just clone/copy the repository and open/double click the CCSEPAssignment.sln in the main folder. From there just run it in Visual Studio code via the run button or right click on the project CCSEPAssignment and then go to debug and click create a new instance (or equivalent). Again, I would highly recommend you run this demo on **Windows** because I know for a fact all branches work on Windows 100%.

## How to run on Mac
* Download the app.
* Afterwards, Open Visual Studio
* Then, File>Open click the folder and click the .sln
* Press start button and it will run within Visual Studio
* Open a new browser window and go to http://127.0.0.1:8080

# Detecting, exploiting and patching the bug
### Detecting
1. Simply create a detection string/test string (a simple alert(1) JS script will do it for detection.
2. Insert your string into all the user inputs on the login page.
3. If an alert appears when you login (when you type admin in either the password or the login field) then you have detected it!
4. If you want an extra challenge use a call home payload, in the real world the hacker wouldn't actually know he detected it or exploited it without a call home payload/part of the payload.
### Exploiting
1. Use various malicious Javascript functions/functionality to get someones cookies and send it back to you, to log someones keys or to do other malicious stuff which we discussed in our presentation. 
2. Note we only use simple alert scripts (in both the demo and our test files), for obvious reasons. However it is not too hard actually put in a malcious script rather than an innocent alert script.
### Patching
1. Enable Content Security Policy
   * In our example it's in the web.config file in the CCSEPAssignment directory (not the web.config in the views directory).
   * You simply add your policy/rule and then test and edit the rule depending on the functionality of your website. Because our website has no other functionality we block most other scripts. In reality if this was a fully functioning website you would have to set up and test the CSP properly/put a lot of care into it.
2. Encode Input and Output
   * In our example we HTML encode. As we said in the presentation there are many types of encoding and it all depends on where the untrusted user data is. Because ours is being inserted into the HTML (When we append/update the <table></table> we must use HTML encoding. 
   * It is best to use a library to encode. We use a HTML encoding method provided by the System.Web.Security.AntiXss library, a .NET Framework library.
   * Specifically in our program make sure our encoder lines in the ValuesController Add method are uncommented for the encoding to work and make sure you pass those variables to the mock database, rather than data.username and data.password.
3. Validate Input and Output
   * In our demo we use an extremely basic validator. **DO NOT USE THIS** in the real world, it would do next to nothing. Our validator is simply there as another proof of concept.
   * You can make your own validator or you can use a library to perform validation for you.
   * Specifically in our program make sure our custom validator lines in the ValuesController Add method are uncommented for the validator to work and make sure you pass those variables to the mock database, rather than data.username and data.password.

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
