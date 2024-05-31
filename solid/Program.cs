// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


#region SingleResponsibility
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }

    public Book(string title, string author, string isbn)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
    }
}
public class BookRepository
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public List<Book> GetAllBooks()
    {
        return books;
    }
}
#endregion

#region OpenClose
public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public string EmailAddress { get; set; }

    public EmailNotification(string emailAddress)
    {
        EmailAddress = emailAddress;
    }

    public void Send(string message)
    {
        Console.WriteLine($"Sending Email to {EmailAddress}: {message}");
    }
}

public class SMSNotification : INotification
{
    public string PhoneNumber { get; set; }

    public SMSNotification(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }

    public void Send(string message)
    {
        Console.WriteLine($"Sending SMS to {PhoneNumber}: {message}");
    }
}

public class NotificationSender
{
    private readonly List<INotification> _notifications;

    public NotificationSender()
    {
        _notifications = new List<INotification>();
    }

    public void AddNotification(INotification notification)
    {
        _notifications.Add(notification);
    }

    public void SendAll(string message)
    {
        foreach (var notification in _notifications)
        {
            notification.Send(message);
        }
    }
}
#endregion

#region Liskov
public class Bird
{
    public virtual void MakeSound()
    {
        Console.WriteLine("Bird sound...");
    }
}

public interface IFlyable
{
    void Fly();
}

public class Eagle : Bird, IFlyable
{
    public void Fly()
    {
        Console.WriteLine("Eagle flying high...");
    }
}

public class Penguin : Bird
{
    // Penguins cannot fly
}
#endregion

#region InterfaceSegrigation
public interface IPrinter
{
    void Print(Document document);
}

public interface IScanner
{
    void Scan(Document document);
}

public interface IFax
{
    void Fax(Document document);
}



public class OldFashionedPrinter : IPrinter
{
    public void Print(Document document)
    {
        Console.WriteLine("Printing document...");
    }
}

public class ModernPrinter : IPrinter, IScanner, IFax
{
    public void Print(Document document)
    {
        Console.WriteLine("Printing document...");
    }

    public void Scan(Document document)
    {
        Console.WriteLine("Scanning document...");
    }

    public void Fax(Document document)
    {
        Console.WriteLine("Faxing document...");
    }
}

public class Document
{
    // ...
}
#endregion

#region DependencyInversion
public interface INotificationService
{
    void Notify(string message);
}

public class EmailService : INotificationService
{
    public void Notify(string message)
    {
        Console.WriteLine($"Sending email: {message}");
    }
}

public class SMSService : INotificationService
{
    public void Notify(string message)
    {
        Console.WriteLine($"Sending SMS: {message}");
    }
}

public class CustomerService
{
    private readonly INotificationService _notificationService;

    public CustomerService(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public void NotifyCustomer(string message)
    {
        _notificationService.Notify(message);
    }
}
#endregion
