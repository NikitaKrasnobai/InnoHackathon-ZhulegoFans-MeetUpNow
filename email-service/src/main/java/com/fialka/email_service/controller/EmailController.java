package com.fialka.email_service.controller;

import com.fialka.email_service.contract.EventDTO;
import com.fialka.email_service.service.IEmailService;
import jakarta.mail.MessagingException;
import jakarta.mail.internet.MimeBodyPart;
import lombok.AllArgsConstructor;
import org.springframework.amqp.rabbit.annotation.EnableRabbit;
import org.springframework.amqp.rabbit.annotation.RabbitListener;
import org.springframework.messaging.handler.annotation.SendTo;
import org.springframework.stereotype.Component;

import java.io.File;
import java.io.IOException;

@EnableRabbit
@Component
@AllArgsConstructor
public class EmailController {

    private IEmailService emailService;

    @RabbitListener(queues = "email-queue")
    @SendTo
    public void sendEmailMessage(EventDTO eventDTO) {
        this.emailService.sendMessage(eventDTO.getEmailAddress(), //
                "на твой телефон пришло новое уведомление", "посмотри, здесь что-то важное");

        // Создание вложения
        MimeBodyPart attachmentBodyPart = new MimeBodyPart();
        try {
            attachmentBodyPart.attachFile(new File("src/main/resources/image/photo.jpg"));
        } catch (IOException e) {
            throw new RuntimeException(e);
        } catch (MessagingException e) {
            throw new RuntimeException(e);
        }
    }
}