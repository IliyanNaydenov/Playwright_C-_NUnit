# 🌟 Playwright + NUnit + C# Automation Framework

This repository provides a fully functional **UI Test Automation Framework** using:

- ✅ [Microsoft Playwright for .NET](https://playwright.dev/dotnet/)
- ✅ [NUnit](https://nunit.org/)
- ✅ [ExtentReports](https://aventstack.com/)
- ✅ Designed for **Desktop** and **Mobile Web** testing
- ✅ Built with **.NET 9** and **Visual Studio 2022**

---

## ✅ Prerequisites

Ensure the following tools are installed:

- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- PowerShell (for installing Playwright dependencies)

---

## 🚀 Getting Started

### 🔧 1. Create a New NUnit Project

```bash
dotnet new nunit -n ProjectName
cd ProjectName
```

### 📆 2. Install Dependencies

Install Playwright and ExtentReports:

```bash
dotnet add package Microsoft.Playwright.NUnit
dotnet add package AventStack.ExtentReports
dotnet add package AventStack.ExtentReports.Core
```

### 🔨 3. Build the Project

```bash
dotnet build
```

### 🌐 4. Install Playwright Browsers

```bash
pwsh bin/Debug/net9.0/playwright.ps1 install --with-deps
```

## 📊 ExtentReports Integration

This framework uses **ExtentReports** for HTML reporting, including:

- Test status (Pass/Fail)
- Detailed logs
- Attached screenshots on failure
- Categorized reports (e.g., Mobile, Desktop)

---

## 🧲 Running Tests

### ▶️ Run Desktop Tests

```bash
dotnet test --settings RunnerDesktop.runsettings --filter "Category=Desktop"
```

### 📱 Run Mobile Tests

```bash
dotnet test --settings RunnerMobile.runsettings --filter "Category=Mobile"
```

---

## 📁 Project Structure Overview

```
/Helpers
    TEstConstants

/PageObject
    GamePage
    HomePage

/Tests
    BaseTest.cs
    WinLostTestsDesktop.cs
    WinLostTestsMobile.cs

/Reports
    TestReport.html
    /Screenshots
    
ReportManager.cs
RunnerDesktop.runsettings
RunnerMobile.runsettings
README.md
```

---

## 📊 Features

- ✅ Page Object Model (POM)
- ✅ Separate classes for Mobile & Desktop tests
- ✅ Device emulation via RunSettings
- ✅ Headless or full-screen control
- ✅ ExtentReport with screenshot support
- ✅ Easy configuration for mobile/desktop testing
