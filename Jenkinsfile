pipeline {
    agent any
	
	parameters {
        string(defaultValue: "TestAPI2.sln", description: 'name of solution file', name: 'solutionName')
		string(defaultValue: "TestAPI2/bin/Release/netcoreapp2.1/TestAPI2.dll", description: 'path of dll file', name: 'dllPath')
    }
	
    stages { 
        stage('Build') {
        	
        	steps{
        		echo 'Build step'
        		bat 'dotnet build %solutionName% -p:Configuration=release -v:q'
        	}
        }
        stage('Test') {
        	
        	steps{
        		echo 'Test step'
        		bat 'dotnet test %solutionName%'
        	}
        }
        stage('Publish') {
        	
        	steps{
        		echo 'Publish step'
        		bat 'dotnet publish %solutionName%'
        	}
        }

        

    }

}

