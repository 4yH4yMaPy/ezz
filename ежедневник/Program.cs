using System;
using System.Collections.Generic;

class Program
{
    static int currentNoteIndex = 0;
    static List<Note> notes = new List<Note>();

    static void Main()
    {
        InitializeNotes();

        ConsoleKeyInfo key;
        do
        {
            Console.Clear();
            ShowNoteTitle();

            key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    GoToPreviousDate();
                    break;
                case ConsoleKey.RightArrow:
                    GoToNextDate();
                    break;
                case ConsoleKey.Enter:
                    ShowNoteDetails();
                    break;
            }
        } while (key.Key != ConsoleKey.Escape);
    }

    static void InitializeNotes()
    {
       
        notes.Add(new Note { Title = "Гулять", Description = "Гулять", Date = new DateTime(2024, 1, 29) });
        notes.Add(new Note { Title = "Спать", Description = "Спать ночью", Date = new DateTime(2024, 2, 3) });
        notes.Add(new Note { Title = "Курить", Description = "Покурить днем", Date = new DateTime(2023, 2, 18) });
        notes.Add(new Note { Title = "Играть", Description = "Играть в комп", Date = new DateTime(2023, 3, 12) });
        notes.Add(new Note { Title = "Плавать", Description = "Пойти в бассейн", Date = new DateTime(2023, 5, 2) });
    }

    static void ShowNoteTitle()
    {
        Note currentNote = notes[currentNoteIndex];
        Console.WriteLine("Дата: " + currentNote.Date.ToString("dd.MM.yyyy"));
        Console.WriteLine("Название: " + currentNote.Title);
    }
    static void GoToNextDate()
    {
        currentNoteIndex = (currentNoteIndex + 1) % notes.Count;
    }

    static void GoToPreviousDate()
    {
        currentNoteIndex = (currentNoteIndex - 1 + notes.Count) % notes.Count;
    }

    static void ShowNoteDetails()
    {
        Note currentNote = notes[currentNoteIndex];
        Console.Clear();
        Console.WriteLine("Дата: " + currentNote.Date.ToString("dd.MM.yyyy"));
        Console.WriteLine("Название: " + currentNote.Title);
        Console.WriteLine("Описание: " + currentNote.Description);
        Console.WriteLine("Заметка должна быть выполнена: " + currentNote.DueDate.ToString("dd.MM.yyyy"));
        Console.WriteLine();
        Console.WriteLine("Нажмите любую клавишу для возврата к списку заметок");
        Console.ReadKey();
    }
}

class Note
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}