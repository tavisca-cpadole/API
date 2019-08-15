pipeline {
    agent any
    stages { 
        stage('Restore') {
        	
        	steps{
        		echo 'Restore Step'
        		bat 'dotnet restore'
        	}
        }
        stage('Build') {
        	
        	steps{
        		echo 'Build step'
        		bat 'dotnet build TestAPI2.sln -p:Configuration=release -v:q'
        	}
        }
        stage('Test') {
        	
        	steps{
        		echo 'Test step'
        		bat 'dotnet test'
        	}
        }
        stage('Publish') {
        	
        	steps{
        		echo 'Publish step'
        		bat 'dotnet publish'
        	}
        }
        stage('Deploy') {
        	
        	steps{
        		echo 'Deploy project'
        		bat 'dotnet TestAPI2/bin/Release/netcoreapp2.1/TestAPI2.dll'
        	}
        }
        

    }
    post{
             success{
                 archiveArtifacts artifacts: '**', fingerprint:true
                 bat 'dotnet TestAPI2/bin/Release/netcoreapp2.1/TestAPI2.dll'
             }
        }
}

