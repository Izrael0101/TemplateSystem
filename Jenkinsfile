import net.sf.json.JSONArray;
import net.sf.json.JSONObject;


// Ruta para el despliegue
def PATH_DEPLOYMENT
// Ruta para respaldar en caso de tener que hacer rollback
def PATH_BACKUP
// Build para dist
def ENVIROMENT_BUILD
// Analisis con Sonarqube
def SONAR_ANALYSIS
// Compilamos servicio Base
def BASE_SERVICE
// Compilamos servicio File
def FILE_SERVICE
// Compilamos servicio SendInfo
def SENDINFO_SERVICE
// Compilamos servicio News
def NEWS_SERVICE

//Si queremos ejecutar un servicio o realizar el analisis pones el valor de 1
SONAR_ANALYSIS = "0"
BASE_SERVICE = "0"
FILE_SERVICE = "0"
SENDINFO_SERVICE = "0"
NEWS_SERVICE = "0"

pipeline {
 // Cualquier nodo de Jenkins puede realizar el proceso
 agent any

 // Cada minuto se deben comprobar cambios en el repositorio
 triggers {
  pollSCM('* * * * *')
 }

 stages {

  // Proceso de configuración del proyecto
  stage('Setting') {
   steps {
    script {
     // Desarrollo
     if ("${GIT_BRANCH}".contains("development")) {
      PATH_DEPLOYMENT = 'E:\\Cuponera-WS'
      PATH_BACKUP = 'E:\\backup\\Cuponera-WS'
      ENVIROMENT_BUILD = 'Development'
     }

     // QA
     if ("${GIT_BRANCH}".contains("qa")) {
      PATH_DEPLOYMENT = 'E:\\Cuponera-WS'
      PATH_BACKUP = 'E:\\Backup\\Cuponera-WS'
      ENVIROMENT_BUILD = 'QA'
     }

     // PRODUCTION
     if ("${GIT_BRANCH}".contains("master")) {
      PATH_DEPLOYMENT = 'E:\\Cuponera-WS'
      PATH_BACKUP = 'E:\\backup\\Cuponera-WS'
      ENVIROMENT_BUILD = 'Production'
     }
    }
   }
   post {
    always {
     sendSlackNotification("Settings", "always", true)
    }
    success {
     sendSlackNotification("Settings", "success")
    }
    failure {
     sendSlackNotification("Settings", "failure")
    }
   }
  }

  //Analisis de codigo con sonar
  stage('Build && SonarQube analysis') {
   steps {
    script {
     if ("${GIT_BRANCH}".contains("development") && "${SONAR_ANALYSIS}" == "1") {
      withSonarQubeEnv('JenkinsSonarServer') {
       bat 'dotnet sonarscanner begin /k:"Cuponera" /n:"Cuponera" /v:"1.0" /d:sonar.host.url=https://mantisbt.tmanager.com.mx/sonar'
       bat 'dotnet build'
       bat 'dotnet sonarscanner end'
      }
     }
    }
   }

  }

  // Calidar de codigo detiene el pipeline
  stage('Quality Gate') {
   steps {
    script {
     if ("${GIT_BRANCH}".contains("development") && "${SONAR_ANALYSIS}" == "1") {
      timeout(time: 1, unit: 'MINUTES') {
       waitForQualityGate abortPipeline: true
      }
     }
    }
   }
  }


  // Proceso de despliegue
  stage('Deployment') {
   steps {
    sendSlackNotification("Deployment", "always")
    // Se copian los compilados del Front End a la carpeta de despliegue
    bat 'xcopy /E "%WORKSPACE%' + '" "' + "${PATH_DEPLOYMENT}" + '" /c /s /i /Y /v'

   }
   post {

    success {
     sendSlackNotification("Deployment", "success")
    }
    failure {
     sendSlackNotification("Deployment", "failure")
    }
   }
  }




  stage('Base Service Build') {
   steps {
    script {
     if ("${BASE_SERVICE}" == "1") {
      bat "dotnet restore ${PATH_DEPLOYMENT}\\CUP_BaseServices\\CUP_BaseServices.csproj"
      bat "dotnet clean ${PATH_DEPLOYMENT}\\CUP_BaseServices\\CUP_BaseServices.csproj"
      bat "dotnet build ${PATH_DEPLOYMENT}\\CUP_BaseServices\\CUP_BaseServices.csproj --configuration Release"
      bat "dotnet publish ${PATH_DEPLOYMENT}\\CUP_BaseServices\\CUP_BaseServices.csproj --configuration Release"	
      bat 'dotnet run --project ${PATH_DEPLOYMENT}\\CUP_BaseServices ASPNETCORE_ENVIRONMENT=Development ASPNETCORE_URLS=http://0.0.0.0:22222'
     }

    }
   }
   post {

    success {
     sendSlackNotification("BaseService", "success")
    }
    failure {
     sendSlackNotification("BaseService", "failure")
    }
   }
  }


  stage('File Service Build') {
   steps {
    script {
     if ("${FILE_SERVICE}" == "1") {
      bat "dotnet restore ${PATH_DEPLOYMENT}\\CUP_FileManagerServices\\CUP_FileManagerServices.csproj"
      bat "dotnet clean ${PATH_DEPLOYMENT}\\CUP_FileManagerServices\\CUP_FileManagerServices.csproj"
      bat "dotnet build ${PATH_DEPLOYMENT}\\CUP_FileManagerServices\\CUP_FileManagerServices.csproj --configuration Release"
      bat "dotnet publish ${PATH_DEPLOYMENT}\\CUP_FileManagerServices\\CUP_FileManagerServices.csproj"	
      bat 'dotnet run --project ${PATH_DEPLOYMENT}\\CUP_FileManagerServices ASPNETCORE_ENVIRONMENT=Development ASPNETCORE_URLS=http://0.0.0.0:33333'
     }
    }
   }
   post {

    success {
     sendSlackNotification("FileService", "success")
    }
    failure {
     sendSlackNotification("FileService", "failure")
    }
   }
  }



  stage('SendInfo Service Build') {
   steps {
    script {
     if ("${FILE_SERVICE}" == "1") {
      bat "dotnet restore ${PATH_DEPLOYMENT}\\CUP_SendInfoService\\CUP_SendInfoServices.csproj"
      bat "dotnet clean ${PATH_DEPLOYMENT}\\CUP_SendInfoService\\CUP_SendInfoServices.csproj"
      bat "dotnet build ${PATH_DEPLOYMENT}\\CUP_SendInfoService\\CUP_SendInfoServices.csproj --configuration Release"
      bat "dotnet publish ${PATH_DEPLOYMENT}\\CUP_SendInfoService\\CUP_SendInfoServices.csproj"	
      bat 'dotnet run --project ${PATH_DEPLOYMENT}\\CUP_SendInfoService ASPNETCORE_ENVIRONMENT=Development ASPNETCORE_URLS=http://0.0.0.0:44444'
     }
    }
   }
   post {

    success {
     sendSlackNotification("SendInfoService", "success")
    }
    failure {
     sendSlackNotification("SendInfoService", "failure")
    }
   }
  }




  stage('News Service Build') {
   steps {
    script {
     if ("${FILE_SERVICE}" == "1") {
      bat "dotnet restore ${PATH_DEPLOYMENT}\\CUP_NewsNotificationServices\\CUP_NewsNotificationServices.csproj"
      bat "dotnet clean ${PATH_DEPLOYMENT}\\CUP_NewsNotificationServices\\CUP_NewsNotificationServices.csproj"
      bat "dotnet build ${PATH_DEPLOYMENT}\\CUP_NewsNotificationServices\\CUP_NewsNotificationServices.csproj --configuration Release"
      bat "dotnet publish ${PATH_DEPLOYMENT}\\CUP_NewsNotificationServices\\CUP_NewsNotificationServices.csproj"
      bat 'dotnet run --project ${PATH_DEPLOYMENT}\\CUP_NewsNotificationServices ASPNETCORE_ENVIRONMENT=Development ASPNETCORE_URLS=http://0.0.0.0:55555'
     }
    }
   }
   post {

    success {
     sendSlackNotification("NewsService", "success")
    }
    failure {
     sendSlackNotification("NewsService", "failure")
    }
   }
  }


  stage('Clean') {
   steps {
    cleanWs();
   }
  }


 }
}




def sendSlackNotification(String stageName, String stageStatus, boolean isFirstStage = false) {
 // Objeto que contiene los campos de la notificación
 JSONObject attachment = new JSONObject();

 // Color azul por defecto
 String color = "#6ecadc";

 // Fallback se utiliza cuando no es posible enviar la notificación
 attachment.put('fallback', 'Hey, Vader seems to be mad at you.');

 // Se agrega mensaje indicando el JOB DE JENKINS
 attachment.put('title', " '${env.JOB_NAME}' \n\n");

 if (stageStatus == "always") {
  if (isFirstStage) {

   def commit = bat(returnStdout: true, script: '@git rev-parse HEAD')

   def author = bat(returnStdout: true, script: "@git --no-pager show -s --format=%%an").trim()

   // Obtiene el encabezado
   def messageCommit = bat(returnStdout: true, script: '@git log -1 --pretty=%%B').trim();
   def content = "Se ha iniciado un nuevo despliegue...\n\n'${env.JOB_NAME}' '[${env.BUILD_NUMBER}]'\n'${GIT_BRANCH}'\n Mensaje: '${messageCommit}'\n\n";

   echo messageCommit
   echo content
   echo isFirstStage.toString()

   // Color amarillo
   color = "#e9a820";

   // Se agrega Tittle Author
   JSONObject commitAuthor = new JSONObject();
   commitAuthor.put('title', "Autor:");
   commitAuthor.put('value', author.toString());
   commitAuthor.put('short', true);

   JSONObject commitHash = new JSONObject();
   commitHash.put('title', "Commit:");
   commitHash.put('value', commit.toString());
   commitHash.put('short', false);

   attachment.put('fields', [commitHash, commitAuthor]);

   // Se agrega el mensaje
   attachment.put('text', content.toString());
  } else {
   // Se agrega el mensaje
   attachment.put('text', 'Se ha iniciado el proceso ' + stageName);
  }
 }

 if (stageStatus == "success") {
  // Color verde
  color = "#3eb991";

  // Se agrega el mensaje
  attachment.put('text', 'El proceso ' + stageName + ' se ha completado con exito');
 }

 if (stageStatus == "failure") {
  // Color rojo
  color = "#e01563";

  // Se agrega el mensaje
  attachment.put('text', 'Se ha presentado un problema en el proceso ' + stageName);
 }

 // Se agrega el color
 attachment.put('color', color);

 // Permite realizar la serialización de los campos de la notificación
 JSONArray attachments = new JSONArray();

 // Se agregan los campos de la notificación
 attachments.add(attachment);

 // Se envía la notificación
 slackSend(color: color, channel: '#jenkins-tsk', attachments: attachments.toString());
}