DateAdd Comments

1) Ensure DateAdd is set as Startup project.
2) For DateAdd.Tests, ensure NUnit 3 test adaptor extension is installed
3) Have occasionally observed this error on running tests:
		Could not find extensions: C:\USERS\LEEWB\APPDATA\LOCAL\MICROSOFT\VISUALSTUDIO\15.0_C47DB0F9\EXTENSIONS\GIDAEF4U.NN4\NUnit3.TestAdapter.dll
   Seemed to be resolved by restarting VS, as it looks like the NUnit Test Adaptor extension had been auto-updated.