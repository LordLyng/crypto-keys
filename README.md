# CryptoKeys

CryptoKeys is a small dotnet core global tool for generating AES encryption Initialization vectors and Keys.  
The Application uses AesCryptoServiceProvider to generate abovementioned artifacts. output ios printed as base64 string.

**Note** The tool isn't available on the NuGet Gallery as of now. the easiest way to install is packing it manually and then installing it locally.

## Building (packing)

Navigate to root of project, run ```dotnet pack -c Release```  -> A new folder called nupkg should show up in the project folder.

## Installation

Install the global tool by running the following ```dotnet tool install crypto-keys -g --add-source <path to nupkg folder form before>```

## Usage

After installing help can be read by running ```crypto-keys --help``` from a terminal.

**Note** You might have to restart your terminal after installation for this to eb available.