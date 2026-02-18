---
sidebar_position: 6
---

# Contracts Library Guide

The **Gandalan.IDAS.Contracts** library provides contracts, base classes, and interfaces that define the core abstractions used across the IDAS ecosystem.

## Overview

The Contracts library includes:

- **BelegBase** - Abstract base class for business documents
- **Command Pattern** - ICommand, ICommandDispatcher interfaces
- **Repository Pattern** - `IRepository<T>` for data access
- **Change Tracking** - IVersionable, SyncableAttribute
- **Contracts** - Interfaces for common entities

## BelegBase Abstract Class

`BelegBase` is the foundation for all business documents (Belege) in IDAS.

### Structure

```csharp
using Gandalan.IDAS.Contracts.Belege;

public abstract class BelegBase
{
    // Identification
    public virtual Guid BelegGuid { get; set; }
    public long BelegNummer { get; set; }
    public int BelegJahr { get; set; }
    public BelegArt BelegArt { get; set; }
    
    // Dates
    public DateTime BelegDatum { get; set; }
    
    // Content
    public string BelegTitelUeberschrift { get; set; }
    public string BelegTitelZeile1 { get; set; }
    public string BelegTitelZeile2 { get; set; }
    public string Schlusstext { get; set; }
    public string ZahlungsBedingungen { get; set; }
    
    // Abstract methods for positions
    public abstract IEnumerable<BelegPositionBase> GetPositionen();
    public abstract void AddOrUpdatePosition(BelegPositionBase position);
    public abstract void RemovePosition(BelegPositionBase position);
    
    // Abstract methods for balances
    public abstract IEnumerable<BelegSaldoBase> GetSalden();
    public abstract void AddOrUpdateSaldo(BelegSaldoBase saldo);
    public abstract void RemoveSaldo(BelegSaldoBase saldo);
    
    // Abstract method for history
    public abstract void AddHistorie(BelegHistorieBase eintrag);
}
```

### Creating a Custom Beleg

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Gandalan.IDAS.Contracts.Belege;

public class CustomBeleg : BelegBase
{
    private List<CustomBelegPosition> _positionen = new();
    private List<BelegSaldo> _salden = new();
    private List<BelegHistorie> _historie = new();
    
    // Implement abstract methods
    public override IEnumerable<BelegPositionBase> GetPositionen()
        => _positionen.Cast<BelegPositionBase>();
    
    public override void AddOrUpdatePosition(BelegPositionBase position)
    {
        var existing = _positionen.FirstOrDefault(p => p.BelegPositionGuid == position.BelegPositionGuid);
        if (existing != null)
            _positionen.Remove(existing);
        _positionen.Add((CustomBelegPosition)position);
    }
    
    public override void RemovePosition(BelegPositionBase position)
    {
        var toRemove = _positionen.FirstOrDefault(p => p.BelegPositionGuid == position.BelegPositionGuid);
        if (toRemove != null)
            _positionen.Remove(toRemove);
    }
    
    public override IEnumerable<BelegSaldoBase> GetSalden()
        => _salden.Cast<BelegSaldoBase>();
    
    public override void AddOrUpdateSaldo(BelegSaldoBase saldo)
    {
        var existing = _salden.FirstOrDefault(s => s.BelegSaldoGuid == saldo.BelegSaldoGuid);
        if (existing != null)
            _salden.Remove(existing);
        _salden.Add((BelegSaldo)saldo);
    }
    
    public override void RemoveSaldo(BelegSaldoBase saldo)
    {
        var toRemove = _salden.FirstOrDefault(s => s.BelegSaldoGuid == saldo.BelegSaldoGuid);
        if (toRemove != null)
            _salden.Remove(toRemove);
    }
    
    public override void AddHistorie(BelegHistorieBase eintrag)
    {
        _historie.Add((BelegHistorie)eintrag);
    }
}
```

### BelegPositionBase

```csharp
public abstract class BelegPositionBase
{
    public Guid BelegPositionGuid { get; set; }
    public int LaufendeNummer { get; set; }
    public string ArtikelNummer { get; set; }
    public string Beschreibung { get; set; }
    public decimal Menge { get; set; }
    public decimal Einzelpreis { get; set; }
    public decimal Gesamtpreis => Menge * Einzelpreis;
}
```

## Command Pattern

The Command pattern provides a standardized way to execute operations with parameters and return results.

### ICommand Interface

```csharp
using System.Collections.Generic;
using Gandalan.UI.Commands.Contracts;

public interface ICommand
{
    string Command { get; }
    ICommandResult InvokeCommand(Dictionary<string, string> parameter);
}
```

### ICommandResult Interface

```csharp
public interface ICommandResult
{
    bool Success { get; }
    string Message { get; }
    object Data { get; }
    CommandResultStatusCode StatusCode { get; }
}
```

### ICommandDispatcher Interface

```csharp
public interface ICommandDispatcher
{
    ICommandResult Execute(string command, Dictionary<string, string> parameters);
    void Register(string commandName, ICommand command);
}
```

### Implementing a Command

```csharp
using System.Collections.Generic;
using Gandalan.UI.Commands.Contracts;

public class CalculateTotalCommand : ICommand
{
    public string Command => "CalculateTotal";
    
    public ICommandResult InvokeCommand(Dictionary<string, string> parameters)
    {
        try
        {
            // Parse parameters
            if (!parameters.TryGetValue("amount", out var amountStr) ||
                !parameters.TryGetValue("taxRate", out var taxRateStr))
            {
                return new CommandResult
                {
                    Success = false,
                    StatusCode = CommandResultStatusCode.BadRequest,
                    Message = "Missing required parameters"
                };
            }
            
            var amount = decimal.Parse(amountStr);
            var taxRate = decimal.Parse(taxRateStr);
            
            // Calculate
            var tax = amount * taxRate / 100;
            var total = amount + tax;
            
            return new CommandResult
            {
                Success = true,
                StatusCode = CommandResultStatusCode.OK,
                Message = "Calculation successful",
                Data = new { Amount = amount, Tax = tax, Total = total }
            };
        }
        catch (Exception ex)
        {
            return new CommandResult
            {
                Success = false,
                StatusCode = CommandResultStatusCode.Error,
                Message = $"Calculation failed: {ex.Message}"
            };
        }
    }
}

public class CommandResult : ICommandResult
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
    public CommandResultStatusCode StatusCode { get; set; }
}
```

### Using the Command Dispatcher

```csharp
public class CommandExample
{
    private readonly ICommandDispatcher _dispatcher;
    
    public CommandExample()
    {
        _dispatcher = new CommandDispatcher();
        
        // Register commands
        _dispatcher.Register("CalculateTotal", new CalculateTotalCommand());
        _dispatcher.Register("SendEmail", new SendEmailCommand());
    }
    
    public void ExecuteCalculation()
    {
        var parameters = new Dictionary<string, string>
        {
            ["amount"] = "100.00",
            ["taxRate"] = "19"
        };
        
        var result = _dispatcher.Execute("CalculateTotal", parameters);
        
        if (result.Success)
        {
            var data = (dynamic)result.Data;
            Console.WriteLine($"Total: {data.Total}");
        }
        else
        {
            Console.WriteLine($"Error: {result.Message}");
        }
    }
}
```

## Repository Pattern

The Repository pattern abstracts data access operations.

### `IRepository<T>` Interface

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Contracts.Repositories;

public interface IRepository<T> where T : class
{
    // Create operations
    T Create();
    void Add(T entity, bool saveImmediately = true);
    void AddOrUpdate(T entity, bool saveImmediately = true);
    void AddOrUpdateRange(IEnumerable<T> range, bool saveImmediately = true);
    
    // Read operations
    T Get(long id);
    Task<T> GetAsync(long id);
    T GetOrCreate(long id);
    IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, 
                       Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
                       string includeProperties = "");
    IQueryable<T> Query();
    IQueryable<T> GetAllForRead();
    IQueryable<T> GetAll();
    bool Exists(T entity);
    
    // Update operations
    void Update(T entity, bool saveImmediately = true);
    void Replace(T oldEntity, T newEntity, bool saveImmediately = true);
    void CancelChanges(T entity);
    
    // Delete operations
    void Remove(T entity, bool saveImmediately = true);
    void RemoveRange(IEnumerable<T> range, bool saveImmediately = true);
    void RemoveAll(bool saveImmediately = true);
    
    // Persistence
    bool Save();
}
```

### Implementing a Repository

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Gandalan.IDAS.Contracts.Repositories;

public class InMemoryRepository<T> : IRepository<T> where T : class
{
    private readonly List<T> _entities = new();
    private long _nextId = 1;
    
    public T Create()
    {
        return Activator.CreateInstance<T>();
    }
    
    public void Add(T entity, bool saveImmediately = true)
    {
        _entities.Add(entity);
        // In real implementation, save to database
    }
    
    public void AddOrUpdate(T entity, bool saveImmediately = true)
    {
        // Check if exists and update, else add
        if (!_entities.Contains(entity))
            Add(entity, saveImmediately);
        else
            Update(entity, saveImmediately);
    }
    
    public T Get(long id)
    {
        // Implementation depends on entity structure
        throw new NotImplementedException();
    }
    
    public Task<T> GetAsync(long id)
    {
        return Task.FromResult(Get(id));
    }
    
    public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, 
                               Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
                               string includeProperties = "")
    {
        IQueryable<T> query = _entities.AsQueryable();
        
        if (filter != null)
            query = query.Where(filter);
        
        if (orderBy != null)
            query = orderBy(query);
        
        return query.ToList();
    }
    
    public IQueryable<T> Query() => _entities.AsQueryable();
    public IQueryable<T> GetAllForRead() => _entities.AsQueryable();
    public IQueryable<T> GetAll() => _entities.AsQueryable();
    
    public bool Exists(T entity) => _entities.Contains(entity);
    
    public void Update(T entity, bool saveImmediately = true)
    {
        // In real implementation, mark as modified
    }
    
    public void Remove(T entity, bool saveImmediately = true)
    {
        _entities.Remove(entity);
    }
    
    public bool Save() => true;
    
    // ... other implementations
    public void AddOrUpdateRange(IEnumerable<T> range, bool saveImmediately = true) { }
    public T GetOrCreate(long id) => Get(id) ?? Create();
    public void Replace(T oldEntity, T newEntity, bool saveImmediately = true) { }
    public void RemoveRange(IEnumerable<T> range, bool saveImmediately = true) { }
    public void RemoveAll(bool saveImmediately = true) => _entities.Clear();
    public void CancelChanges(T entity) { }
}
```

### Using a Repository

```csharp
public class OrderService
{
    private readonly IRepository<Order> _orderRepository;
    
    public OrderService(IRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public Order CreateOrder(OrderDto dto)
    {
        var order = _orderRepository.Create();
        order.CustomerId = dto.CustomerId;
        order.Items = dto.Items;
        order.Total = dto.Items.Sum(i => i.Price * i.Quantity);
        
        _orderRepository.Add(order);
        _orderRepository.Save();
        
        return order;
    }
    
    public IEnumerable<Order> GetPendingOrders()
    {
        return _orderRepository.Get(
            filter: o => o.Status == OrderStatus.Pending,
            orderBy: q => q.OrderBy(o => o.CreatedDate)
        );
    }
    
    public void UpdateOrderStatus(long orderId, OrderStatus status)
    {
        var order = _orderRepository.Get(orderId);
        if (order != null)
        {
            order.Status = status;
            _orderRepository.Update(order);
            _orderRepository.Save();
        }
    }
}
```

## Change Tracking

### IVersionable Interface

Provides versioning and change tracking capabilities.

```csharp
using System;
using Gandalan.IDAS.Contracts.ChangeTracking;

public interface IVersionable
{
    long Version { get; set; }
    DateTime ChangedDate { get; set; }
}
```

### SyncableAttribute

Marks classes that can be synchronized across systems.

```csharp
using System;
using Gandalan.IDAS.Contracts.ChangeTracking;

[Syncable("EntityGuid")]
public class SyncableEntity : IVersionable
{
    public Guid EntityGuid { get; set; }
    public long Version { get; set; }
    public DateTime ChangedDate { get; set; }
    public string Data { get; set; }
}
```

### Using Change Tracking

```csharp
public class ChangeTrackingExample
{
    public void UpdateEntity(SyncableEntity entity)
    {
        // Update version and timestamp
        entity.Version++;
        entity.ChangedDate = DateTime.UtcNow;
        
        // Save changes
        SaveToDatabase(entity);
    }
    
    public bool HasConflicts(SyncableEntity local, SyncableEntity remote)
    {
        // Check if remote has newer version
        return remote.Version > local.Version && 
               remote.ChangedDate > local.ChangedDate;
    }
    
    public void SyncEntities(List<SyncableEntity> localEntities, 
                             List<SyncableEntity> remoteEntities)
    {
        foreach (var remote in remoteEntities)
        {
            var local = localEntities.FirstOrDefault(
                l => l.EntityGuid == remote.EntityGuid);
            
            if (local == null)
            {
                // New entity
                localEntities.Add(remote);
            }
            else if (remote.Version > local.Version)
            {
                // Update local
                var index = localEntities.IndexOf(local);
                localEntities[index] = remote;
            }
        }
    }
}
```

## Other Contracts

### IMandant

```csharp
public interface IMandant
{
    Guid MandantGuid { get; set; }
    string MandantenName { get; set; }
    string KundenNummer { get; set; }
}
```

### IBenutzerBase

```csharp
public interface IBenutzerBase
{
    Guid BenutzerGuid { get; set; }
    string Email { get; set; }
    string Vorname { get; set; }
    string Nachname { get; set; }
    string Benutzername { get; set; }
}
```

### IObjectCache

```csharp
public interface IObjectCache
{
    T Get<T>(string key);
    void Set<T>(string key, T value, TimeSpan? expiration = null);
    bool Remove(string key);
    bool Contains(string key);
    void Clear();
}
```

---

For complete API documentation, see the [API Reference](/api/csharp).
