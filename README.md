# CSBotnet

CSBotnet is a C# botnet management system, consisting of a **Server** and **Client**. It allows centralized control and monitoring of connected clients.

---

## Table of Contents

1. [Overview](#overview)
2. [Screenshots](#screenshots)
3. [Features](#features)
4. [Requirements](#requirements)
5. [Installation](#installation)
6. [Usage](#usage)
7. [Configuration](#configuration)

---

## Overview

CSBotnet is designed to manage multiple clients from a server application. Clients connect to the server, allowing command execution and remote monitoring. It is primarily a C# educational project demonstrating networked client-server communication.

---

## Screenshots

<img width="1082" height="650" alt="Capture d&#39;écran 2025-11-30 175227" src="https://github.com/user-attachments/assets/829c7e6d-4711-4ee3-bcbe-930f4facadca" />
<img width="1097" height="684" alt="Capture d&#39;écran 2025-11-30 175104" src="https://github.com/user-attachments/assets/769c8112-ff89-42bd-be4b-a647f44c6b52" />
<img width="1109" height="622" alt="Capture d&#39;écran 2025-11-30 175043" src="https://github.com/user-attachments/assets/ae69def5-d43e-49ad-80a6-5e5f1eddd126" />
<img width="1147" height="660" alt="Capture d&#39;écran 2025-11-30 175254" src="https://github.com/user-attachments/assets/9f9d1efc-a142-4f0f-b3aa-cf3a2f7cca8f" />

---

## Features

* Server-client architecture in C#.
* Centralized management of connected clients.
* Send commands from server to clients.
* Simple Windows Forms interface for server control.
* Real-time monitoring of client connections.

---

## Requirements

* Windows OS
* .NET SDK 8.0
* Visual Studio for building the project

---

## Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/NoonePYDEV/CSBotnet.git
   ```

2. Open the solution in Visual Studio.

3. Restore NuGet packages if prompted.

4. Build **CSBotnet.Server** and **CSBotnet.Client** projects.

---

## Usage

1. Run **CSBotnet.Server** on the control machine.
2. Deploy **CSBotnet.Client** on machines to be connected.
3. Connect clients to the server using the server's IP and port.
4. Manage clients via the server UI:

   * View connected clients
   * Send commands to clients
   * Monitor activity in real time

---

## Configuration

* Configure the server's IP and port in the server project.
* Configure the client to point to the server's address.
* Optional: adjust firewall settings to allow TCP connections between server and clients.

---

