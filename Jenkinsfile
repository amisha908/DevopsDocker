pipeline {
  agent any
  triggers {
    // Trigger the pipeline on every commit to the master branch
    githubPush()
  }
  stages {
    stage('Git Checkout') {
      steps {
        git 'https://github.com/vinay301/jenkins-demo.git'  
      }
    }
  }
}