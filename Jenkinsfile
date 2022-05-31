pipeline {
    agent any
   
    stages {
         stage('Build 0'){
           steps{
               sh 'export PATH=$PATH:/home/ubuntu/dotnetcoresdk/.dotnet'
            }
         }
                 stage('Build 1'){
           steps{
               sh 'export DOTNET_ROOT=/home/ubuntu/dotnetcoresdk/.dotnet'
            }
         }
       
        stage('Build'){
           steps{
               sh '/home/ubuntu/dotnetcoresdk/.dotnet/dotnet build CustomURL02.sln'
            }
         }
       
       
        
    }
}
