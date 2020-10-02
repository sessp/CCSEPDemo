# Group 7 - CCSEP Demo

![CCSEP - Demo](demo/login.png)

# Program Description 
This program is a website that has some other use which is not relevant to the assignment. The functionality that is relevant to the assignment is the logging of incorrect login attempts. When a user completes an invalid login attempt the server logs the inputted username and password. All the usernames and passwords of invalid login attempts are able to be seen by admins when they login. No real world website, or system for that matter, would operate like this. This is simply a proof of concept type of program. In this program when the user enters any password or username other than "admin" it counts as an invalid attempt and thus the attempt is logged. 

# Program Specs
We recommend using Windows to test the **master** and **final_patched** branches. Any issues contact us and we will happily help or even do an assignment demonstration if you wish. The framework used is the .NET Framework, specifically .NET Core and .NET MVC and uses ASP. The programming languages are JavaScript, C##, JQuery + AJAX and HTML. You should not need to download anything, no frameworks, nada, if you use **Visual Studio** to run this program (which is what we recommend since we cant guarantee it will work on anythigng else).

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
### Detecting Step by Step
1. Simply create a detection string/test string (a simple alert(1) JS script will do it for detection).
2. Insert your string into all the user inputs on the login page.
3. Once you have submitted all your test strings in type into the password or userfield "admin", to simulate logging in as an admin. 
4. If an alert appears when you login (when you type "admin" in either the password or the login field) then you have detected it!
5. If you want an extra challenge use a call home payload, in the real world the hacker wouldn't actually know he detected it or exploited it without a call home payload/part of the payload.
### Exploiting
1. Use various malicious Javascript functions/functionality to get someones cookies and send it back to you, to log someones keys or to do other malicious stuff which we discussed in our presentation. 
2. Do it the same way as in the detecting phase, except put it into the fields that you know are vulnerable rather than all of them.
3. Note we only use simple alert scripts (in both the demo and our test files), for obvious reasons. However it is not too hard actually put in a malcious script rather than an innocent alert script.
### Patching
1. Enable Content Security Policy
   * In our example it's in the web.config file in the CCSEPAssignment directory (not the web.config in the views directory).
   * You simply add your policy/rule and then test and edit the rule depending on the functionality of your website. Because our website has no other functionality we block most other scripts. In reality if this was a fully functioning website you would have to set up and test the CSP properly/put a lot of care into it.
   * In our case to patch you just uncomment the following code in that web.config file:
   ```       
          <httpProtocol>
		  <customHeaders>
			  <add name="Content-Security-Policy" value="default-src 'self'; style-src 'self' 'unsafe-inline'; script-src 'self' 'nonce-123456';" />
		  </customHeaders>
	 </httpProtocol> 
2. Encode Input and Output
   * In our example we HTML encode. As we said in the presentation there are many types of encoding and it all depends on where the untrusted user data is. Because ours is being inserted into the HTML (When we append/update the <table></table> we must use HTML encoding. 
   * It is best to use a library to encode. We use a HTML encoding method provided by the System.Web.Security.AntiXss library, a .NET Framework library.
   * Specifically in our program make sure our encoder lines in the ValuesController Add method are uncommented for the encoding to work and make sure you pass those variables to the mock database, rather than data.username and data.password.
   ```
            string encodedUsername = AntiXssEncoder.HtmlEncode(data.username, false);
            string encodedPassword = AntiXssEncoder.HtmlEncode(data.password, false); 
            return MockDatabase.getDB().add(encodedUsername, encodedPassword); 
3. Validate Input and Output
   * In our demo we use an extremely basic validator. **DO NOT USE THIS** in the real world, it would do next to nothing. Our validator is simply there as another proof of concept.
   * You can make your own validator or you can use a library to perform validation for you.
   * Specifically in our program make sure our custom validator lines in the ValuesController Add method are uncommented for the validator to work and make sure you pass those variables to the mock database, rather than data.username and data.password. Uncomment the following code in the ValuesController, located in the Controller directory, located in the CCSEPAssignment project :
   ```        CustomValidator validator = new CustomValidator();
              string validUsername = validator.antiXssValidation(data.username);
              string validPassword = validator.antiXssValidation(data.password);
              return MockDatabase.getDB().add(validUsername, validPassword); 

## About 

Cross-site scripting is a widespread breed of web vulnerabilities which allows hackers to inject malicious code from their untrusted websites into the webpages that are are being viewed by unknowing victims. Second Order cross side scripting is a specific type of XSS attack where the payload is consumed by some inner functionality in the program and affects multiple users when the inner functionality or some other functionality in the program reflects the payload to a number of users. Second Order XSS is not instaneous and it can take a significant amount of time before the program uses the inner functionality and reflects the payload back at unsuspecting users. 

## Google slides

* https://docs.google.com/presentation/d/1B_Zfi9v9PkJHw7hkjxCTDZ8ytnqP8fqlb0EMikIOrVw/edit?usp=sharing

## Credits

* Rares Popa - 19159700
* Peter Sessarego - 19127639
* Sebastian Ng - 19092986

In terms of contribution each member was responsible for one of the parts on the marking rubric. Peter was responsible for the Demo program, Rares for the presentation and Sebastian for the slides.

## Prerequisites 

* Visual Studio
* Theoretically any OS will do however I highly recommend using **Windows** (since it is the .NET Framework)


# Note to marker (Couple of issues to address)
There are a couple of issues to address with this program. 
1. Testing
   * Because it is a website and creating proper tests with a framework is harder than say a C program the only real testing we did was we provided a function to upload a file, in which a file with any number of xss exploit statements/strings can be present in, in order to test the program. We provided a file with around 8-9 different variation of strings in the tests directory, you are more than welcome to use your own. Generally speaking the patched program, located in both the the final_patched and the patched branch will not trigger that test input file. The nonpatched/vulnerable branches, master and demoversion, will trigger all of those xss strings and you should get alerts when you hit the submit button and get onto the admin page. The input file testing is the only way we figured we could do it as trying to implement unit or integration tests would be extremely difficult, atleast on the Javascript side. The file, or any files you upload (in that same format) will be sufficient indicators for if you identify the vulnerability, exploit it or don't.
2. 4 Branches
   * This brings me onto our second issue to address, there are 4 branches. The ones you should look at are **master** (the vulnerable program) and **final_patched** (the patched version of master branch) branches are what you should look at. Why are there 2 other branches? All 4 branches work on Windows but the reason there is a demoversion and a patched branch is because those branches were the branches used in the demo video. We came across a few issues when trying to get those branches working on non Windows machines, due to the fact that demoversion and patched branches are a Client-Server implementation of the master and final_patched. Therefore as a group we decided to include these branches incase you wanted to see the program we actually used in the demo but those aren't our final "branches"/"submission". If you do want to test out the *demoversion* or *patched* branch you can try to follow the steps in how to run a program, but a) i highly suggest you run it on Windows and b) if there are any problems then feel free to contact one of us (Refer to the lower section for contact details). Note the difference between the *final_patched* + *master* and the *demoversion* + *patched* is simply the way the program is implemented, the master/final_patched is just a client/typical program structure and the demoversion/patched is a client-server architecture/structure of the program, because we wanted to make the video demonstration more realistic. 
3. Because this is a .NET Framework and Visual Studio there is no make file and we were unable to get the docker working correctly. The program is still however very portable and easy to run, simply follow the steps in Running the program section. It will take you longer to read all of this then it will to both setup and run the program.

## Problems
If you're having difficulties running the programs or want Peter to do an assignment demostration of any of the branches/programs then don't hesitate to contact him 19127639@student.curtin.edu.au
If you're having any problems feel free to contact me! 19159700@student.curtin.edu.au
