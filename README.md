# Eng User Manager

Microservice for managing users, it has layered programming to separate responsibilities using SQLServer as a database.
## Features
Allows you to:
 - Add new a user,
 - Change their status (active, inactive), 
 - Delete
 - Get all active users

## Tech

Used technology:
- Entity Framwork Core (code-first)
- .Net Core 7
- SQL SERVER 2019
- XUnit
- Swashbuckle (Swagger)
- Kubernetes (Minikube)
- HELM

## Pre-requirements
- [Kubectl](https://kubernetes.io/docs/tasks/tools/install-kubectl-windows/)  
- [Docker](https://www.docker.com/) 
- [Minikube](https://minikube.sigs.k8s.io/docs/start/) 
- [Helm](https://helm.sh/docs/intro/install/) (Recommended to install via [Chocolatey](https://chocolatey.org/install), optional) 
- [PowerShell v7](https://learn.microsoft.com/en-us/powershell/scripting/install/installing-powershell-on-windows?view=powershell-7.3)
- [Hyper-V](https://learn.microsoft.com/en-us/virtualization/hyper-v-on-windows/quick-start/enable-hyper-v) enabled 

## Pipeline deployment
On Powershell 7
```sh
.\_pipeline.ps1
```
In the root of solution.
