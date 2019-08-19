pipeline {
    agent any
	
	parameters {
        string(defaultValue: "TestAPI2.sln", description: 'name of solution file', name: 'solutionName')
		string(defaultValue: "APITests/APITests.csproj", description: 'name of test file', name: 'testName')
		string(defaultValue: "api_image", description: 'name of docker image', name: 'docker_image_name')
		string(defaultValue: "chinmaypadole/chinmay_repo", description: 'repository_name', name: 'repository_name')

		string(defaultValue: "api_tag", description: 'tag name', name: 'tag_name')
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
		
		stage('Docker build Image') {
        	
        	steps{
        		echo 'Docker image'
        		bat 'docker build -t %docker_image_name% -f Dockerfile .'				
        	}
        }
		
		
		stage('Docker hub Login') {
        	
        	steps{
				withCredentials([usernamePassword(credentialsId: '695944ad-b76b-4e42-8dab-3bf6996c816e', passwordVariable: 'pass', usernameVariable: 'user')]) {					
					echo 'Docker login to dockerhub'
					bat 'docker login -p %pass% -u %user%'   	
				}	
        			
        	}
        }
		stage('Docker push Image') {
        	
        	steps{
        		echo 'Docker push image to dockerhub'
				bat 'docker tag %docker_image_name% %repository_name%:%tag_name%'
				bat 'docker push %repository_name%:%tag_name%' 
				bat 'docker rmi %docker_image_name%:latest'
				bat 'docker rmi %repository_name%:%tag_name%'
        	}
        }
		
		stage('Docker pull Image') {
        	
        	steps{
        		echo 'Docker pull image from dockerhub'
				bat 'docker pull %repository_name%:%tag_name%'        		
        	}
        }
		
		stage('Docker run image') {
        	
        	steps{
        		echo 'Docker run the image pulled from dockerhub'
				bat 'docker run --rm -p 40001:40001 %repository_name%:%tag_name% '        		
        	}
        }
		stage('SonarQube stage') {
        	
        	steps{
        		echo 'Docker run the image pulled from dockerhub'
				bat 'dotnet C:\Users\cpadole\.dotnet\tools\.store\dotnet-sonarscanner\4.3.1\dotnet-sonarscanner\4.3.1\tools\netcoreapp2.1\any\SonarScanner.MSBuild.dll begin /d:sonar.login=admin /d:sonar.password=bitnami /k:"e30c45aee417212a98751051b9244d54f94c9157"'
				bat 'dotnet build'
				bat 'dotnet C:\Users\cpadole\.dotnet\tools\.store\dotnet-sonarscanner\4.3.1\dotnet-sonarscanner\4.3.1\tools\netcoreapp2.1\any\SonarScanner.MSBuild.dll end /d:sonar.login=admin /d:sonar.password=bitnami'
        	}
        }
		
    }

}

