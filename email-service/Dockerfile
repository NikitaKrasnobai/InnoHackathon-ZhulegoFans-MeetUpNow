FROM openjdk:23-ea-21 as build

COPY .mvn .mvn
COPY mvnw .
COPY pom.xml .
COPY src src

RUN ./mvnw -B package -Dmaven.test.skip=true
FROM openjdk:23-ea-21
COPY --from=build target/email-service-0.0.1-SNAPSHOT.jar .
EXPOSE 8082
ENTRYPOINT ["java", "-jar", "email-service-0.0.1-SNAPSHOT.jar"]