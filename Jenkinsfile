pipeline {
    agent any
    triggers {
        githubPush()
    }
    stages {
        stage('Restore packages'){
           steps{
               sh 'dotnet restore CustomURL01.sln'
            }
         }
        stage('Clean'){
           steps{
               sh 'dotnet clean CustomURL01.sln --configuration Release'
            }
         }
        stage('Build'){
           steps{
               sh 'dotnet build CustomURL01.sln --configuration Release --no-restore'
            }
         }
       
        stage('Publish'){
             steps{
               sh 'dotnet publish CustomURL01.csproj --configuration Release --no-restore'
             }
        }
        
    }
}
