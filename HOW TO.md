# BLE-Concussion-Predictor-App-Prototype

This file describes how to download and open this file in Visual Studio.

What you need:
-Visual Studio (Preferrably 2022)

Steps:
1.  Open Visual Studio
2.  Under "Get Started", click 'Clone a repository'
3.  Enter "https://github.com/trevorwhitfield/BLE-Concussion-Predictor-App-Prototype" as repository location.  Set the Path to an empty folder you would like to store your copy of this project in
4.  Click clone repository
5.  Once your file is cloned, open the .sln file in its folder using visual studio

--Other instructions--

How to load sample data (you will need to do this to test unless you have the arduino and can generate some real data):
1. Launch the app by clicking the play button with the "Windows Machine" label
2. In the app, click the hamburger menu (three vertical lines in the top left)
3. Click save/load
4. Click load
5. Navigate to the folder that contains your respository.  Find the file called Sample data for importing.txt.  Select it and hit yes
6. Wait a few seconds then click the hamburger again and click "Home".  You must wait a few seconds because some coding stuff I did poorly (basically, I have both loading data and viewing the UI done asynchronously, if you try viewing the loaded data while its loading you run into an error that I think is caused by conflicting resources but i'm not sure.  I could've fixed this if I coded it so that only one could make changes at a time)

This app is semi Android compatible but because of some problems with running Bluetooth scans (to find devices that can be paired with) the app crashes on Android right now often).  I will mention more about Android testing when we have our meeting
