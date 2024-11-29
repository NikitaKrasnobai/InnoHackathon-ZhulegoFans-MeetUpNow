package com.fialka.email_service.contract;

import lombok.Builder;
import lombok.Data;

import java.time.LocalDate;
import java.util.UUID;

@Data
@Builder
public class EventDTO {
    private UUID id;
    private String name;
    private String description;
    private LocalDate time;
    private String emailAddress;
}