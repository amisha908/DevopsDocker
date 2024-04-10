pipeline {
  agent any
  tools {
    jdk 'JDK17'
  }
  environment {
    sonarScanner = tool 'sonar-scanner' 
  }
  triggers {
    // Trigger the pipeline on every commit to the master branch
    githubPush()
  }
  stages {
    stage('Git Checkout') {
      steps {
        git 'https://github.com/amisha908/DevopsDocker.git'  
      }
    }
    
      stage('SonarQube Analysis') {
      steps {
        withSonarQubeEnv(installationName: 'sonar') {
          sh """${sonarScanner}/bin/sonar-scanner \
            -Dsonar.projectKey=DotnetApp \
            -Dsonar.projectName=DotnetApp"""
        }
      }
     }
  }
}
