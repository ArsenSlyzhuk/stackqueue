using System;
using System.Collections.Generic;

// Завдання 1: Керування стеком документів
public class Document
{
    public int DocumentId { get; set; }
    public string Title { get; set; }

    public override string ToString()
    {
        return $"Документ ID: {DocumentId}, Назва: {Title}";
    }
}

public class DocumentStack
{
    private Stack<Document> documentStack = new Stack<Document>();

    // Додавання нового документу до стеку
    public void AddDocument(Document document)
    {
        documentStack.Push(document);
        Console.WriteLine($"Документ '{document.Title}' додано до стеку.");
    }

    // Видалення верхнього документу зі стеку
    public void RemoveDocument()
    {
        if (documentStack.Count > 0)
        {
            Document removedDocument = documentStack.Pop();
            Console.WriteLine($"Документ '{removedDocument.Title}' видалено зі стеку.");
        }
        else
        {
            Console.WriteLine("Стек документів порожній.");
        }
    }

    // Отримання верхнього документу зі стеку без його видалення
    public Document PeekDocument()
    {
        if (documentStack.Count > 0)
        {
            return documentStack.Peek();
        }
        else
        {
            Console.WriteLine("Стек документів порожній.");
            return null;
        }
    }

    // Виведення інформації про верхній документ у стеці
    public void DisplayTopDocument()
    {
        Document topDocument = PeekDocument();
        if (topDocument != null)
        {
            Console.WriteLine($"Верхній документ у стеці: {topDocument}");
        }
    }
}

// Завдання 2: Керування чергою замовлень
public class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }

    public override string ToString()
    {
        return $"Замовлення ID: {OrderId}, Клієнт: {CustomerName}";
    }
}

public class OrderQueue
{
    private Queue<Order> orderQueue = new Queue<Order>();

    // Додавання нового замовлення до черги
    public void AddOrder(Order order)
    {
        orderQueue.Enqueue(order);
        Console.WriteLine($"Замовлення для клієнта '{order.CustomerName}' додано до черги.");
    }

    // Видалення найстаршого замовлення з черги
    public void RemoveOrder()
    {
        if (orderQueue.Count > 0)
        {
            Order removedOrder = orderQueue.Dequeue();
            Console.WriteLine($"Замовлення для клієнта '{removedOrder.CustomerName}' видалено з черги.");
        }
        else
        {
            Console.WriteLine("Черга замовлень порожня.");
        }
    }

    // Отримання найстаршого замовлення з черги без його видалення
    public Order PeekOrder()
    {
        if (orderQueue.Count > 0)
        {
            return orderQueue.Peek();
        }
        else
        {
            Console.WriteLine("Черга замовлень порожня.");
            return null;
        }
    }

    // Виведення інформації про найстарше замовлення у черзі
    public void DisplayFirstOrder()
    {
        Order firstOrder = PeekOrder();
        if (firstOrder != null)
        {
            Console.WriteLine($"Найстарше замовлення у черзі: {firstOrder}");
        }
    }
}

// Завдання 3: Магазин книг зі словником книг
public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }

    public override string ToString()
    {
        return $"Книга ID: {BookId}, Назва: {Title}";
    }
}

public class BookStore
{
    private Dictionary<int, Book> bookDictionary = new Dictionary<int, Book>();

    // Додавання нової книги до словника
    public void AddBook(Book book)
    {
        bookDictionary[book.BookId] = book;
        Console.WriteLine($"Книга '{book.Title}' додана до магазину.");
    }

    // Видалення книги зі словника за її унікальним ідентифікатором
    public void RemoveBook(int bookId)
    {
        if (bookDictionary.Remove(bookId))
        {
            Console.WriteLine($"Книга з ID {bookId} видалена з магазину.");
        }
        else
        {
            Console.WriteLine($"Книга з ID {bookId} не знайдена.");
        }
    }

    // Отримання інформації про книгу зі словника
    public void DisplayBook(int bookId)
    {
        if (bookDictionary.TryGetValue(bookId, out Book book))
        {
            Console.WriteLine($"Інформація про книгу: {book}");
        }
        else
        {
            Console.WriteLine($"Книга з ID {bookId} не знайдена.");
        }
    }
}

// Тестування
class Program
{
    static void Main()
    {
        // Тестування DocumentStack
        Console.WriteLine("Тестування стеку документів:");
        DocumentStack documentStack = new DocumentStack();

        documentStack.AddDocument(new Document { DocumentId = 1, Title = "Документ 1" });
        documentStack.AddDocument(new Document { DocumentId = 2, Title = "Документ 2" });
        documentStack.DisplayTopDocument();
        documentStack.RemoveDocument();
        documentStack.DisplayTopDocument();

        // Тестування OrderQueue
        Console.WriteLine("\nТестування черги замовлень:");
        OrderQueue orderQueue = new OrderQueue();

        orderQueue.AddOrder(new Order { OrderId = 1, CustomerName = "Клієнт 1" });
        orderQueue.AddOrder(new Order { OrderId = 2, CustomerName = "Клієнт 2" });
        orderQueue.DisplayFirstOrder();
        orderQueue.RemoveOrder();
        orderQueue.DisplayFirstOrder();

        // Тестування BookStore
        Console.WriteLine("\nТестування магазину книг:");
        BookStore bookStore = new BookStore();

        bookStore.AddBook(new Book { BookId = 1, Title = "Книга 1" });
        bookStore.AddBook(new Book { BookId = 2, Title = "Книга 2" });
        bookStore.DisplayBook(1);
        bookStore.RemoveBook(1);
        bookStore.DisplayBook(1);
    }
}
