# 🧠 Cache Aside Pattern (ASP.NET Core + Redis)

A practical implementation of the **Cache Aside (Lazy Loading) Pattern** using ASP.NET Core, Redis, and SQL Server.

🚀 This project demonstrates how real-world backend systems improve performance by reducing database load using caching.

> Part of the **System Design Learning Series**

---

## ⚡ Quick Understanding

* First request → Data comes from **Database (Cache Miss)**
* Next requests → Data comes from **Redis (Cache Hit)**
* Cache expires after 5 minutes → refreshed from DB

👉 Result: Faster responses + reduced database load

---

## 📖 Overview

The **Cache-Aside Pattern** is one of the most widely used caching strategies in modern applications.

### How it works:

1. Application checks cache first
2. If data exists → return immediately (**Cache Hit**)
3. If not → fetch from database (**Cache Miss**)
4. Store data in cache
5. Return response

---

## 🏗️ Architecture

```
Controller
   ↓
Service Layer
   ↓
Database (SQL Server) + Cache (Redis)
```

---

## 🔄 Data Flow

```
Request → Check Cache
        → Hit → Return Data
        → Miss → Fetch DB → Store in Cache → Return
```

---

## 🔌 API Example

### GET /api/test/data

**First Request:**

* Fetches data from database
* Stores in Redis
* Slower response

**Subsequent Requests:**

* Data returned from Redis
* Faster response

---

## 🛠️ Tech Stack

* ASP.NET Core (.NET 8)
* Redis (Distributed Cache)
* Entity Framework Core
* SQL Server

---

## 📈 Benefits

* 🚀 Faster response time
* 📉 Reduced database load
* 📊 Better scalability
* ⚡ Efficient for frequently accessed data

---

## ⚠️ Limitations

* Risk of stale data
* Requires proper cache invalidation strategy

---

## 🎯 Why This Matters

This pattern is widely used in:

* E-commerce systems (product caching)
* Banking systems (frequent queries)
* High-traffic APIs

👉 Understanding this helps in designing **scalable backend systems**

---

## 🧪 How to Run

1. Run Redis (local or Docker)
2. Run the ASP.NET Core project
3. Test APIs using Swagger or Postman

---

## 🔄 What’s Next?

👉 Cache Invalidation — handling stale data properly

---

## 💡 Key Learning

Understanding **when to use caching** is more important than just implementing it.

---
