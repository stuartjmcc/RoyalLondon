DESIGN:
CustomerClass:
This part of the design does all the work and is designed to be called from an external source.
This element of the project I would assume would be versioned controlled as a Nuget package or similar.

DrivingApplication:
A basic app to drive the above class. This could easily have just been a console app or service.

BodyTextTemplate:
For flexibilility I designed the CustomerClass to operate with a template to enable manual editing
of the output file without having to address code changes. The mechanism for using this system is not
documented but I'd expect such things to be made available.

VALIDATION:
As the requirement made no specific mention of how errors would be handled I have made an assumtion that 
all data and processing errors would be thrown away but would not stop the file from continuing to process. 
Ordinarily I'd expect record errors to be recorded for correction in later runs of the code. 
The DrivingApplication validates what it can and informs the user of the respective issue - different handling
would be required with a different driving mechanism.

TESTING:
The design is aimed at testing at two levels with unit tests
CustomerHandler - can just test if the class has all the information needed to start processing.
	Tests would include:
		- Template present
		- Output area valid
		- Source CSV file present
CustomerRecord - as I have thrown away all the processing errors the unit tests here are limited to:
		- Is the record valid
		- Are the requirements being met e.g. Date formats, rounding scenarios

No testing has been included in the project because the agent has been waiting patiently for this and
I'm just not being able to find the time to get it done to my satisfaction so unfortunately this will
have to to - apologies! Typically I'd expect the tests to be defined at the design discussion stage so
really I should have started there.

NOTES:
- Where I have made an assumtion I have I have marked it as such
- Most of these assumtions reiterate the above.