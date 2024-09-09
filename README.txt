==========================================================
=  SPROUT.EXAM.WEBAPP PROJECT SETUP AND CONFIGURATIONS:  =
==========================================================


A.  FRONT-END ADDITIONAL SETUP:
===============================

 1. Make sure NODEJS and NPM versions are installed and updated
 2. Open command prompt
 3. Navigate to folder "\Sprout.Exam.WebApp\ClientApp"
 4. To install/update "node_modules" folder, run below CLI commmand:

	- npm install

 5. After the installation, run CLI command below to Start the React development server:

	- npm start


IMPORTANT NOTE:
---------------
1. Modify the folder paths in the "Log4Net.config" file located in the "\Sprout.Exam.WebApp\Configuration" folder, 
   below sample:
   <file value="C:\_PROJECTS\_SPROUT\_LOGS\Exception_.txt" />
   
2. Modify connection string value in the "appsettings.json" file for new data source dB server connectivity

3. All Regular and Contractual Employee Net Income computaion lookup values are in the "appsettings.json" to be
   configurable for future changes



B. BACK-END SETUP (MS SQL DATABASE):
====================================

1. No any changes on the database side below

	- SproutExamDB11052021.bak



After everything has been prepared/completed, the application should now work. Thanks!


Use this login credentials below for testing:
=============================================
Username: sprout.test@gmail.com 
Password: P@$$word6



For the answer to the question below:
=====================================
Q: "If we are going to deploy this on production, what do you think is the next
    improvement that you will prioritize next? This can be a feature, a tech debt, or
    an architectural design."

A: Below Answers:
-----------------
1. In todays generation, serverless technology is rapidly growing in the world of enterprise software development 
   and so it may be time to delve into cloud technologies such as Azure or AWS

2. In may be time also to apply CI/CD approach for deployment procedures

3. Look into containerization tools like Docker on how it can benefit development/deployment routines
