pipeline {
    agent any
	
	parameters {
        string(defaultValue: "TestAPI2.sln", description: 'name of solution file', name: 'solutionName')
		string(defaultValue: "APITests/APITests.csproj", description: 'name of test file', name: 'testName')
		string(defaultValue: "api_image", description: 'name of docker image', name: 'docker_image_name')
		string(defaultValue: "chinmaypadole", description: 'registry_name', name: 'registry_name')
		string(defaultValue: "chinmay_repo", description: 'repository_name', name: 'repository_name')
		string(defaultValue: "api_tag", description: 'tag name', name: 'tag_name')
		string(defaultValue: "40001", description: 'port number', name: 'port_no')
		
		string(defaultValue: "TestAPI2/Publish", description: 'publish path', name: 'publishPath')
		string(defaultValue: "TestAPI2.dll", description: 'dll name', name: 'dllName')

		
		
		string(defaultValue: "api_tag", description: 'tag name', name: 'tag_name')
		string(defaultValue: "/bin/sonar-scanner.bat", description: 'sonar scanner path', name: 'sonarpath')

    }
	
    stages { 
	    
	stage('SonarQube stage') {
        	
        	steps{
        		echo 'Code analysis uisng sonarqube'
				
				script {
             scannerHome = tool 'sonarscanner';
        }
     withSonarQubeEnv('sonar') {
         bat "${scannerHome}%sonarpath%" 
    }
        	}
        }
        
	    
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
        		bat 'docker build --build-arg publish_path=%publishPath% -e SOLUTION_DLL=%dllName% -t %docker_image_name% -f Dockerfile .'				
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
				bat 'docker tag %docker_image_name% %registry_name%/%repository_name%:%tag_name%'
				bat 'docker push %registry_name%/%repository_name%:%tag_name%' 
				bat 'docker rmi %registry_name%/%repository_name%:%tag_name%'
        	}
        }
		
		stage('Docker pull Image') {
        	
        	steps{
        		echo 'Docker pull image from dockerhub'
				bat 'docker pull %registry_name%/%repository_name%:%tag_name%'        		
        	}
        }
		
		stage('Docker run image') {
        	
        	steps{
        		echo 'Docker run the image pulled from dockerhub'
				bat 'docker run --rm -p %port_no%:%port_no% %registry_name%/%repository_name%:%tag_name%'        		
        	}
        }
		
		
    }
	}


