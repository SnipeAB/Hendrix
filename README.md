
# Hendrix - Network Surveillance Toolkit 🔍


# Version 1.0 | Developed by SnipeAE 🔥

# Description

Hendrix is a C#-based security reconnaissance tool designed for network analysis and web server enumeration. Featuring a retro-style console interface with typewriter animation, it integrates popular security tools into a unified interface for penetration testing and network surveillance.

# Key Features ✨

Network Scanner:  
Leverages nmap for host discovery (-Pn) and verbose port scanning (-vv)

Web Directory Brute-forcer:  
Utilizes gobuster with common.txt wordlist for hidden path discovery

Interactive Console UI:  
Typewriter effect animations  
Persistent menu system  
Error handling for invalid inputs

Upcoming Feature:  
Encryption module (placeholder implementation)

# Requirements 📦
.NET 6+ Runtime

Nmap

Gobuster

SecLists repository (common.txt wordlist)

# Important Notes ⚠️

Requires elevated privileges for raw socket operations

Ensure target authorization before scanning

Currently optimized for Linux environments

Wordlist path may need adjustment for your system
## Deployment

# Installation ⚙️
```bash
    git clone https://github.com/SnipeZoidYT/Hendrix.git
    cd Hendrix
    cd Scanner
    # Install dependencies:
    sudo apt install nmap gobuster seclists
    sudo apt-get install -y mono-mcs
```
# Usage 🖥️
```bash
    mcs -out:Program.exe Program.cs
    mono Program.exe
```

## Legal Disclaimer ⚖️

This tool is intended for authorized security testing and educational purposes only. Unauthorized network scanning may violate local/international laws. Developers assume no liability for misuse.

