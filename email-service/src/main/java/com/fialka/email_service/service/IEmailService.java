package com.fialka.email_service.service;


public interface IEmailService {
    void sendMessage(String to, String subject, String text);
}
