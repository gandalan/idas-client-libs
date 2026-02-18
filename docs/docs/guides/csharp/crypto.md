---
sidebar_position: 4
---

# Crypto Library Guide

The **Gandalan.IDAS.Crypto** library provides cryptographic utilities for encryption, hashing, and encoding operations commonly used in IDAS applications.

## Overview

The Crypto library includes:

- **AES Encryption** - Symmetric encryption for secure data storage
- **BCrypt Hashing** - Password hashing with salt
- **SHA1 Hashing** - One-way hashing for data integrity
- **Hex Encoding** - Byte array to hexadecimal string conversion

## AES Encryption

AES (Advanced Encryption Standard) provides symmetric encryption for securing sensitive data.

### Encrypting Data

```csharp
using Gandalan.IDAS.Crypto;

// Encrypt a string
string plainText = "Sensitive data";
string password = "MySecretPassword123";

string encrypted = AESHelper.EncryptData(plainText, password);
Console.WriteLine($"Encrypted: {encrypted}");
// Output: Base64 encoded encrypted string
```

### Decrypting Data

```csharp
using Gandalan.IDAS.Crypto;

// Decrypt a string
string encryptedData = "...";
string password = "MySecretPassword123";

try
{
    string decrypted = AESHelper.DecryptData(encryptedData, password);
    Console.WriteLine($"Decrypted: {decrypted}");
}
catch (Exception ex)
{
    Console.WriteLine($"Decryption failed: {ex.Message}");
}
```

### Working with Byte Arrays

For binary data encryption:

```csharp
using System.Security.Cryptography;
using Gandalan.IDAS.Crypto;

// Encrypt byte array
byte[] data = File.ReadAllBytes("document.pdf");
string password = "MySecretPassword123";

byte[] encrypted = AESHelper.EncryptData(data, password, PaddingMode.ISO10126);

// Decrypt byte array
byte[] decrypted = AESHelper.DecryptData(encrypted, password, PaddingMode.ISO10126);
File.WriteAllBytes("document_decrypted.pdf", decrypted);
```

### Complete Example

```csharp
using System;
using Gandalan.IDAS.Crypto;

public class SecureStorage
{
    private readonly string _encryptionKey;

    public SecureStorage(string encryptionKey)
    {
        _encryptionKey = encryptionKey;
    }

    public string Encrypt(string plainText)
    {
        if (string.IsNullOrEmpty(plainText))
            return null;
            
        return AESHelper.EncryptData(plainText, _encryptionKey);
    }

    public string Decrypt(string cipherText)
    {
        if (string.IsNullOrEmpty(cipherText))
            return null;
            
        try
        {
            return AESHelper.DecryptData(cipherText, _encryptionKey);
        }
        catch
        {
            // Handle decryption failure
            return null;
        }
    }
}

// Usage
var storage = new SecureStorage("MyStrongPassword123");
var encrypted = storage.Encrypt("Credit Card: 1234-5678-9012-3456");
var decrypted = storage.Decrypt(encrypted);
```

## BCrypt Password Hashing

BCrypt is a secure password hashing algorithm that automatically handles salt generation.

### Hashing Passwords

```csharp
using Gandalan.IDAS.Crypto;

// Hash a password
string password = "userPassword123";
string hash = BCryptHelper.GetBCryptHash(password);

Console.WriteLine($"Hash: {hash}");
// Output: $2a$10$... (60 character hash)
```

### Verifying Passwords

```csharp
using BCrypt.Net;

// Verify a password against stored hash
string password = "userPassword123";
string storedHash = "$2a$10$...";

bool isValid = BCrypt.Net.BCrypt.Verify(password, storedHash);

if (isValid)
{
    Console.WriteLine("Password is correct");
}
else
{
    Console.WriteLine("Password is incorrect");
}
```

### User Authentication Example

```csharp
using System.Collections.Generic;
using Gandalan.IDAS.Crypto;
using BCrypt.Net;

public class UserService
{
    private readonly Dictionary<string, string> _userStore = new();

    // Register a new user
    public void RegisterUser(string username, string password)
    {
        // Hash the password
        string passwordHash = BCryptHelper.GetBCryptHash(password);
        
        // Store username and hash
        _userStore[username] = passwordHash;
    }

    // Authenticate a user
    public bool AuthenticateUser(string username, string password)
    {
        if (!_userStore.TryGetValue(username, out var storedHash))
            return false;

        // Verify password against stored hash
        return BCrypt.Verify(password, storedHash);
    }

    // Change password
    public bool ChangePassword(string username, string currentPassword, string newPassword)
    {
        if (!AuthenticateUser(username, currentPassword))
            return false;

        _userStore[username] = BCryptHelper.GetBCryptHash(newPassword);
        return true;
    }
}

// Usage
var userService = new UserService();
userService.RegisterUser("john.doe", "SecurePass123!");
bool isValid = userService.AuthenticateUser("john.doe", "SecurePass123!");
```

## SHA1 Hashing

SHA1 provides one-way hashing for data integrity checks. **Note:** SHA1 is not recommended for cryptographic security, use BCrypt for passwords.

### Creating SHA1 Hashes

```csharp
using Gandalan.IDAS.Crypto;

// Hash a string
string data = "Data to hash";
string hash = SHA1Helper.GetSHA1Hash(data);

Console.WriteLine($"SHA1: {hash}");
// Output: 40 character hexadecimal string
```

### Data Integrity Check

```csharp
using Gandalan.IDAS.Crypto;

public class FileIntegrityChecker
{
    public string CalculateHash(string filePath)
    {
        byte[] fileBytes = File.ReadAllBytes(filePath);
        string content = Convert.ToBase64String(fileBytes);
        return SHA1Helper.GetSHA1Hash(content);
    }

    public bool VerifyIntegrity(string filePath, string expectedHash)
    {
        string actualHash = CalculateHash(filePath);
        return actualHash.Equals(expectedHash, StringComparison.OrdinalIgnoreCase);
    }
}

// Usage
var checker = new FileIntegrityChecker();
string hash = checker.CalculateHash("document.pdf");
bool isValid = checker.VerifyIntegrity("document.pdf", hash);
```

## Hex Encoding

HexEncoding utilities convert between byte arrays and hexadecimal strings.

### Converting Bytes to Hex

```csharp
using Gandalan.IDAS.Crypto;

// Convert byte array to hex string
byte[] bytes = { 0x00, 0x1A, 0xFF, 0x42 };
string hex = HexEncoding.ToString(bytes);

Console.WriteLine(hex); // Output: 001AFF42
```

### Converting Hex to Bytes

```csharp
using Gandalan.IDAS.Crypto;

// Convert hex string to byte array
string hex = "001AFF42";
int discarded;
byte[] bytes = HexEncoding.GetBytes(hex, out discarded);

Console.WriteLine($"Bytes: {BitConverter.ToString(bytes)}");
Console.WriteLine($"Discarded characters: {discarded}");
```

### Validating Hex Strings

```csharp
using Gandalan.IDAS.Crypto;

// Check if string is valid hex
bool isValid1 = HexEncoding.InHexFormat("001AFF42");     // true
bool isValid2 = HexEncoding.InHexFormat("001AGF42");     // false (G is not hex)
bool isValid3 = HexEncoding.InHexFormat("00 1A FF 42");  // false (spaces)

// Check individual characters
bool isHexDigit = HexEncoding.IsHexDigit('A');  // true
bool isHexDigit2 = HexEncoding.IsHexDigit('G'); // false
```

### Working with Mixed Content

```csharp
using Gandalan.IDAS.Crypto;

// Handle hex strings with non-hex characters
string mixed = "0x00, 0x1A, 0xFF";
int discarded;
byte[] bytes = HexEncoding.GetBytes(mixed, out discarded);

Console.WriteLine($"Extracted {bytes.Length} bytes, discarded {discarded} chars");
```

## Complete Security Example

```csharp
using System;
using Gandalan.IDAS.Crypto;
using BCrypt.Net;

public class SecureDataManager
{
    private readonly string _aesKey;

    public SecureDataManager(string aesKey)
    {
        _aesKey = aesKey;
    }

    // Store sensitive user data
    public UserData StoreUserData(string username, string password, string ssn)
    {
        return new UserData
        {
            Username = username,
            // Hash password with BCrypt
            PasswordHash = BCryptHelper.GetBCryptHash(password),
            // Encrypt sensitive data with AES
            EncryptedSSN = AESHelper.EncryptData(ssn, _aesKey),
            // Create integrity hash
            DataHash = SHA1Helper.GetSHA1Hash($"{username}:{ssn}")
        };
    }

    // Verify and retrieve data
    public bool VerifyPassword(UserData userData, string password)
    {
        return BCrypt.Verify(password, userData.PasswordHash);
    }

    public string DecryptSSN(UserData userData)
    {
        try
        {
            return AESHelper.DecryptData(userData.EncryptedSSN, _aesKey);
        }
        catch
        {
            return null;
        }
    }
}

public class UserData
{
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string EncryptedSSN { get; set; }
    public string DataHash { get; set; }
}
```

## Security Best Practices

1. **Use BCrypt for passwords** - Never store plain text passwords
2. **Use AES for sensitive data** - Encrypt data at rest
3. **Protect encryption keys** - Store keys securely, not in code
4. **Use HTTPS for transmission** - Always use TLS for network communication
5. **Validate input** - Always validate data before encryption/hashing

---

For complete API documentation, see the [API Reference](/docs/api/csharp).
