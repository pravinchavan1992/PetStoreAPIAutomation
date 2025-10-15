
# Pet Store API Automation
This project automates CRUD operations on the Swagger Petstore API using **C#**, **HttpClient**, and **NUnit**.


## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [Allure Commandline](https://docs.qameta.io/allure/#_installing_a_commandline) 

---

## Project Structture
PetStoreAPIAutomation/
├── ApiClient/ # API client logic
│ ├── Models/ # Pet, Order, Category, Tag classes
│ └── Services/ # HttpClient services for Pet and Order
├── Tests/ # NUnit test cases
│ └── TestData/ # Sample data helpers
├── runtest.sh # Bash script to run tests & generate report
└── README.md

## Setup

1. Clone the repository:

```bash
git clone https://github.com/your-username/PetStoreAPIAutomation.git
cd PetStoreAPIAutomation
```

2. Restore the dependencies:

```bash
dotnet restore
```

3. Build the project:

```bash
dotnet build
```
4. Run the tests (Without Allure Reports):

```bash
dotnet test
```

## Running the Tests with Allure
```bash
./runtest.sh
allure open allure-report
```



