pipeline {
    agent any
	
	parameters {
        string(defaultValue: "TestAPI2.sln", description: 'name of solution file', name: 'solutionName')
		string(defaultValue: "APITests/APITests.csproj", description: 'name of test file', name: 'testName')
		string(defaultValue: "api_image", description: 'name of docker image', name: 'docker_image_name')
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
        		bat 'dotnet test %testName%'
        	}
        }
        stage('Publish') {
        	
        	steps{
        		echo 'Publish step'
        		bat 'dotnet publish %solutionName% -c RELEASE -o Publish'
        	}
        }
		
		stage('Docker build and run') {
        	
        	steps{
        		echo 'Docker step'
        		bat 'docker build -t %docker_image_name% -f Dockerfile .'
				bat 'docker run --rm -p 40001:40001 %docker_image_name% '
				
        	}
        }
    }

}

