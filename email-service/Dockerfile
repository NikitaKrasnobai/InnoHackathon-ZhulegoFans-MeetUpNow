FROM openjdk:23-ea-21 as build

COPY target/email-service-0.0.1-SNAPSHOT.jar .
EXPOSE 8082
ENTRYPOINT ["java","-jar","/email-service-0.0.1-SNAPSHOT.jar"]