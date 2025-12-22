# 🍓 Strawberries – Microservices E-Commerce System

> A production-ready backend system built with **.NET 8** following **Microservices Architecture**,  
> focusing on **Clean Architecture, CQRS, Event-Driven Communication, and Dockerized Infrastructure**.

---

## 📌 Project Overview

**Strawberries** is a backend-focused e-commerce system developed as part of an advanced microservices learning journey.  
The project was initially inspired by **educational material from Rahul**, with all code, implementation, and refinements independently built to reinforce a deep understanding of backend architecture and distributed systems.

> ⚠️ The **Frontend is intentionally not completed**, as the main goal of this project is to **strengthen backend fundamentals, system design, and distributed systems concepts**.

---

## 🧠 Key Learning Objectives

This project was built to gain **hands-on experience** with:

- Designing scalable **Microservices Architecture**
- Applying **Clean Architecture** principles
- Implementing **CQRS & MediatR**
- Building **Event-Driven Systems**
- Service-to-service communication using **gRPC**
- Containerization using **Docker & Docker Compose**
- Logging, Monitoring, and API Versioning

---

## 🧩 Microservices Implemented

### 🏷️ Catalog Microservice
- Manages products, brands, and categories
- CRUD operations
- Advanced filtering, sorting & pagination
- MongoDB as a database
- RESTful API with Swagger documentation

### 🛒 Basket Microservice
- Shopping cart management
- Redis for high-performance caching
- Communicates with Discount Service via gRPC
- Publishes checkout events to RabbitMQ

### 💰 Discount Microservice
- High-performance gRPC service
- PostgreSQL + Dapper
- Coupon & discount management
- Fully Dockerized

### 📦 Ordering Microservice
- Order processing and management
- SQL Server + Entity Framework Core
- CQRS with command & query separation
- FluentValidation & global exception handling
- Integrated with RabbitMQ

---

## 🔄 Communication & Integration

- ✅ **gRPC** → Basket ↔ Discount
- ✅ **RabbitMQ (Event-Driven)** → Basket → Ordering
- ✅ **MassTransit** for message bus abstraction
- ✅ Correlation IDs for request tracing

---

## 🏗️ Architecture & Design Patterns

- Clean Architecture
- CQRS (Command Query Responsibility Segregation)
- Repository Pattern
- Event-Driven Architecture
- Database per Microservice
- Dependency Injection

---

## 📚 Core Libraries & Tools

The project relies on a carefully selected set of libraries and tools to support scalability, maintainability, and performance in a distributed system environment.

| Purpose | Library / Tool |
|-------|---------------|
| Backend Framework | ASP.NET Core (.NET 8) |
| Clean Architecture & CQRS | MediatR |
| Event-Driven Messaging | MassTransit + RabbitMQ |
| Inter-service Communication | gRPC |
| NoSQL Database | MongoDB.Driver |
| Relational Database (Orders) | Entity Framework Core |
| Relational Database (Discounts) | Dapper + PostgreSQL |
| Caching | Redis |
| Validation | FluentValidation |
| Logging | Serilog |
| API Documentation | Swagger / OpenAPI |
| Containerization | Docker & Docker Compose |
| Container Management | Portainer |
| Monitoring & Log Analysis | Elasticsearch & Kibana (ELK Stack) |

> Each library was chosen to address a specific architectural or performance concern, ensuring the system remains modular, testable, and production-ready.

---

## 🐳 Infrastructure & DevOps

- Docker & Docker Compose
- Portainer for container management
- Centralized logging with **Serilog**
- ELK Stack (Elasticsearch + Kibana)
- Health Checks & Retry Policies
- Persistent volumes for databases

---

## 🔢 API Versioning

- Basket API supports **v1 & v2**
- Swagger documentation per version
- Backward compatibility ensured
- Improved data security in v2

---

## 🚀 How to Run the Project

### 1️⃣ Clone the Repository
```bash
git clone https://github.com/Hasanqp/Strawberries.git
cd Strawberries
```
---

### 2️⃣ Run Using Docker
```bash
docker-compose up --build
```
---

## 3️⃣ Access the Services
Once all containers are running, you can access:
- Catalog Service: http://localhost:8000/swagger
- Basket Service: http://localhost:8001/swagger
- Ordering Service: http://localhost:8004/swagger
- Discount gRPC Service: http://localhost:8003 (gRPC endpoint)
- Portainer (Container Management): http://localhost:9000
- Kibana (Log Analysis): http://localhost:5601

---

## 🚀 Features

- ✅ Fully Dockerized microservices environment
- ✅ Event-driven architecture using RabbitMQ
- ✅ High-performance caching with Redis
- ✅ Database-per-microservice design
- ✅ Scalable and modular backend
- ✅ API versioning with Swagger documentation

---

## 🔮 Future Enhancements

- Implement Frontend UI (Angular)
- Add Authentication & Authorization
- Unit & Integration Testing
- CI/CD pipelines for automatic deployment
- Cloud deployment (Azure / AWS)

---

## 👥 Contributors
Hasanqp – Backend Development · Microservices Architecture · Docker · System Design.

---

## 📬 Contact
- GitHub: [https://github.com/Hasanqp](https://github.com/Hasanqp)
- LinkedIn: [https://www.linkedin.com/in/hasan-gubran](https://www.linkedin.com/in/hasan-gubran/)
