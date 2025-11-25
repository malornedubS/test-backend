# Test Backend — Skills Management (Hall Of Fame)

Backend-приложение для управления сотрудниками и их навыками.  
Разработано на **ASP.NET Core 8 + EF Core + PostgreSQL**.

## Функциональность

API предоставляет CRUD-операции для сущности **Person**, включая вложенную коллекцию **Skill**.

## Сущности

### **Person**

```json
{
  "id": 1,
  "name": "Maxim",
  "displayName": "Max",
  "skills": [{ "name": "C#", "level": 8 }]
}
```

### **Skill**

```json
{
  "name": "TypeScript",
  "level": 7
}
```

### API Endpoints

GET /api/v1/persons- Получить всех сотрудников
GET /api/v1/persons/{id}- Получить сотрудника по ID
POST /api/v1/persons- Создать сотрудника
PUT /api/v1/persons/{id}- Обновить сотрудника
DELETE /api/v1/persons/{id}- Удалить сотрудника

### Swagger UI

Доступен после запуска приложения:

https://localhost:7049/swagger
