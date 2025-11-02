# Speech Synthesis
A lightweight speech synthesis web tool written in C#. 

## Features
- Adjust the voice default volume.
- Switch spoken voices being used.
- Change the voice rate of speed.
- Enter custom text to speak.
- Includes a REST based API for remote calls.

## Screenshots
![Screenshot 1](Media/Screenshots/HomePage.png)

![Screenshot 2](Media/Screenshots/APIHome.png)

## Source Code
View the project's [Source Code](https://github.com/hayes0278/Speech-Synthesis).

## How It Works
- User enters text to synthesize, default is "Testing the speech synthesis app".
- Select the volume level desired, the default is 50%.
- Select the spoken voice desired, the default is Microsoft David Desktop.
- Take the input and generate the voice response.

## Helpful Links
- [Website URL](https://localhost:7021) (Development)
- [API URL](https://localhost:7021/swagger) (Development)

## Limitations
- There is no input checking and sanitation performed either client or server side.
- This project is more Windows server focused, instead of being more platform agnostic.
- The necessary code to be placed in a production environment is not present.